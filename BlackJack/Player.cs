using System;
using System.Collections.Generic;

namespace BlackJack_Kata
{
    /**
     * <summary>Class <c>Player</c> represents a player in the game. They can receive cards and have scores</summary>
     */
    public class Player
    {
        private readonly Hand _playerHand = new Hand();
        protected int Score = 0;
        public Player()
        {}

        public void ReceiveCard(Card card)
        {
            _playerHand.AddCard(card);
        }
        
        public void ReceiveScore(int playerScore)
        {
            Score = playerScore;
        }
        
        public int GetScore()
        {
            return Score;
        }

        public List<Card> GetHand()
        {
            return _playerHand.GetHand();
        }

        public bool PlayerScoreUnder21()
        {
            return Score < 21;
        }

        public bool PlayerScoreIs21()
        {
            return Score == 21;
        }
    }
}