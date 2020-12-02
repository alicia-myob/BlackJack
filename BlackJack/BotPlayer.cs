namespace BlackJack_Kata
{
    /**
     * <summary>Class <c>BotPlayer is a type of player but with automated decision making
     * so it can play against the player</c></summary>
     */
    public class BotPlayer : Player
    {
        public BotPlayer(){}

        public bool DecisionMaker()
        {
            if (Score < 17)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}