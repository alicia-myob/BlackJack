using System.Collections.Generic;
using BlackJack_Kata;
using Xunit;

namespace Tests.UnitTests
{
    public class TestValueCalculator
    {
        [Fact]
        public void Test_Card_Worth_With_Numeral_Card()
        {
            var card = new Card(Suit.Club, Rank.Two);
            var cardWorth = ValueCalculator.CardWorth(card);
            Assert.Equal(2,cardWorth);
        }
        
        [Fact]
        public void Test_Card_Worth_With_Picture_Card()
        {
            var card = new Card(Suit.Club, Rank.Queen);
            var cardWorth = ValueCalculator.CardWorth(card);
            Assert.Equal(10,cardWorth);
        }
        
        [Fact]
        public void Test_Default_Ace_Card_Worth()
        {
            var card = new Card(Suit.Club, Rank.Ace);
            var cardWorth = ValueCalculator.CardWorth(card);
            Assert.Equal(1,cardWorth);
        }

        [Fact]
        public void Test_Ace_Change_With_One_Ace_And_Too_Big_Hand_Value()
        {
            var handWorthAfterAceChange = ValueCalculator.AceChange(1, 12);
            Assert.Equal(12,handWorthAfterAceChange);
        }
        
        [Fact]
        public void Test_Ace_Change_With_One_Ace_And_Valid_Hand_Value()
        {
            var handWorthAfterAceChange = ValueCalculator.AceChange(1, 11);
            Assert.Equal(21,handWorthAfterAceChange);
        }
        
        [Fact]
        public void Test_Ace_Change_With_Two_Aces_And_Valid_Hand_Value()
        {
            var handWorthAfterAceChange = ValueCalculator.AceChange(2, 11);
            Assert.Equal(21,handWorthAfterAceChange);
        }
        
        [Fact]
        public void Test_Ace_Change_With_Two_Aces_In_Hand_Only()
        {
            var handWorthAfterAceChange = ValueCalculator.AceChange(2, 2);
            Assert.Equal(12,handWorthAfterAceChange);
        }

        [Fact]
        public void Test_HandWorth_Calculator_With_Empty_Hand()
        {
            var hand = new List<Card> { };
            Assert.Equal(0, ValueCalculator.HandWorth(hand));
        }
        
        [Fact]
        public void Test_HandWorth_Calculator_With_Hand_No_Ace_Change()
        {
            var hand = new List<Card> {new Card(Suit.Club, Rank.Eight), new Card(Suit.Diamond, Rank.Seven)};
            Assert.Equal(15, ValueCalculator.HandWorth(hand));
        }
        
        [Fact]
        public void Test_HandWorth_Calculator_With_Hand_And_Ace_Change()
        {
            var hand = new List<Card> {new Card(Suit.Club, Rank.Eight), new Card(Suit.Diamond, Rank.Ace)};
            Assert.Equal(19, ValueCalculator.HandWorth(hand));
        }
    }
}