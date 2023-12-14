using System.Collections.Generic;

namespace Crossword.Parsers;

public sealed partial class CrosswordParser
{
    /// <summary>
    /// GetBlurb
    /// </summary>
    /// <param name="strData"></param>
    private void GetBlurb(IReadOnlyList<string> strData)
    {
        if (_crosswordData != null) _crosswordData.Blurb = strData[8];
    }
}