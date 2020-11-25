using System.Collections.Generic;

namespace BlackJack_Kata
{
    public class Table
    {
        private Queue<Card> _currentDeck;
        private PlayerHand _playerHand;
        private DealerHand _dealerHand;
        public Table(Queue<Card> currentDeck)
        {
            _currentDeck = currentDeck;
            _playerHand = new PlayerHand();
            _dealerHand = new DealerHand();
        }
        
    }
}