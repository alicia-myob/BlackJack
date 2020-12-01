using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack_Kata
{
    /**
     * <summary>Class <c>Table</c> represents a BlackJack table which a dealer is assigned to and players can sit
     * at it. It is also for announcing scores and results</summary>
     */
    public class Table
    {
        private readonly List<Player> _playersAtTable = new List<Player>();

        public Table()
        {}

        public void AddPlayerToTable(Player player)
        {
            _playersAtTable.Add(player);
        }

        /**
         * <summary>This method announces the score of the player's hand and the </summary>
         */
        public static void AnnounceScore(Player player, bool isPlayer)
        {
            if (isPlayer)
            {
                Console.WriteLine("\nYou are at currently at " + player.GetScore());
            }
            else
            {
                Console.WriteLine("\nDealer is at: " + player.GetScore());
            }
            
            Console.Write("with the hand [");
            Hand.ShowHand(player);
        }

        public void AnnounceDrawnCard(Player player, bool isPlayer)
        {
            if (isPlayer)
            {
                Console.Write("\nYou draw ");
            }
            else
            {
                Console.Write("\nDealer draws ");
            }
            
            Console.WriteLine(player.GetHand().Last().ToString());
        }

        public void UpdateTable()
        {
            foreach (var player in _playersAtTable)
            {
                AnnounceScore(player, true);
            }
        }

        //Result messages
        
        public void Congratulations()
        {
            Console.WriteLine("\nYou beat the dealer!");
        }
        public void CongratulationsBlackJack()
        {
            Console.WriteLine("\nThat's BlackJack! Congratulations :D");
        }

        public void Busted()
        {
            Console.WriteLine("\nBusted! Take risks but don't be greedy ;)");
        }

        public void DealerWins()
        {
            Console.WriteLine("\nDealer wins :( ");
        }
        
        public void DealerBusted()
        {
            Console.WriteLine("\nDealer busted! You win :) ");
        }

        public void AnnounceTie()
        {
            Console.WriteLine("\nIt's a tie!");
        }
    }
}