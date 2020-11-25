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

        private static bool IsPictureCard(Rank rank)
        {
            return ((rank >= Rank.Jack) && (rank <= Rank.King));
        }
        

        public int Value(Card card)
        {
            if (IsPictureCard(card.GetRank()))
            {
                return 10;
            }
            else
            {
                return (int) (card.GetRank());
            }
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