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
        _puzzleSquares[i, j] = new Rectangle(
            _sqPuzzleSquares[i, j]!.XCoord + i * (int)UiConstants.SquareSpacer,
            _sqPuzzleSquares[i, j]!.YCoord + j * (int)UiConstants.SquareSpacer,
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
        //Check to see if a char is allowed
        if (_sqPuzzleSquares[i, j]!.IsCharAllowed)
        {
            //Draws the squares
            DrawSquare(_sqPuzzleSquares[i, j], _puzzleSquares[i, j], _spriteBatch);

            //small number font
            var drawFont = new DrawSmallFont();
            drawFont.DrawSmallFontAcross(_sqPuzzleSquares?[i, j].ClueAnswerAcross, _sqPuzzleSquares[i, j], _puzzleSquares[i, j], _fntnumFont, _spriteBatch);
            drawFont.DrawSmallFontDown(_sqPuzzleSquares?[i, j].ClueAnswerDown, _sqPuzzleSquares[i, j], _puzzleSquares[i, j], _fntnumFont, _spriteBatch);

            //check if squares are dirty
            if (_sqPuzzleSquares[i, j]!.IsDirty)
            {
                //Char entered by user.
                DrawUserChar(i, j);
            }
        }
        else
        {
            // Black square
            _spriteBatch.Draw(_imgBlackSquare, _puzzleSquares[i, j], _rectangleColor);
        }
    }

    #region DrawCrossword
    /// <summary>
    /// Draws the crossword graphics
    /// </summary>
    private void DrawCrossword()
    {
        try
        {
            _logger.LogInformation("Start DrawCrossword()");

            // Begin drawing
            _spriteBatch.Begin();

            //Draw the main rectangle
            _spriteBatch.Draw(_blackTexture, rectCrossWord, _rectangleColor);

            //Build the squares
            for (var i = 0; i < _NumRows; i++)
            {
                for (var j = 0; j < _NumCols; j++)
                {
                    if (_sqPuzzleSquares is null) continue;
                    if (_puzzleSquares is null) continue;

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