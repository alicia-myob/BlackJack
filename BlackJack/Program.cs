using System;
using System.Collections.Generic;

namespace BlackJack_Kata
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome to BlackJack!");
            StartGame();
        }

        private static void StartGame()
        {
            var gameMaster = new GameMaster();
        }

        public static void ResetGame()
        {
            Console.Write("Would you like to reset your game? (y/n): ");
            string input = Console.ReadLine();
            if (InputValidator.CheckYnInput(input))
            {
                
                Console.WriteLine("\nNEW GAME");
                StartGame();
            }
            else
            {
                Console.WriteLine("\nThanks for playing BlackJack!");
            }
        }
        
    }
    
}