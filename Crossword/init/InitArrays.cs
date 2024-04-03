using System;
using Crossword.Puzzle.Squares;
using Crossword.Shared.Constants;

namespace Crossword.App;

public sealed partial class CrosswordMain
{
    #region InitArrays

    /// <summary>
    /// Inits the arrays and objects
    /// </summary>
    private void InitArrays()
    {
        try
        {
            logger.LogInformation("Start InitArrays()");
            
            //loop over rows
            for (var i = 0; i < _NumRows; i++)
            {
                //loop over columns
                for (var j = 0; j < _NumCols; j++)
                {
                    if (sqPuzzleSquares is null) continue;
                    sqPuzzleSquares[i, j] = new Square();

                    //Set SQs to dirty
                    if (NewBackFlush || InitCrossword)
                    {
                        sqPuzzleSquares[i, j]!.IsDirty = true;
                    }

                    //Create squares
                    sqPuzzleSquares[i, j]
                        ?.CreateSquare(nCrossOffsetX + i * UIConstants.SquareWidth,
                            nCrossOffsetY + j * UIConstants.SquareHeight);
                }
            }
        
        }
        catch (Exception ex)
        {
            logger.LogError(ex,ex.Message);
            throw;
        }
    }

    #endregion
}