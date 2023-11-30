namespace Crossword.PuzzleSquares;

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
            case true when ClueAnswerDown != null:
            case false when ClueAnswerAcross != null:
                return true;
            default:
                return false;
        }
    }

    #endregion
}