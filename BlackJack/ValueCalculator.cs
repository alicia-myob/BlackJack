using System;
using System.Collections.Generic;

namespace BlackJack_Kata
{
    /**
     * <summary>Class <c>ValueCalculator</c> works out the value of cards in a players hand</summary>
     * <remarks>This class handles the case of Ace which by default has a value of 1, but can be 11 if it
     * best fits the player's advantage.</remarks>
     */
    public static class ValueCalculator
    {

        /**
         * <summary>This method takes in a players hand, calculate the worth of the hand and returns it.</summary>
         * <param name="hand">List of cards representing the players hand</param>
         * <returns>An integer value representing the worth</returns>
         */
        public static int HandWorth(List<Card> hand)
        {
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
                        handWorthWithoutAceChange += value;
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
        
        /**
         * <summary>This method takes into account that if the card is Jack, Queen or King,
         * the value is 10</summary>
         */
        public static int CardWorth(Card card)
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
        public static int AceChange(int aceCount, int handWorthWithoutAceChange)
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
    }
}