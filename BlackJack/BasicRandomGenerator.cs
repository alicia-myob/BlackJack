using System;

namespace BlackJack_Kata
{
    /**
     * <summary>Class <c>BasicRandomGenerator</c> uses the Random API to generate
     * random values given a max bound</summary>
     */
    public class BasicRandomGenerator: IRandomGenerator
    {
        private Random _random = new Random();
        public int Generate(int max)
        {
            return _random.Next(0,max);
        }
    }
}