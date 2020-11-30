namespace BlackJack_Kata
{
    public class GameMaster
    {
        private Card[] _deck;
        public GameMaster()
        {
            PrepareGame();
        }

        private void PrepareGame()
        {
            CreateDeck();
            var dealer = new Dealer(_deck, new BasicShuffler(new BasicRandomGenerator()));
        }
        
        private void CreateDeck()
        {
            _deck = new Card[52];
            for (var suit = 0; suit < 4; suit++)
            {
                for (var rank = 1; rank < 14; rank++)
                {
                    _deck[suit*13 + rank - 1] = new Card((Suit) suit, (Rank)rank);
                }
            }
        }

        private void AssignDealerToTable(Dealer dealer)
        {
            
        }
        
        
    }
}