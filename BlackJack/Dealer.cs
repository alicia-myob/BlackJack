using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit.Sdk;

namespace BlackJack_Kata
{
    public class Dealer
    {
        private Card[] _deck;
        private BasicShuffler _shuffler;
        private Queue<Card> _cardStack;
        private Table _table;
        private string _input; 
        public Dealer(Card[] deck, IShuffler shuffler)
        {
            _deck = deck;
            _shuffler = (BasicShuffler) shuffler;
            ShuffleDeck();
            PrepareDeck();
        }

        public void SetTable(Table table)
        {
            _table = table;
        }
        
        private void ShuffleDeck()
        {
           _deck = _shuffler.Shuffle(_deck);
        }

        private void PrepareDeck()
        {
            _cardStack = new Queue<Card>();
            foreach (var card in _deck)
            {
                _cardStack.Enqueue(card);
            }
        }
        
        public void DealCardToPlayer(Player player, int numOfDeals)
        {
            for (var i = 0; i < numOfDeals; i++)
            {
                player.ReceiveCard(_cardStack.Dequeue());
            }
        }
        
        private void AnnounceScore(Player player)
        {
            var playerScore = ValueCalculator.HandWorth(player.GetHand());
            player.ReceiveScore(playerScore);
            _table.AnnounceScore(player);
        }

        public int AskHitOrStay()
        {
            var keepAsking = false;
            while (!keepAsking)
            {
                Console.Write("\nHit or stay? (Hit = 1, Stay = 0)");
                _input = Console.ReadLine();
                keepAsking = InputValidator.CheckHitStayInput(_input);
                if (keepAsking)
                {
                    if (_input != null) return int.Parse(_input.Trim(), NumberStyles.AllowLeadingWhite| NumberStyles.AllowTrailingWhite);
                }
                else
                {
                    Console.WriteLine("Please check your input!");
                }
            }

            return 0;
        }

        public Table GetTable()
        {
            return _table;
        }




    }
}