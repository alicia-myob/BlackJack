using System;
using System.Collections.Generic;

namespace BlackJack_Kata
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to BlackJack!");
            Program blackjackGame = new Program();
            
            blackjackGame.StartGame();
        }

        public void StartGame()
        { 
            var dealer = new Dealer();
            var player = new Player();
            dealer.prepareGame();
        }
    }
    
}