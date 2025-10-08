

namespace Crossword.Parser;

public sealed partial class CrosswordParser
{
    /// <summary>
    /// GetClues
    /// </summary>
    /// <param name="strData"></param>
    private void GetClues(IReadOnlyList<string> strData)
    {
        var puzzletempstr = strData[4];

        var cluetemp = puzzletempstr.Split("#");
        if (_crosswordData == null) return;
        _crosswordData.Clues = cluetemp.AsSpan(0, _crosswordData.NumQuestions).ToArray();
    }
}