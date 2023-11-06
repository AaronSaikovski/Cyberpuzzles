using System.Collections.Generic;

namespace CyberPuzzles.Crossword.Parser;

public sealed partial class CrosswordParser
{
    private void GetColsAndRows(IReadOnlyList<string> strData)
    {
        var PuzzleTempStr=  strData[2];
        NumCols = int.Parse(PuzzleTempStr[..2]);
        NumRows = int.Parse(PuzzleTempStr[2..]);
    }
}