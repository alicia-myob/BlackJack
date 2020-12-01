using System;
using Xunit.Sdk;

namespace BlackJack_Kata
{
    public class BasicShuffler: IShuffler
    {
        private IRandomGenerator _generator;
        public BasicShuffler(IRandomGenerator generator)
        {
            _generator = generator;
        }
        public Card[] Shuffle(Card[] deck)
        {
            for (var n = deck.Length - 1; n > 0; --n)
            {
                var rand = _generator.Generate(n + 1);
                var temp = deck[n];
                deck[n] = deck[rand];
                deck[rand] = temp;
            }

            return deck;
        }
    }
}