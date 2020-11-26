using System;
using System.Collections.Generic;
using Xunit.Sdk;

namespace BlackJack_Kata
{
    public class Dealer
    {
        private Card[] _deck;
        public Dealer()
        {
            
        }

        public void CreateDeck()
        {
            _deck = new Card[52];
        }
        
        public void ShuffleDeck()
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

        public void PrepareDeck(Card[] deck)
        {
            var gameDeck = new Queue<Card>();
            foreach (var card in deck)
            {
                gameDeck.Enqueue(card);
            }
        }
    }
}