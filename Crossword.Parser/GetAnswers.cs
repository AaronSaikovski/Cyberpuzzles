

namespace Crossword.Parser;

public sealed partial class CrosswordParser
{
    #region 
    /// <summary>
    /// GetAnswers
    /// </summary>
    /// <param name="strData"></param>
    private void GetAnswers(IReadOnlyList<string> strData)
    {
        var puzzletempstr = strData[5];
        var answertemp = puzzletempstr.Split("#");
        if (_crosswordData == null) return;
        _crosswordData.Answers = answertemp.AsSpan(0, _crosswordData.NumQuestions).ToArray();
    }
    #endregion
}