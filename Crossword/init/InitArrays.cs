using System;
using Crossword.Puzzle.Squares;
using Crossword.Shared.Constants;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region InitArrays

    /// <summary>
    /// Inits the arrays and objects
    /// </summary>
    private void InitArrays()
    {
        try
        {
            _logger.LogInformation("Start InitArrays()");

            if (_sqPuzzleSquares is null)
                return;

            // Use regular loops instead of nested Parallel.For
            // Parallel.For adds overhead for small arrays (typically 9x9 grids)
            for (var i = 0; i < _NumRows; i++)
            {
                for (var j = 0; j < _NumCols; j++)
                {
                    _sqPuzzleSquares[i, j] = new Square();

                    //Set SQs to dirty
                    if (_newBackFlush || _initCrossword)
                    {
                        _sqPuzzleSquares[i, j].IsDirty = true;
                    }

                    //Create squares
                    _sqPuzzleSquares[i, j].CreateSquare(
                        _nCrossOffsetX + i * UiConstants.SquareWidth,
                        _nCrossOffsetY + j * UiConstants.SquareHeight);
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