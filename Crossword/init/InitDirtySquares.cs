using System;
using System.Threading.Tasks;

namespace Crossword.App;

/// <summary>
/// Main Crossword App
/// </summary>
public sealed partial class CrosswordApp
{
    #region InitDirtySquares

    /// <summary>
    /// Forces dirty squares
    /// </summary>
    private void InitDirtySquares()
    {
        try
        {
            logger.LogInformation("Start ForceDirtySquares()");

            //Forces dirty squares
            Parallel.For(0, _NumRows, i =>
            {
                Parallel.For(0, _NumCols, j =>
                {
                    _sqPuzzleSquares[i, j]!.IsDirty = true;
                });
            });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            throw;
        }

    }

    #endregion
}