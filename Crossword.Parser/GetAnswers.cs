namespace CyberPuzzles.Crossword.Parser;

public sealed partial class PuzzleData
{
    #region 
    /// <summary>
    /// GetAnswers
    /// </summary>
    /// <param name="strData"></param>
    private void GetAnswers(IReadOnlyList<string> strData)
    {
        string puzzletempstr;
        string[] answertemp;
        puzzletempstr = strData[5];
        answertemp = puzzletempstr.Split("#");
        Answers = new string[NumQuestions];
        for (var k = 0; k < NumQuestions; k++)
        {
            Answers[k] = answertemp[k];
        }
    }
    #endregion
}