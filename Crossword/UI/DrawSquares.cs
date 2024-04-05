using System;
using Crossword.Shared.Constants;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region DrawSquares

    /// <summary>
    /// Draws the crossword squares
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <returns></returns>
    private bool DrawSquares(int i, int j)
    {
        try
        {
            logger.LogInformation("Start DrawSquares()");

            //Check to see if a repaint is required
            if (!_sqPuzzleSquares[i, j]!.IsDirty) return true;
            if (_sqPuzzleSquares[i, j]!.BackColour.Equals(UiConstants.SquareHighlightNone))
            {
                if (_puzzleSquares is not null)
                    _spriteBatch.Draw(_imgNormalSquare, _puzzleSquares[i, j], _rectangleColor);
            }

            if (_sqPuzzleSquares[i, j]!.BackColour.Equals(UiConstants.SquareHighlightWord))
            {
                if (_puzzleSquares is not null)
                    _spriteBatch.Draw(_imgSquareWord, _puzzleSquares[i, j], _rectangleColor);
            }

            if (!_sqPuzzleSquares[i, j]!.BackColour.Equals(UiConstants.SquareHighlightCurrent)) return false;
            if (_puzzleSquares is not null)
                _spriteBatch.Draw(_imgHighliteSquare, _puzzleSquares[i, j], _rectangleColor);

            return false;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            throw;
        }
    }

    #endregion
}