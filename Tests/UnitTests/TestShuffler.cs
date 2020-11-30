using BlackJack_Kata;
using Moq;
using Xunit;

namespace Tests.UnitTests
{
    public class TestShuffler
    {
        [Fact]
        public void ShuffleDeckDifferentToOriginalDeck()
        {
            //Arrange, Act and Assert
            BasicShuffler shuffler = new BasicShuffler(new BasicRandomGenerator());
            var deck = CreateDeck();
            var shuffledDeck = shuffler.Shuffle(deck);
            Assert.NotEqual(deck, shuffledDeck);
        }

        [Fact]
        public void ShufflerShouldShuffleCards()
        {
            var mock = Mock<IRandomGenerator>();
        }

        

        private Card[] CreateDeck()
        {
            Card[] deck = new Card[52];
            for (var suit = 0; suit < 4; suit++)
            {
                for (var rank = 1; rank < 14; rank++)
                {
                    deck[suit*13 + rank - 1] = new Card((Suit) suit, (Rank)rank);
                }
            }

            return deck;
        }
    }
}
