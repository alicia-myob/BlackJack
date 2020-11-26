using System;
using System.Collections.Generic;

namespace BlackJack_Kata
{
    public class Hand
    {
        private List<Card> _hand = new List<Card>();
        private int _worth;
        public Hand()
        {
            _worth = 0;
        }

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
    }
}