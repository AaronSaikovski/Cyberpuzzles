namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region ForceDirtySquares

    /// <summary>
    /// Forces dirty squares
    /// </summary>
    private void ForceDirtySquares()
    {
        //Forces dirty squares
        for (var i = 0; i < _NumRows; i++)
        {
            //down
            for (var j = 0; j < _NumCols; j++)
            {
                sqPuzzleSquares[i, j]!.IsDirty = true;
            }
        }
    }

    #endregion
}