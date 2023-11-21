using System.Collections.Generic;

namespace CyberPuzzles.Crossword.Parser;

public sealed partial class CrosswordParser
{
    private void GetPuzzleIdAndType(IReadOnlyList<string> strData)
    {
        var puzzletempstr = strData[1];
        PuzzleId = int.Parse(puzzletempstr[2..]);
        PuzzleType = puzzletempstr[..2];
    }
}