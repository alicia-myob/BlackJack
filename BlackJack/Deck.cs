using System;
using System.Collections;
using System.Collections.Generic;

namespace BlackJack_Kata
{
    public class Deck 
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

        public Card[] GetDeck()
        {
            return _deck;
        }
    }
}