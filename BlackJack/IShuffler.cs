namespace BlackJack_Kata
{
    /**
     * <summary>Interface for various shuffling algorithms</summary>
     */
    public interface IShuffler
    {
        Card[] Shuffle(Card[] deck);
    }
}