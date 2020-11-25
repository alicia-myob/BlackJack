using System.Collections.Generic;

namespace BlackJack_Kata
{
    public class Table
    {
        private Queue<Card> _currentDeck;
        private Hand _playerHand;
        private Hand _dealerHand;
        public Table(Queue<Card> currentDeck)
        {
            _currentDeck = currentDeck;
            _playerHand = new Hand();
            _dealerHand = new Hand();
            DealInitialCards();
        }

        public void DealInitialCards()
        {
            //Deal player cards
            _playerHand.StoreCardInHand(_currentDeck.Dequeue());
            _playerHand.StoreCardInHand(_currentDeck.Dequeue());
            
            //Deal dealer cards
            _dealerHand.StoreCardInHand(_currentDeck.Dequeue());
            _dealerHand.StoreCardInHand(_currentDeck.Dequeue());
            
            _playerHand.ShowHand();
            _dealerHand.ShowHand();
        }
        
        
        
    }
}