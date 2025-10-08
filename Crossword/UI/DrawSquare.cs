

using Crossword.Puzzle.Squares;
using Crossword.Shared.Constants;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region DrawSquare

    /// <summary>
    /// Draws a square
    /// </summary>
    /// <param name="sqPuzzleSquare"></param>
    /// <param name="rectSquare"></param>
    /// <param name="spriteBatch"></param>
    private void DrawSquare(Square sqPuzzleSquare, Rectangle rectSquare, SpriteBatch spriteBatch)
    {
        //Check to see if a repaint is required
        if (!sqPuzzleSquare.IsDirty || _puzzleSquares is null) return;

        if (sqPuzzleSquare.BackColour.Equals(UiConstants.SquareHighlightNone))
        {
            spriteBatch.Draw(_imgNormalSquare, rectSquare, _rectangleColor);
        }
        else if (sqPuzzleSquare.BackColour.Equals(UiConstants.SquareHighlightWord))
        {
            spriteBatch.Draw(_imgSquareWord, rectSquare, _rectangleColor);
        }
        else if (sqPuzzleSquare.BackColour.Equals(UiConstants.SquareHighlightCurrent))
        {
            spriteBatch.Draw(_imgHighliteSquare, rectSquare, _rectangleColor);
        }
    }


    #endregion
}