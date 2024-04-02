using System;
using System.Threading.Tasks;

namespace Crossword.App;

/// <summary>
/// Main Crossword App
/// </summary>
public sealed partial class CrosswordMain
{
    #region InitDirtySquares

    /// <summary>
    /// Forces dirty squares
    /// </summary>
    private void InitDirtySquares()
    {
        try
        {
<<<<<<< HEAD
            logger.LogInformation("Start ForceDirtySquares()");
            
            //Forces dirty squares
            Parallel.For(0, _NumRows, i =>
=======
            //_logger.LogInformation("Start ForceDirtySquares()");

            for (var i = 0; i < _NumRows; i++)
>>>>>>> main
            {
                for (var j = 0; j < _NumCols; j++)
                {
                    sqPuzzleSquares[i, j]!.IsDirty = true;
                }
            }

            //Forces dirty squares
            // Parallel.For(0, _NumRows, i =>
            // {
            //     Parallel.For(0, _NumCols, j =>
            //     {
            //         sqPuzzleSquares[i, j]!.IsDirty = true;
            //     });
            // });
        }
        catch (Exception ex)
        {
            logger.LogError(ex,ex.Message);
            throw;
        }
        
    }

    #endregion
}