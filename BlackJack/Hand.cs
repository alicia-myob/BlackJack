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

        public void StoreCardInHand(Card card)
        {
            _hand.Add(card);
        }

        public void CalculateWorth()
        {
            
        }
    }
}