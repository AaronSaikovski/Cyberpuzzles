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
            _logger.LogInformation("Start ForceDirtySquares()");
            
            //Forces dirty squares
            Parallel.For(0, _NumRows, i =>
            {
                Parallel.For(0, _NumCols, j =>
                {
                    sqPuzzleSquares[i, j]!.IsDirty = true;
                });
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
            throw;
        }
        
    }

    #endregion
}