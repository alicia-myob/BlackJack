using System;
using System.Collections;
using System.Collections.Generic;

namespace BlackJack_Kata
{
    /**
     * <summary>Class <c>Deck</c> represents a standard deck of 52 playing cards. It is a card
     * array made up of Card objects</summary>
     */
    public class Deck 
    {
        private readonly Card[] _deck;
        
        /**
         * <summary>This constructor creates a deck and stores it in a readonly field</summary>
         */
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