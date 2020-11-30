using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit.Sdk;

namespace BlackJack_Kata
{
    public class Dealer
    {
        private const int InitialNoOfCards = 2;
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

        public void StartGameWithPlayer(Player player)
        {
           DealCardToPlayer(player, InitialNoOfCards);
           AnnounceToTable(player);
           
        }
        public void DealCardToPlayer(Player player, int numOfDeals)
        {
            for (var i = 0; i < numOfDeals; i++)
            {
                player.ReceiveCard(_cardStack.Dequeue());
            }
        }

        public void GamePlay(Player player)
        {
            while (player.PlayerScoreUnder21())
            {
                if (player.PlayerScoreIs21())
                {
                    break;
                }

                if (AskHitOrStay() == 1)
                {
                    DealCardToPlayer(player, 1);
                    AnnounceToTable(player);
                }
                else
                {
                    
                }
            }
        }

        private int AskHitOrStay()
        {
            var keepAsking = false;
            while (!keepAsking)
            {
                Console.Write("Hit or stay? (Hit = 1, Stay = 0)");
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

        private void AnnounceToTable(Player player)
        {
            var playerScore = ValueCalculator.HandWorth(player.GetHand());
            player.ReceiveScore(playerScore);
            _table.AnnounceScore(player);
        }
        
        
    }
}