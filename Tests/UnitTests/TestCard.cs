using BlackJack_Kata;
using Xunit;

namespace Tests.UnitTests
{
    public class TestCard
    {
        [Fact]
        public void CardToString()
        {
            var card = new Card(Suit.Club, Rank.Ace);
            var cardStr = card.ToString();
            Assert.Equal("[Ace, Club]", cardStr);
        }

        [Fact]
        public void GetOutOfRangeCard()
        {
            var deck = new Deck();
            Assert.Throws<System.ArgumentOutOfRangeException>(() => deck.GetCard(52));
        }

        [Fact]
        public void GetRank()
        {
            var card = new Card(Suit.Club, Rank.Ace);
            var cardRank = card.GetRank();
            Assert.Equal(Rank.Ace, cardRank);
        }

        [Fact]
        public void GetSuit()
        {
            var card = new Card(Suit.Club, Rank.Ace);
            var cardSuit = card.GetSuit();
            Assert.Equal(Suit.Club, cardSuit);
        }
        
        [Fact]
        public void SetAceToValueOne()
        {
            var card = new Card(Suit.Diamond, Rank.Ace);
            var valueOfAce = (int) card.GetRank();
            Assert.Equal(1, valueOfAce);
        }
        

    }
}