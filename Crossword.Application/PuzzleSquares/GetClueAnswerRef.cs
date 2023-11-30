using Crossword.ClueAnswer;

namespace Crossword.PuzzleSquares;

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