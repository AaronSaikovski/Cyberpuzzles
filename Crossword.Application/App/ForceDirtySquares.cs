using System.Threading.Tasks;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region ForceDirtySquares

    /// <summary>
    /// Forces dirty squares
    /// </summary>
    private void ForceDirtySquares()
    {
        //Forces dirty squares
        // for (var i = 0; i < _NumRows; i++)
        // {
        //     //down
        //     for (var j = 0; j < _NumCols; j++)
        //     {
        //         sqPuzzleSquares[i, j]!.IsDirty = true;
        //     }
        // }
        
        Parallel.For(0, _NumRows, i =>
        {
            Parallel.For(0, _NumCols, j =>
            {
                sqPuzzleSquares[i, j]!.IsDirty = true;
            });
        });
    }

    #endregion
}