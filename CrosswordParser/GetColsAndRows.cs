using System.Collections.Generic;

namespace CyberPuzzles.Crossword.Parser;

public sealed partial class CrosswordParser
{
    private void GetColsAndRows(IReadOnlyList<string> strData)
    {
        var puzzleTempStr=  strData[2];
        NumCols = int.Parse(puzzleTempStr[..2]);
        NumRows = int.Parse(puzzleTempStr[2..]);
    }
}