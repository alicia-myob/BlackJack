using System;
using System.Collections.Generic;
using Xunit.Sdk;

namespace BlackJack_Kata
{
    public class Dealer
    {
        private Card[] _deck;
        private Queue<Card> _cardStack;
        public Dealer()
        {
            
        }

        public void PrepareGame()
        {
            CreateDeck();
            ShuffleDeck();
            PrepareDeck(_deck);
        }

        private void CreateDeck()
        {
            _deck = new Card[52];
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

        public void DealCardToPlayer(Player player, int numOfDeals)
        {
            for (var i = 0; i < numOfDeals; i++)
            {
                player.ReceiveCard(_cardStack.Dequeue());
            }
        }
    }
}