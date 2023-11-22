using System.Collections.Generic;

namespace CyberPuzzles.Crossword.Parser;

public sealed partial class PuzzleData
{
    /// <summary>
    /// GetBlurb
    /// </summary>
    /// <param name="strData"></param>
    private void GetBlurb(IReadOnlyList<string> strData)
    {
        Blurb = strData[8];
    }
}