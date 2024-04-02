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
        {
            return ClueAnswerAcross != null ? ClueAnswerAcross.GetNextSq(this) : this;
        }

        return ClueAnswerDown != null ? ClueAnswerDown.GetNextSq(this) : this;


        // if (isAcross)
        // {
        //     if(ClueAnswerAcross != null)
        //         return ClueAnswerAcross.GetNextSq(this);
        //     else
        //         return this;
        // }
        // else
        // {
        //     if(ClueAnswerDown != null)
        //         return ClueAnswerDown.GetNextSq(this);
        //     else
        //         return this;
        // }

    }

    #endregion
}