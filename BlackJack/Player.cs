using System;
using System.Collections.Generic;

namespace BlackJack_Kata
{
    public class Player
    {
        private Hand _playerHand = new Hand();
        private int _score = 0;
        public Player()
        {}

        public void ReceiveCard(Card card)
        {
            _playerHand.AddCard(card);
        }
        
        public void ReceiveScore(int playerScore)
        {
            _score = playerScore;
        }
        
        public int PassScore()
        {
            return _score;
        }

        public List<Card> GetHand()
        {
            return _playerHand.GetHand();
        }

        public bool PlayerScoreUnder21()
        {
            return _score < 21;
        }

        public bool PlayerScoreIs21()
        {
            return _score == 21;
        }

        
        
        
    }
}