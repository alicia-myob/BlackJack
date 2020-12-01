namespace BlackJack_Kata
{
    public class GameMaster
    {
        private Card[] _deck;
        private const int InitialNoOfCards = 2;
        public GameMaster()
        {
            PrepareGame();
        }

        private void PrepareGame()
        {
            CreateDeck();
            var dealer = new Dealer(_deck, new BasicShuffler(new BasicRandomGenerator()));
            AssignDealerToTable(dealer);
            var player = new Player();
            dealer.DealCardToPlayer(player, InitialNoOfCards);
            GamePlay(dealer,player);
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

        private static void AssignDealerToTable(Dealer dealer)
        {
            var table = new Table();
            dealer.SetTable(table);
        }

        private static void GamePlay(Dealer dealer, Player player)
        {
            var table = dealer.GetTable();
            while (player.PlayerScoreUnder21())
            {
                var playerScore = ValueCalculator.HandWorth(player.GetHand());
                player.ReceiveScore(playerScore);
                table.AnnounceScore(player);
                
                if (player.PlayerScoreIs21())
                {
                    break;
                }

                var hitOrStay = dealer.AskHitOrStay();
                if (hitOrStay == 1)
                {
                    dealer.DealCardToPlayer(player, 1);
                    table.AnnounceDrawnCard(player);
                }
                else
                {
                    break;
                }
            }

            if (player.PlayerScoreIs21())
            {
                table.Congratulations();
            } else if (!player.PlayerScoreUnder21())
            {
                table.Busted();
            }
            else
            {
                
            }

        }
        
    }
}