namespace Crossword.Puzzle.Squares;

public sealed partial class Square
{
    #region CanFlipDirection

    /// <summary>
    /// Can the current orientation be flipped.
    /// </summary>
    /// <param name="isAcross"></param>
    /// <returns></returns>
    public bool CanFlipDirection(bool isAcross)
    {
        switch (isAcross)
        {
            //if square is an intersection
            case true when ClueAnswerDown is not null:
            case false when ClueAnswerAcross is not null:
                return true;
            default:
                return false;
        }
        
        //if square is an intersection
        // if ((isAcross) && (ClueAnswerDown != null))
        //     return true;
        // else if ((!isAcross) && (ClueAnswerAcross != null))
        //     return true;
        // else
        //     return false;
 
    }

    #endregion
}