using System;
using Crossword.Puzzle.Squares;
using Crossword.Shared.Constants;
using System.Threading.Tasks;

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


            Parallel.For(0, _NumRows, i =>
            {
                Parallel.For(0, _NumCols, j =>
                {
                    if (_sqPuzzleSquares != null)
                    {
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
                });
            });

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }

    #endregion
}