using System.Numerics;
using BlackJack_Kata;
using Xunit;

namespace Tests.UnitTests
{
    public class TestPlayer
    {
        [Fact]
        public void Test_Receive_Card()
        {
            var player = new Player();
            var card = new Card(Suit.Club, Rank.Ace);
            player.ReceiveCard(card);
            Assert.True(player.GetHand().Count > 0);
        }
        
        [Fact]
        public void Test_Receive_Card_Is_Card_Passed()
        {
            var player = new Player();
            var card = new Card(Suit.Club, Rank.Ace);
            player.ReceiveCard(card);
            var cardReceived = player.GetHand()[0];
            Assert.Equal(card, cardReceived);
        }
        
        
    }
}