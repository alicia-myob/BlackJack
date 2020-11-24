using System;

namespace BlackJack_Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();
            deck.Shuffle();
            for (int i = 0; i < 52; i++)
            {
                Card temp = deck.GetCard(i);
                Console.WriteLine(temp.ToString());
            }
        }
    }
}