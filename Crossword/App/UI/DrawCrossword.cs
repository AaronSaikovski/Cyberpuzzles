using System;
using Crossword.Constants;
using FontStashSharp;
using Microsoft.Xna.Framework;

namespace Crossword.App;

public sealed partial class CrosswordMain
{
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
                    if (sqPuzzleSquares is null) continue;
                    if (_puzzleSquares is null) continue;
                    
                    //Main puzzle squares array
                    //Draw crossword with squares with spaces
                    _puzzleSquares[i, j] = new Rectangle(
                        sqPuzzleSquares[i, j]!.xCoord + i * ((int)UIConstants.SquareSpacer),
                        sqPuzzleSquares[i, j]!.yCoord + j * ((int) UIConstants.SquareSpacer),
                        UIConstants.SquareWidth,
                        UIConstants.SquareHeight);
            
                    //Check to see if a char is allowed
                    if (sqPuzzleSquares[i, j]!.IsCharAllowed)
                    {
                        //Draws the squares
                        if (DrawSquares(i, j)) continue;
            
                        //small number font
                        DrawSmallFontAcross(i, j);
                        DrawSmallFontDown(i, j);
            
                        //check if squares are dirty
                        if (sqPuzzleSquares[i, j]!.IsDirty)
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
            NewBackFlush = false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
            throw;
        }
    }

    #endregion

    #region DrawUserChar
    /// <summary>
    /// Draws char entered by user
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    private void DrawUserChar(int i, int j)
    {
        try
        {
            _logger.LogInformation("Start DrawUserChar()");
            
            //Char entered by user.
            _spriteBatch.DrawString(_fntFont, char.ToUpper(sqPuzzleSquares[i, j].Letter).ToString(),
                new Vector2(_puzzleSquares[i, j].X + UIConstants.SqCharOffsetX,
                    _puzzleSquares[i, j].Y + UIConstants.SqCharOffsetY),
                sqPuzzleSquares[i, j].ForeColour);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
            throw;
        }
    }
    #endregion

    #region DrawSmallFont
    /// <summary>
    /// Draws small font Across
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    private void DrawSmallFontAcross(int i, int j)
    {
        try
        {
            _logger.LogInformation("Start DrawSmallFontAcross()");
            if (sqPuzzleSquares[i, j]?.ClueAnswerAcross is null) return;
            if (sqPuzzleSquares[i, j]?.ClueAnswerAcross?.SqAnswerSquares?[0] != sqPuzzleSquares[i, j]) return;
            if (_puzzleSquares is not null)
                _spriteBatch.DrawString(_fntnumFont,
                    sqPuzzleSquares[i, j]?.ClueAnswerAcross?.QuestionNumber.ToString(),
                    new Vector2(_puzzleSquares[i, j].X + UIConstants.SmlNumOffsetX,
                        _puzzleSquares[i, j].Y + UIConstants.SmlNumOffsetY), UIConstants.SmallFontColor);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
            throw;
        }
       
    }

    /// <summary>
    /// Draws small font Down
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    private void DrawSmallFontDown(int i, int j)
    {
        try
        {
            _logger.LogInformation("Start DrawSmallFontDown()");
            
            if (sqPuzzleSquares?[i, j].ClueAnswerDown is null) return;
            if (sqPuzzleSquares?[i, j].ClueAnswerDown?.SqAnswerSquares?[0] != sqPuzzleSquares[i, j]) return;
            _spriteBatch.DrawString(_fntnumFont,
                sqPuzzleSquares[i, j]?.ClueAnswerDown?.QuestionNumber.ToString(),
                new Vector2(_puzzleSquares[i, j].X + UIConstants.SmlNumOffsetX,
                    _puzzleSquares[i, j].Y + UIConstants.SmlNumOffsetY), UIConstants.SmallFontColor);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
            throw;
        }
        
    }
    #endregion

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
            _logger.LogInformation("Start DrawSquares()");
            
            //Check to see if a repaint is required
            if (!sqPuzzleSquares[i, j]!.IsDirty) return true;
            if (sqPuzzleSquares[i, j]!.BackColour.Equals(UIConstants.SquareHighlightNone))
            {
                if (_puzzleSquares is not null) _spriteBatch.Draw(_imgNormalSquare, _puzzleSquares[i, j], _rectangleColor);
            }

            if (sqPuzzleSquares[i, j]!.BackColour.Equals(UIConstants.SquareHighlightWord))
            {
                if (_puzzleSquares is not null) _spriteBatch.Draw(_imgSquareWord, _puzzleSquares[i, j], _rectangleColor);
            }

            if (!sqPuzzleSquares[i, j]!.BackColour.Equals(UIConstants.SquareHighlightCurrent)) return false;
            if (_puzzleSquares is not null) _spriteBatch.Draw(_imgHighliteSquare, _puzzleSquares[i, j], _rectangleColor);

            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
            throw;
        }
        
    }

    #endregion
}