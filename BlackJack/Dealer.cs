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
        private Queue<Card> _cardStack;
        private Table _table;
        private string _input; 
        public Dealer(Card[] deck, IShuffler shuffler)
        {
            
        }

        private void SetTable()
        {
            
        }
        
        private void ShuffleDeck()
        {
            var shuffledDeck = new Card[52];
            var place = new Random();
            var cardExists = new bool[52];

            for (var i = 0; i < 52; i++)
            {
                var cardPlace = 0;
                var foundPlace = false;
                while (!foundPlace)
                {
                    cardPlace = place.Next(52);
                    if (!cardExists[cardPlace])
                    {
                        foundPlace = true;
                    }
                }

                cardExists[cardPlace] = true;
                try
                {
                    shuffledDeck[cardPlace] = _deck[i];
                } catch (NullException){}
                
            }
            
            shuffledDeck.CopyTo(_deck, 0);
        }

        private void PrepareDeck(Card[] deck)
        {
            _cardStack = new Queue<Card>();
            foreach (var card in deck)
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