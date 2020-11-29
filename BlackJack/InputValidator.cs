using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BlackJack_Kata
{
    public static class InputValidator
    {
        public static bool CheckHitStayInput(string input)
        {
            var rx = new Regex("^\\s*[01]\\s*$");
            return (rx.IsMatch(input));
        }
    }
}