using System;
using System.Collections;
using System.Collections.Generic;

namespace BlackJack_Kata
{
    public class Deck : IEnumerable<Card>
    {
        private readonly Card[] _deck;
        public Deck()
        {
            _deck = new Card[52];
            for (var suit = 0; suit < 4; suit++)
            {
                for (var rank = 1; rank < 14; rank++)
                {
                    _deck[suit * 13 + rank - 1] = new Card((Suit) suit, (Rank) rank);
                }
            }
        }

        public void Shuffle()
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
                shuffledDeck[cardPlace] = _deck[i];
            }
            
            shuffledDeck.CopyTo(_deck, 0);
        }

        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= 51)
            {
                return _deck[cardNum];
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public IEnumerator<Card> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}