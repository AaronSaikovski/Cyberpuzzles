

namespace Crossword.Parser;

public sealed partial class CrosswordParser
{
    /// <summary>
    /// GetColsAndRows
    /// </summary>
    /// <param name="strData"></param>
    private void GetColsAndRows(IReadOnlyList<string> strData)
    {
        var puzzleTempStr = strData[2];
        if (_crosswordData == null) return;
        _crosswordData.NumCols = int.Parse(puzzleTempStr[..2]);
        _crosswordData.NumRows = int.Parse(puzzleTempStr[2..]);
    }
}