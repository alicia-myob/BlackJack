namespace BlackJack_Kata
{
    public class Deck
    {
        public Deck()
        {
            var deck = new Card[52];
            for (var suit = 0; suit < 4; suit++)
            {
                for (var rank = 1; rank < 14; rank++)
                {
                    deck[suit * 13 + rank - 1] = new Card((Suit) suit, (Rank) rank);
                }
            }
        }
    }
}