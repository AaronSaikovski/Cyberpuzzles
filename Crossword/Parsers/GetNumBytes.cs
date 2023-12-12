using System.Collections.Generic;

namespace Crossword.Parsers;

public sealed partial class CrosswordParser
{
    /// <summary>
    /// GetNumBytes
    /// </summary>
    /// <param name="strData"></param>
    private void GetNumBytes(IReadOnlyList<string> strData)
    {
        _crosswordData.NumBytes = int.Parse(strData[0]);
    }
}