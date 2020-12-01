namespace BlackJack_Kata
{
    public class BotPlayer : Player
    {
        public BotPlayer(){}

        public bool DecisionMaker()
        {
            if (_score < 17)
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