using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BlackJack_Kata
{
    /**
     * <summary>Utility class for checking user input using regex expressions</summary>
     */
    public static class InputValidator
    {
        /**
         * <summary>This method checks the 0/1 input for staying/hitting respectively</summary>
         */
        public static bool CheckHitStayInput(string input)
        {
            var rx = new Regex("^\\s*[01]\\s*$");
            return (rx.IsMatch(input));
        }

        /**
         * <summary>This method checks Yes/No input
         * (case insensitive, leading and trailing whitespace allowed)</summary>
         */
        public static bool CheckYnInput(string input)
        {
            var rx = new Regex("^\\s*[ynYN]\\s*$");
            return (rx.IsMatch(input)); 
        }
    }
}