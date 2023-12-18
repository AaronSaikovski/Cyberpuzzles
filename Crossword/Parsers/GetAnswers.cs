using System.Collections.Generic;

namespace Crossword.Parsers;

public sealed partial class CrosswordParser
{
    #region 
    /// <summary>
    /// GetAnswers
    /// </summary>
    /// <param name="strData"></param>
    private void GetAnswers(IReadOnlyList<string> strData)
    {
        string[] answertemp;
        var puzzletempstr = strData[5];
        answertemp = puzzletempstr.Split("#");
        if (_crosswordData == null) return;
        _crosswordData.Answers = new string[_crosswordData.NumQuestions];
        for (var k = 0; k < _crosswordData.NumQuestions; k++)
        {
            _crosswordData.Answers[k] = answertemp[k];
        }
    }
    #endregion
}