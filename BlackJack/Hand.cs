using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack_Kata
{
    public class Hand
    {
        private readonly List<Card> _hand = new List<Card>();
        
        public Hand()
        {}

        public void AddCard(Card card)
        {
            _hand.Add(card);
        }

        public static void ShowHand(Player player)
        {
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

        public List<Card> GetHand()
        {
            return _hand;
        }
    }
}