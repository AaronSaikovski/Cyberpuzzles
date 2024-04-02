namespace Crossword.Square;

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
        {
            return ClueAnswerAcross != null ? ClueAnswerAcross.GetNextSq(this) : this;
        }

        return ClueAnswerDown != null ? ClueAnswerDown.GetNextSq(this) : this;

    }

    #endregion
}