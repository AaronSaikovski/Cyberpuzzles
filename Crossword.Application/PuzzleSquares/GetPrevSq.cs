namespace Crossword.PuzzleSquares;

public sealed partial class Square
{
    #region GetPrevSq

    /// <summary>
    /// /Gets the previous available square
    /// </summary>
    /// <param name="isAcross"></param>
    /// <returns></returns>
    public Square? GetPrevSq(bool isAcross)
    {
        if (isAcross)
            return ClueAnswerAcross != null ? ClueAnswerAcross.GetPrevSq(this) : this;
        return ClueAnswerDown != null ? ClueAnswerDown.GetPrevSq(this) : this;
    }

    #endregion
}