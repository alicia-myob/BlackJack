using System;

namespace BlackJack_Kata
{
    /**<summary>Class <c>GameMaster</c> controls the flow of the game</summary>
     * <para>GameMaster prepares game, instructs how the player plays, and then instructs how
     * the bot dealer plays the game.</para>
     */
    public class GameMaster
    {
        private Card[] _deck;
        private const int InitialNoOfCards = 2;
        public GameMaster()
        {
            PrepareGame();
        }

        /**<summary>Method PrepareGame creates an ordered deck, a dealer, a player, a bot player and instructs
         * the dealer to deal cards to the player</summary>
         */
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
        
        /**
         * <summary>Creating a standard deck of 52 playing cards, not shuffled</summary>
         */
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

        /**
         * Creates a table for the dealer and assigns it to them
         */
        private static void AssignDealerToTable(Dealer dealer)
        {
            var table = new Table();
            dealer.SetTable(table);
        }

        /**
         * <summary>GamePlay is the main flow of the game. It instructs what the dealer should do and
         * calls utility classes InputValidator and ValueCalculator to check at points in the game</summary>
         */
        private void GamePlay(Dealer dealer, Player player, BotPlayer bot)
        {
            var table = dealer.GetTable();
            
            //While player has not won or busted
            while (player.PlayerScoreUnder21())
            {
                var playerScore = ValueCalculator.HandWorth(player.GetHand()); //Get the player's current score
                player.ReceiveScore(playerScore);
                table.AnnounceScore(player, true); //Print to console
                
                if (player.PlayerScoreIs21())
                {
                    break;
                }

                if (player.PlayerScoreUnder21())
                {
                    var hitOrStay = dealer.AskHitOrStay();
                    if (hitOrStay == 1) // Hit = 1
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
                //If player chose to stay, then bot player must face the player
                DealerPlaysWithBotDealer(dealer, bot, player);
            }
            //Ask to reset the game at the end
            Program.ResetGame();
        }

        /**
         * <summary>Method DealerPlaysWithBotDealer uses the decision maker feature in BotPlayer to
         * control how the play goes. At the end, it compares the scores and declares a winner</summary>
         */
        private void DealerPlaysWithBotDealer(Dealer dealer, BotPlayer bot, Player player)
        {
            var table = dealer.GetTable(); //Play at the same table as the player
            var playerScore = ValueCalculator.HandWorth(bot.GetHand());
            bot.ReceiveScore(playerScore);
            table.AnnounceScore(bot, false);

            while (bot.DecisionMaker()) //While the bot is still under 17 
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

        /**
         * <summary>CompareScores compares the scores between the bot and the player
         * and declares a winner</summary>
         */
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