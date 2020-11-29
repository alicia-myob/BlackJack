using System;
using System.Collections.Generic;

namespace BlackJack_Kata
{
    public static class ValueCalculator
    {

        public static int HandWorth(List<Card> hand)
        {
            var handWorth = 0;
            var handWorthWithoutAceChange = 0;
            var aceCount = 0;
            
            //Work out the total worth in hand without changing ace values (ace default value is 1)
            try
            {
                foreach (var card in hand)
                {
                    var value = ValueCalculator.CardWorth(card);
                    if (value == 1)
                    {
                        aceCount++;
                    }
                    else
                    {
                        handWorthWithoutAceChange += value;
                    }
                }
            } catch (NullReferenceException){}
            
            
            //If there is at least one ace, see if the worth of the ace(s) should change
            if (aceCount > 0)
            {
                handWorthWithoutAceChange = AceChange(aceCount, handWorthWithoutAceChange);
            }
            
            return handWorthWithoutAceChange;
        }
        
        private static int CardWorth(Card card)
        {
            if (IsPictureCard(card.GetRank()))
            {
                return 10;
            } 
            else
            {
                return (int) (card.GetRank());
            }
        }
        
        //Changing ace value depending on current hand
        private static int AceChange(int aceCount, int handWorthWithoutAceChange)
        {
            if (21 - handWorthWithoutAceChange >= 10) 
            {
                var handWorthWithAceChange = handWorthWithoutAceChange - 1 + 11;
                return handWorthWithAceChange;
            }
            
            return handWorthWithoutAceChange;
        }

        //Checking if picture card
        private static bool IsPictureCard(Rank rank)
        {
            return ((rank >= Rank.Jack) && (rank <= Rank.King));
        }

        private static bool IsAce(Rank rank)
        {
            return rank >= Rank.Ace;
        }
    }
}