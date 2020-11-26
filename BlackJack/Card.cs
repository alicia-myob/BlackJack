using System;

namespace BlackJack_Kata
{
    public class Card
    {
        private readonly Suit _suit;
        private readonly Rank _rank;
        public Card(Suit suit, Rank rank)
        {
            _suit = suit;
            _rank = rank;
        }
        
        public override string ToString()
        {
            return "[" + _rank + ", " + _suit + "]";
        }

        
        

        

        public Rank GetRank()
        {
            return _rank;
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