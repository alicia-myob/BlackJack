using System;
using System.Collections.Generic;

namespace BlackJack_Kata
{
    /**
     * <summary>Class <c>Program</c> initiates and starts the game when required, and is able to reset the game</summary>
     */
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
            var hasReplied = false;
            while (!hasReplied)
            {
                Console.Write("Would you like to reset your game? (y/n): ");
                var input = Console.ReadLine();
                if (InputValidator.CheckYnInput(input))
                {
                    hasReplied = true;
                    if (input != null && input.Trim().Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("\nNEW GAME");
                        StartGame();
                    }
                    else
                    {
                        Console.WriteLine("\nThanks for playing BlackJack!");
                    }
                }
                else
                {
                    Console.WriteLine("Please check your input!");
                }
            }
            
            
        }
        
    }
    
}