using System;

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
            _logger.LogInformation("Start ForceDirtySquares()");

            if (_sqPuzzleSquares is null)
                return;

            // Use regular loops instead of nested Parallel.For
            // Parallel.For adds overhead for small arrays (typically 9x9 grids)
            for (var i = 0; i < _NumRows; i++)
            {
                for (var j = 0; j < _NumCols; j++)
                {
                    _sqPuzzleSquares[i, j].IsDirty = true;
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }

    }

    #endregion
}