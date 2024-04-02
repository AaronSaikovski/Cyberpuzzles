using System.Collections.Generic;

namespace Crossword.Parsers;

public sealed partial class CrosswordParser
{
    /// <summary>
    /// GetPuzzleIdAndType
    /// </summary>
    /// <param name="strData"></param>
    private void GetPuzzleIdAndType(IReadOnlyList<string> strData)
    {
        var puzzletempstr = strData[1];
        if (_crosswordData == null) return;
        _crosswordData.PuzzleId = int.Parse(puzzletempstr[2..]);
        _crosswordData.PuzzleType = puzzletempstr[..2];
    }
}