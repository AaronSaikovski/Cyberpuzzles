

namespace Crossword.Puzzle.ClueAnswerMap;

public sealed partial class ClueAnswer
{
    #region CheckWord

    /// <summary>
    /// Sets the letter colour if Check words is pressed.
    /// </summary>
    public void CheckWord()
    {
        if (Answer is null || SqAnswerSquares is null)
            return;

        // Use regular loop instead of Parallel.For (answer length is typically small)
        for (var i = 0; i < Answer.Length; i++)
        {
            SqAnswerSquares[i]?.CheckLetter(Answer[i]);
        }
    }

    #endregion
}