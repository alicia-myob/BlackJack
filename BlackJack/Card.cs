using System;

namespace BlackJack_Kata
{
    /**
     * <summary>Class <c>Card</c> is a model class representing a standard playing card</summary>
     */
    public class Card
    {
        private readonly Suit _suit;
        private readonly Rank _rank;
        public Card(Suit suit, Rank rank)
        {
            _suit = suit;
            _rank = rank;
        }
        
        /**
         * <summary>This method turns the card into a string in the required format</summary>
         */
        public override string ToString()
        {
            return "[" + _rank + ", " + _suit + "]";
        }

        public Rank GetRank()
        {
            return _rank;
        }

        public Suit GetSuit()
        {
            return _suit; 
        }
    }
    public enum Suit
    {
        Spade, Heart, Diamond, Club
    }

    public enum Rank
    {
        Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
    }
}