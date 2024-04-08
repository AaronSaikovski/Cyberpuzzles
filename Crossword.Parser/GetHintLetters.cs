

namespace Crossword.Parser;

public sealed partial class CrosswordParser
{
    /// <summary>
    /// GetHintLetters
    /// </summary>
    /// <param name="strData"></param>
    private void GetHintLetters(IReadOnlyList<string> strData)
    {
        if (_crosswordData != null) _crosswordData.GetLetters = strData[6];
    }
}