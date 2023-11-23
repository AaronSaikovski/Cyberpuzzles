namespace CyberPuzzles.Crossword.App.ClueAnswer;

public sealed partial class ClueAnswerMap
{
    #region CheckWord

    /// <summary>
    /// Sets the letter colour if Check words is pressed.
    /// </summary>
    public void CheckWord()
    {
        if (Answer == null) return;
        for (var i = 0; i < Answer.Length; i++)
        {
            SqAnswerSquares?[i]?.CheckLetter(Answer[i]);
        }
    }

    #endregion
}