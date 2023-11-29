namespace CyberPuzzles.Crossword.App.PuzzleSquares;

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
        this.xCoord = xCoord;
        this.yCoord = yCoord;
    }

    #endregion
}