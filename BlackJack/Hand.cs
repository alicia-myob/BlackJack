using System;
using System.Collections.Generic;

namespace BlackJack_Kata
{
    public class Hand
    {
        private List<Card> _hand = new List<Card>();
        
        public Hand()
        {}

        public void AddCard(Card card)
        {
            _hand.Add(card);
        }

        public void ShowHand()
        {
            foreach (var card in _hand)
            {
                Console.WriteLine(card.ToString());
            }
        }

        public List<Card> GetHand()
        {
            return _hand;
        }
    }
}