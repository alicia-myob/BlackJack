using System;
using System.Collections.Generic;

namespace BlackJack_Kata
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to BlackJack!");
            var blackjackGame = new Program();
            
            StartGame();
        }

        private static void StartGame()
        {
            var gameMaster = new GameMaster();
        }
    }
    
}