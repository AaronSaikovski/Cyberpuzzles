using CyberPuzzles.Crossword.App.PuzzleSquares;

namespace CyberPuzzles.Crossword.App.ClueAnswer;

public sealed partial class ClueAnswerMap
{
    #region GetSquare

    /// <summary>
    /// Gets the first square referenced by my answer.
    /// </summary>
    /// <returns></returns>
    public Square? GetSquare()
    {
        return SqAnswerSquares?[0];
    }

    #endregion
}