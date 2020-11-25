using System;
using System.Collections.Generic;

namespace BlackJack_Kata
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var deck = new Deck();
            deck.Shuffle();
            Console.WriteLine("Welcome to BlackJack!");
            Program.StartGame(deck);
        }

        private static void StartGame(Deck deck)
        {
            var gameDeck = new Queue<Card>();
            foreach (var card in deck)
            {
                gameDeck.Enqueue(card);
            }
            var newTable = new Table(gameDeck);
        }
        
    }
    
}