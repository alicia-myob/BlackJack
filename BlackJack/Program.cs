using System;

namespace BlackJack_Kata
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var deck = new Deck();
            deck.Shuffle();
            Console.WriteLine("Welcome to BlackJack!");
        }
        
    }
}