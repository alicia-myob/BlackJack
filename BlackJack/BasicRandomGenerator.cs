using System;

namespace BlackJack_Kata
{
    public class BasicRandomGenerator: IRandomGenerator
    {
        private Random _random = new Random();
        public int Generate(int max)
        {
            return _random.Next(max);
        }
    }
}