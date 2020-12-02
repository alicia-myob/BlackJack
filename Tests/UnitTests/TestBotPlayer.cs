using BlackJack_Kata;
using Xunit;

namespace Tests.UnitTests
{
    public class TestBotPlayer
    {
        [Fact]
        public void TestBotPlayerDecisionWithScore17()
        {
            var bot = new BotPlayer();
            bot.ReceiveScore(17);
            Assert.False(bot.DecisionMaker());
        }

        [Fact]
        public void TestBotPlayerDecisionWithScore16()
        {
            var bot = new BotPlayer();
            bot.ReceiveScore(16);
            Assert.True(bot.DecisionMaker());
        }
    }
}