using System;
using System.Linq;
using BlackJack_Kata;
using FluentAssertions;
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
            var shuffler = new BasicShuffler(new BasicRandomGenerator());
            var deck = CreateDeck();
            var shuffledDeck = shuffler.Shuffle(deck);
            Assert.NotEqual(deck, shuffledDeck);
        }

        [Fact]
        public void ShufflingIsConsistentWithMocking()
        {
            var mock = new Mock<IRandomGenerator>();
            mock.Setup(x => x.Generate(It.IsAny<int>())).Returns(12);
            var shuffler = new BasicShuffler(mock.Object);
            var deck1 = CreateDeck();
            var deck2 = CreateDeck();
            var shuffledDeck1 = shuffler.Shuffle(deck1);
            var shuffledDeck2 = shuffler.Shuffle(deck2);
            AssertingEqualityOnDecks(shuffledDeck1, shuffledDeck2);
        }

        private void AssertingEqualityOnDecks(Card[] deck1, Card[] deck2)
        {
            Assert.NotNull(deck1);  
            Assert.NotNull(deck2);
            Assert.Equal(deck1.Length, deck2.Length);
            for (var i = 0; i < deck1.Length; i++)
            {
                Assert.Equal(deck1[i].GetRank(), deck2[i].GetRank());
                Assert.Equal(deck1[i].GetSuit(), deck2[i].GetSuit());
            }
            
            
                      
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
