using CyberPuzzles.Crossword.App.PuzzleSquares;

namespace CyberPuzzles.Crossword.App.ClueAnswer;

public sealed partial class ClueAnswerMap
{
    #region GetNextSq

    /// <summary>
    /// Returns the next square
    /// </summary>
    /// <param name="sq"></param>
    /// <returns></returns>
    public Square? GetNextSq(Square? sq)
    {
        var i = 0;
        while (Answer != null && i < Answer.Length)
        {
            if (SqAnswerSquares != null && sq == SqAnswerSquares?[i])
                if (i < Answer.Length - 1)
                    return SqAnswerSquares?[i + 1];
            i++;
        }

        return sq;
    }

    #endregion
}