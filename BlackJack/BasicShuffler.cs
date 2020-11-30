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
            var shuffledDeck = new Card[52];
            var cardExists = new bool[52];

            for (var i = 0; i < 52; i++)
            {
                var cardPlace = 0;
                var foundPlace = false;
                while (!foundPlace)
                {
                    cardPlace = _generator.Generate(52);
                    if (!cardExists[cardPlace])
                    {
                        foundPlace = true;
                    }
                }

                cardExists[cardPlace] = true;
                try
                {
                    shuffledDeck[cardPlace] = deck[i];
                } catch (NullException){}
                
            }

            return shuffledDeck;
        }
    }
}