namespace Crossword.Puzzle.Squares;

public sealed partial class Square
{
    #region CreateSquare

    /// <summary>
    /// Allocates  memory for blank square
    /// </summary>
    /// <param name="xCoord"></param>
    /// <param name="yCoord"></param>
    public void CreateSquare(int xCoord, int yCoord)
    {
        this.XCoord = xCoord;
        this.YCoord = yCoord;
    }

    #endregion
}