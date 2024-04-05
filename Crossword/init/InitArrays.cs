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

            //loop over rows
            for (var i = 0; i < _NumRows; i++)
            {
                //loop over columns
                for (var j = 0; j < _NumCols; j++)
                {
                    if (_sqPuzzleSquares is null) continue;
                    _sqPuzzleSquares[i, j] = new Square();

                    //Set SQs to dirty
                    if (_newBackFlush || _initCrossword)
                    {
                        _sqPuzzleSquares[i, j]!.IsDirty = true;
                    }

                    //Create squares
                    _sqPuzzleSquares[i, j]
                        ?.CreateSquare(_nCrossOffsetX + i * UiConstants.SquareWidth,
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