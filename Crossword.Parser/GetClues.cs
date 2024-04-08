

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
        //string[] cluetemp = puzzletempstr.Split("#");
        var cluetemp = puzzletempstr.Split("#");
        if (_crosswordData == null) return;
        _crosswordData.Clues = new string[_crosswordData.NumQuestions];
        for (var j = 0; j < _crosswordData.NumQuestions; j++)
        {
            _crosswordData.Clues[j] = cluetemp[j];
        }

        // string[] cluetemp;
        // var puzzletempstr = strData[4];
        // cluetemp = puzzletempstr.Split("#");
        // if (_crosswordData == null) return;
        // _crosswordData.Clues = new string[_crosswordData.NumQuestions];
        // for (var j = 0; j < _crosswordData.NumQuestions; j++)
        // {
        //     _crosswordData.Clues[j] = cluetemp[j];
        // }
    }
}