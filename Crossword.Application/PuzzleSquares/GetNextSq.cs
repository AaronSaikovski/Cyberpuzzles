namespace Crossword.PuzzleSquares;

public sealed partial class Square
{
    #region GetNextSq

    /// <summary>
    /// Gets the next available square
    /// </summary>
    /// <param name="isAcross"></param>
    /// <returns></returns>
    public Square? GetNextSq(bool isAcross)
    {
        if (isAcross)
            return ClueAnswerAcross is not null ? ClueAnswerAcross.GetNextSq(this) : this;
        return ClueAnswerDown is not null ? ClueAnswerDown.GetNextSq(this) : this;
    }

    #endregion
}