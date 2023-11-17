
using System;
using System.Linq;

namespace CyberPuzzles.Crossword.Parsers
{
    public static class Helpers
    {
        
        #region CountOccurrences
        /// <summary>
        /// Counts the occurrences of a char in a word
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="targetChar"></param>
        /// <returns></returns>
        public static int CountOccurrences(string inputString, char targetChar)
         {
             if (inputString.Length <= 0) throw new ArgumentOutOfRangeException(nameof(inputString));
             if (targetChar <= 0) throw new ArgumentOutOfRangeException(nameof(targetChar));
             return inputString.Count(c => c == targetChar);
         }
        #endregion

    }
}