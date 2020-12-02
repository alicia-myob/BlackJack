using BlackJack_Kata;
using Xunit;

namespace Tests.UnitTests
{
    public class TestValueCalculator
    {
        [Fact]
        public void TestCardWorthWithNumeralCard()
        {
            var card = new Card(Suit.Club, Rank.Two);
            var cardWorth = ValueCalculator.CardWorth(card);
            Assert.Equal(2,cardWorth);
        }
        
        [Fact]
        public void TestCardWorthWithPictureCard()
        {
            var card = new Card(Suit.Club, Rank.Queen);
            var cardWorth = ValueCalculator.CardWorth(card);
            Assert.Equal(10,cardWorth);
        }
        
        [Fact]
        public void TestDefaultAceCardWorth()
        {
            var card = new Card(Suit.Club, Rank.Ace);
            var cardWorth = ValueCalculator.CardWorth(card);
            Assert.Equal(1,cardWorth);
        }
    }
}