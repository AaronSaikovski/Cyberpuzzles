using System.Collections.Generic;

namespace Crossword.Parsers;

public sealed partial class CrosswordParser
{
    /// <summary>
    /// GetClues
    /// </summary>
    /// <param name="strData"></param>
    private void GetClues(IReadOnlyList<string> strData)
    {
        string[] cluetemp;
        var puzzletempstr = strData[4];
        cluetemp = puzzletempstr.Split("#");
        if (_crosswordData == null) return;
        _crosswordData.Clues = new string[_crosswordData.NumQuestions];
        for (var j = 0; j < _crosswordData.NumQuestions; j++)
        {
            _crosswordData.Clues[j] = cluetemp[j];
        }
    }
}