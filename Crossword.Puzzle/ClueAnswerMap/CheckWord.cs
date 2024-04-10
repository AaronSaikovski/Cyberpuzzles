

namespace Crossword.Puzzle.ClueAnswerMap;

public sealed partial class ClueAnswer
{
    #region CheckWord

    /// <summary>
    /// Sets the letter colour if Check words is pressed.
    /// </summary>
    public void CheckWord()
    {
        if (Answer is null) return;

        Parallel.For(0, Answer.Length, i =>
        {
            SqAnswerSquares?[i]?.CheckLetter(Answer[i]);
        });
    }

    #endregion
}