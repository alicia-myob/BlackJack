using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack_Kata
{
    public class Table
    {
        private readonly List<Player> _playersAtTable = new List<Player>();
        private List<Card> _playerCards;
        private List<Card> _dealerCards;
        
        public Table()
        {
           _playerCards = new List<Card>();
           _dealerCards = new List<Card>();
        }

        public void AddPlayerToTable(Player player)
        {
            _playersAtTable.Add(player);
        }

        public void AnnounceScore(Player player, bool isPlayer)
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
            foreach (var card in player.GetHand())
            {
                if (card.Equals(player.GetHand().Last()))
                {
                    Console.Write(card.ToString() + "]\n");
                }
                else
                {
                    Console.Write(card.ToString() + ", ");
                }
            }
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
           
            var lastCard = player.GetHand().Last();
            Console.WriteLine(lastCard.ToString());
        }

        public void UpdateTable()
        {
            foreach (var player in _playersAtTable)
            {
                AnnounceScore(player, true);
            }
        }

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