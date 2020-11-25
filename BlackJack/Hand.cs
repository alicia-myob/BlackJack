using System;

namespace BlackJack_Kata
{
    public class Hand
    {
        private Deck _currentDeck;
        private bool[] _taken;
        private Random _cardGen;
        public Hand(Deck deck)
        {
            _currentDeck = deck;
            _taken = new bool[52];
            _cardGen = new Random();
        }

        public void InitialHand()
        {
            
        }
    }
}