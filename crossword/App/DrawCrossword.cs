using CyberPuzzles.Crossword.Constants;
using FontStashSharp;
using Microsoft.Xna.Framework;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region DrawCrossword

    private void DrawCrossword()
    {
        // Begin drawing
        _spriteBatch.Begin();

        //Draw the main rectangle
        _spriteBatch.Draw(blackTexture, RectCrossWord, rectangleColor);

        //Build the squares
        for (var i = 0; i < nNumRows; i++)
        {
            for (var j = 0; j < nNumCols; j++)
            {
                PuzzleSquares[i, j] = new Rectangle(_sqPuzzleSquares[i, j].XCoord, _sqPuzzleSquares[i, j].YCoord,
                    CWSettings.SquareWidth, CWSettings.SquareHeight);

                //Check to see if a char is allowed
                if (_sqPuzzleSquares[i, j].bIsCharAllowed)
                {
                    //Check to see if a repaint is required
                    if (!_sqPuzzleSquares[i, j].bIsDirty) continue;
                    if (_sqPuzzleSquares[i, j].clBackColour.Equals(Color.White))
                    {
                        _spriteBatch.Draw(imgNormalSquare, PuzzleSquares[i, j], rectangleColor);
                    }

                    if (_sqPuzzleSquares[i, j].clBackColour.Equals(Color.Yellow))
                    {
                        _spriteBatch.Draw(imgSquareWord, PuzzleSquares[i, j], rectangleColor);
                    }

                    if (_sqPuzzleSquares[i, j].clBackColour.Equals(Color.Cyan))
                    {
                        _spriteBatch.Draw(imgHighliteSquare, PuzzleSquares[i, j], rectangleColor);
                    }

                    //small number font
                    //hack walking across object boundaries

                    if (_sqPuzzleSquares[i, j].clAcross != null)
                    {
                        if (_sqPuzzleSquares[i, j].clAcross.SqAnswerSquares[0] == _sqPuzzleSquares[i, j])
                        {
                            _spriteBatch.DrawString(fntnumFont,
                                _sqPuzzleSquares[i, j].clAcross.QuestionNumber.ToString(),
                                new Vector2(PuzzleSquares[i, j].X + CWSettings.SML_NUM_OFFSET_X,
                                    PuzzleSquares[i, j].Y + CWSettings.SML_NUM_OFFSET_Y), Color.Black);
                        }
                    }

                    if (_sqPuzzleSquares[i, j].clDown != null)
                    {
                        if (_sqPuzzleSquares[i, j].clDown.SqAnswerSquares[0] == _sqPuzzleSquares[i, j])
                        {
                            _spriteBatch.DrawString(fntnumFont, _sqPuzzleSquares[i, j].clDown.QuestionNumber.ToString(),
                                new Vector2(PuzzleSquares[i, j].X + CWSettings.SML_NUM_OFFSET_X,
                                    PuzzleSquares[i, j].Y + CWSettings.SML_NUM_OFFSET_Y), Color.Black);
                        }
                    }

                    //Char entered by user.
                    _spriteBatch.DrawString(fntFont, char.ToUpper(_sqPuzzleSquares[i, j].ChLetter).ToString(),
                        new Vector2(PuzzleSquares[i, j].X + CWSettings.SQ_CHAR_OFFSET_X,
                            PuzzleSquares[i, j].Y + CWSettings.SQ_CHAR_OFFSET_Y), _sqPuzzleSquares[i, j].clForeColour);
                }
                else
                {
                    // Black square
                    _spriteBatch.Draw(blackTexture, PuzzleSquares[i, j], rectangleColor);
                }
            }
        }

        _spriteBatch.End();


        bNewBackFlush = false;
    }

    #endregion
}