using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack_Kata
{
    public class Table
    {
        private List<Player> _playersAtTable = new List<Player>();
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

        public void AnnounceScore(Player player)
        {
            Console.WriteLine("\nYou are at currently at " + player.PassScore());
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

        public void AnnounceDrawnCard(Player player)
        {
            Console.Write("You draw ");
            var lastCard = player.GetHand().Last();
            Console.WriteLine(lastCard.ToString());
        }

        public void UpdateTable()
        {
            foreach (var player in _playersAtTable)
            {
                AnnounceScore(player);
            }
        }

        public void Congratulations()
        {
            Console.WriteLine("That's BlackJack! Congratulations :D");
        }

        public void Busted()
        {
            Console.WriteLine("Busted! Take risks but don't be greedy ;)");
        }
        

        
        
        

        
        
        
        
    }
}