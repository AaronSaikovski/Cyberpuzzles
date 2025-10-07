using System;
using Crossword.Shared.Constants;
using Microsoft.Xna.Framework;
using Crossword.UI.SmallFont;
using System.Threading.Tasks;

namespace Crossword.App;

public sealed partial class CrosswordApp
{

    /// <summary>
    /// Init the puzzle squares
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    internal void InitPuzzleSquares(int i, int j)
    {
        
        _puzzleSquares![i, j] = new Rectangle(
            _sqPuzzleSquares![i, j]!.XCoord + i * (int)UiConstants.SquareSpacer,
            _sqPuzzleSquares![i, j]!.YCoord + j * (int)UiConstants.SquareSpacer,
            UiConstants.SquareWidth,
            UiConstants.SquareHeight);
    }

    /// <summary>
    /// Draw the squares
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    internal void DrawSquares(int i, int j)
    {
        var square = _sqPuzzleSquares![i, j];
        var rectangle = _puzzleSquares![i, j];

        //Check to see if a char is allowed
        if (square.IsCharAllowed)
        {
            //Draws the squares
            DrawSquare(square, rectangle, _spriteBatch!);

            //small number font - reuse instance to avoid allocations
            if (square.ClueAnswerAcross != null)
                _drawFont!.DrawSmallFontAcross(square.ClueAnswerAcross, square, rectangle, _fntnumFont!, _spriteBatch!);
            if (square.ClueAnswerDown != null)
                _drawFont!.DrawSmallFontDown(square.ClueAnswerDown, square, rectangle, _fntnumFont!, _spriteBatch!);

            //check if squares are dirty
            if (square.IsDirty)
            {
                //Char entered by user.
                DrawUserChar(i, j);
            }
        }
        else
        {
            // Black square
            _spriteBatch!.Draw(_imgBlackSquare, rectangle, _rectangleColor);
        }
    }

    #region DrawCrossword
    /// <summary>
    /// Draws the crossword graphics
    /// </summary>
    private void DrawCrossword()
    {
        // Move null checks outside loops for better performance
        if (_sqPuzzleSquares is null || _puzzleSquares is null)
            return;

        try
        {
            // Begin drawing
            _spriteBatch!.Begin();

            //Draw the main rectangle
            _spriteBatch.Draw(_blackTexture, rectCrossWord, _rectangleColor);

            //Build the squares
            for (var i = 0; i < _NumRows; i++)
            {
                for (var j = 0; j < _NumCols; j++)
                {
                    //Main puzzle squares array
                    //Draw crossword with squares with spaces
                    InitPuzzleSquares(i, j);

                    //Check to see if a char is allowed
                    DrawSquares(i, j);
                }
            }

            _spriteBatch.End();
            _newBackFlush = false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }

    #endregion
}