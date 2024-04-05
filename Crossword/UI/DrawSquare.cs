

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
    // private bool DrawSquare(int i, int j)
    // {
    //     try
    //     {
    //         _logger.LogInformation("Start DrawSquares()");
    //
    //         //Check to see if a repaint is required
    //         if (!_sqPuzzleSquares[i, j]!.IsDirty) return true;
    //         if (_sqPuzzleSquares[i, j]!.BackColour.Equals(UiConstants.SquareHighlightNone))
    //         {
    //             if (_puzzleSquares is not null)
    //                 _spriteBatch.Draw(_imgNormalSquare, _puzzleSquares[i, j], _rectangleColor);
    //         }
    //
    //         if (_sqPuzzleSquares[i, j]!.BackColour.Equals(UiConstants.SquareHighlightWord))
    //         {
    //             if (_puzzleSquares is not null)
    //                 _spriteBatch.Draw(_imgSquareWord, _puzzleSquares[i, j], _rectangleColor);
    //         }
    //
    //         if (!_sqPuzzleSquares[i, j]!.BackColour.Equals(UiConstants.SquareHighlightCurrent)) return false;
    //         if (_puzzleSquares is not null)
    //             _spriteBatch.Draw(_imgHighliteSquare, _puzzleSquares[i, j], _rectangleColor);
    //
    //         return false;
    //     }
    //     catch (Exception ex)
    //     {
    //         _logger.LogError(ex, ex.Message);
    //         throw;
    //     }
    // }

    private bool DrawSquare(int i, int j)
    {
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
    
    /// <summary>
    /// Draws the crossword square
    /// </summary>
    /// <param name="sqPuzzleSquare"></param>
    /// <param name="rectSquare"></param>
    /// <param name="spriteBatch"></param>
    /// <returns></returns>
    // private bool DrawSquare(Square sqPuzzleSquare, Rectangle rectSquare, SpriteBatch spriteBatch)
    // {
    //     if (!sqPuzzleSquare.IsDirty) return true;
    //     if (sqPuzzleSquare.HighlightSquareSelColour == HighlightSquare.SquareHighlightNone)
    //     { 
    //         spriteBatch.Draw(_imgNormalSquare,rectSquare, _rectangleColor);
    //     }
    //
    //     if (sqPuzzleSquare.HighlightSquareSelColour == HighlightSquare.SquareHighlightWord)
    //     { 
    //         spriteBatch.Draw(_imgSquareWord, rectSquare, _rectangleColor);
    //     }
    //
    //     if (sqPuzzleSquare.HighlightSquareSelColour != HighlightSquare.SquareHighlightCurrent) return false;
    //     spriteBatch.Draw(_imgHighliteSquare, rectSquare, _rectangleColor);
    //
    //     return false;
    //}
    
    #endregion
}