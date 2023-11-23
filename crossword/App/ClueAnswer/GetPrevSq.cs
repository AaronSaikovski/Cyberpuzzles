using CyberPuzzles.Crossword.App.PuzzleSquares;

namespace CyberPuzzles.Crossword.App.ClueAnswer;

public sealed partial class ClueAnswerMap
{
    #region GetPrevSq

    /// <summary>
    /// Returns the previous square
    /// </summary>
    /// <param name="sq"></param>
    /// <returns></returns>
    public Square? GetPrevSq(Square? sq)
    {
        if (Answer == null) return sq;
        var i = Answer.Length - 1;
        while (i > -1)
        {
            if (sq == SqAnswerSquares?[i]) return i != 0 ? SqAnswerSquares?[i - 1] : sq;
            i--;
        }

        return sq;
    }

    #endregion
}