using System.Collections.Generic;

namespace CyberPuzzles.Crossword.Parser;

public sealed partial class PuzzleData
{
    /// <summary>
    /// GetHintLetters
    /// </summary>
    /// <param name="strData"></param>
    private void GetHintLetters(IReadOnlyList<string> strData)
    {
        GetLetters = strData[6];
    }
}