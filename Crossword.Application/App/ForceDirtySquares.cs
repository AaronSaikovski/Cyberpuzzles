using System;
using System.Threading.Tasks;

namespace Crossword.App;

/// <summary>
/// Main Crossword App
/// </summary>
public sealed partial class CrosswordMain
{
    #region ForceDirtySquares

    /// <summary>
    /// Forces dirty squares
    /// </summary>
    private void ForceDirtySquares()
    {
        try
        {
            //Forces dirty squares
            Parallel.For(0, _NumRows, i =>
            {
                Parallel.For(0, _NumCols, j =>
                {
                    sqPuzzleSquares[i, j]!.IsDirty = true;
                });
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    #endregion
}