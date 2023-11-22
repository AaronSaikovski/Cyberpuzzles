using System.Collections.Generic;

namespace CyberPuzzles.Crossword.Parser;

public sealed partial class PuzzleData
{
    /// <summary>
    /// GetPuzzleIdAndType
    /// </summary>
    /// <param name="strData"></param>
    private void GetPuzzleIdAndType(IReadOnlyList<string> strData)
    {
        var puzzletempstr = strData[1];
        PuzzleId = int.Parse(puzzletempstr[2..]);
        PuzzleType = puzzletempstr[..2];
    }
}