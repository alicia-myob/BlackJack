namespace BlackJack_Kata
{
    public class Player
    {
        private Hand _playerHand = new Hand();
        private int _handWorth = 0;
        public Player()
        {
            
        }

        public void ReceiveCard(Card card)
        {
            _playerHand.AddCard(card);
        }
    }
}