using System.Collections.Generic;

namespace Crossword.Parsers;

public sealed partial class CrosswordParser
{
    /// <summary>
    /// GetHintLetters
    /// </summary>
    /// <param name="strData"></param>
    private void GetHintLetters(IReadOnlyList<string> strData)
    {
        _crosswordData.GetLetters = strData[6];
    }
}