using System;
using Crossword.Shared.Constants;
using Microsoft.Xna.Framework;


using Crossword.UI.SmallFont;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region DrawCrossword
    /// <summary>
    /// Draws the crossword graphics
    /// </summary>
    private void DrawCrossword()
    {
        //small font class
        DrawSmallFont drawFont;
        
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
                    _puzzleSquares[i, j] = new Rectangle(
                        _sqPuzzleSquares[i, j]!.xCoord + i * (int)UiConstants.SquareSpacer,
                        _sqPuzzleSquares[i, j]!.yCoord + j * (int)UiConstants.SquareSpacer,
                        UiConstants.SquareWidth,
                        UiConstants.SquareHeight);

                    //Check to see if a char is allowed
                    if (_sqPuzzleSquares[i, j]!.IsCharAllowed)
                    {
                        //Draws the squares
                        //if (DrawSquare(i, j)) continue;
                        if (DrawSquare(_sqPuzzleSquares[i, j], _puzzleSquares[i, j], _spriteBatch)) continue;

                        //small number font
                        //DrawSmallFontAcross(i, j);
                        //DrawSmallFontDown(i, j);
                        drawFont = new DrawSmallFont();
                        drawFont.DrawSmallFontAcross(_sqPuzzleSquares?[i, j].ClueAnswerAcross,_sqPuzzleSquares[i, j], _puzzleSquares[i, j], _fntnumFont,_spriteBatch);
                        drawFont.DrawSmallFontDown(_sqPuzzleSquares?[i, j].ClueAnswerDown,_sqPuzzleSquares[i, j], _puzzleSquares[i, j], _fntnumFont,_spriteBatch);

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