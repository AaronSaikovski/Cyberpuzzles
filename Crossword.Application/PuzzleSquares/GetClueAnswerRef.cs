using CyberPuzzles.Crossword.App.ClueAnswer;

namespace CyberPuzzles.Crossword.App.PuzzleSquares;

public sealed partial class Square
{
    #region GetClueAnswerRef

    /// <summary>
    /// returns the Clue/Answer reference
    /// </summary>
    /// <param name="isAcross"></param>
    /// <returns></returns>
    public ClueAnswerMap? GetClueAnswerRef(bool isAcross)
    {
        return isAcross ? ClueAnswerAcross : ClueAnswerDown;
    }

    #endregion
}