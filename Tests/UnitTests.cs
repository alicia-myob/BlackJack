using System;
using BlackJack_Kata;
using Xunit;
using Xunit.Sdk;

namespace Tests
{
    public class UnitTests
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
        
        

    }
}