using System;

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
            var bot = new BotPlayer();
            dealer.DealCardToPlayer(bot, InitialNoOfCards);
            GamePlay(dealer,player, bot);
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

        private void GamePlay(Dealer dealer, Player player, BotPlayer bot)
        {
            var table = dealer.GetTable();
            while (player.PlayerScoreUnder21())
            {
                var playerScore = ValueCalculator.HandWorth(player.GetHand());
                player.ReceiveScore(playerScore);
                table.AnnounceScore(player, true);
                
                if (player.PlayerScoreIs21())
                {
                    break;
                }

                if (player.PlayerScoreUnder21())
                {
                    var hitOrStay = dealer.AskHitOrStay();
                    if (hitOrStay == 1)
                    {
                        dealer.DealCardToPlayer(player, 1);
                        table.AnnounceDrawnCard(player, true);
                    }
                    else
                    {
                        break;
                    } 
                }
            }

            if (player.PlayerScoreIs21())
            {
                table.CongratulationsBlackJack();
            } else if (!player.PlayerScoreUnder21())
            {
                table.Busted();
            }
            else
            {
                DealerPlaysWithBotDealer(dealer, bot, player);
            }
            
            Program.ResetGame();
        }

        private void DealerPlaysWithBotDealer(Dealer dealer, BotPlayer bot, Player player)
        {
            var table = dealer.GetTable();
            var playerScore = ValueCalculator.HandWorth(bot.GetHand());
            bot.ReceiveScore(playerScore);
            table.AnnounceScore(bot, false);

            while (bot.DecisionMaker())
            {
                dealer.DealCardToPlayer(bot, 1);
                playerScore = ValueCalculator.HandWorth(bot.GetHand());
                bot.ReceiveScore(playerScore);
                table.AnnounceDrawnCard(bot, false);
            }

            if (bot.PlayerScoreIs21())
            {
                table.DealerWins();
            }
            else if (!bot.PlayerScoreUnder21())
            {
                table.DealerBusted();
                table.Congratulations();
            }
            else
            {
                CompareScores(bot, player);
            }
            
        }

        private static void CompareScores(Player bot, Player player)
        {
            var table = new Table();
            if (bot.GetScore() > player.GetScore())
            {
                
                table.DealerWins();
            } else if (bot.GetScore() == player.GetScore())
            {
                table.AnnounceTie();
            }
                
        }
        
    }
}