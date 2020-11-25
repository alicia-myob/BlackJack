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
            var deck = new Deck();
            deck.Shuffle();
            blackjackGame.StartGame(deck);
        }

        public void StartGame(Deck deck)
        {
            var gameDeck = new Queue<Card>();
            var currentDeck = deck.GetDeck();
            foreach (var card in currentDeck)
            {
                gameDeck.Enqueue(card);
            }
            var newTable = new Table(gameDeck);
        }
        
    }
    
}