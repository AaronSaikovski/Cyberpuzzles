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
        _spriteBatch.Draw(_blackTexture, RectCrossWord, _rectangleColor);

        //Build the squares
        for (var i = 0; i < _NumRows; i++)
        {
            for (var j = 0; j < _NumCols; j++)
            {
                _puzzleSquares[i, j] = new Rectangle(_sqPuzzleSquares[i, j].nXCoord, _sqPuzzleSquares[i, j].nYCoord,
                    CwSettings.nSquareWidth, CwSettings.nSquareHeight);

                //Check to see if a char is allowed
                if (_sqPuzzleSquares[i, j].bIsCharAllowed)
                {
                    //Check to see if a repaint is required
                    if (!_sqPuzzleSquares[i, j].bIsDirty) continue;
                    if (_sqPuzzleSquares[i, j].clBackColour.Equals(Color.White))
                    {
                        _spriteBatch.Draw(_imgNormalSquare, _puzzleSquares[i, j], _rectangleColor);
                    }

                    if (_sqPuzzleSquares[i, j].clBackColour.Equals(Color.Yellow))
                    {
                        _spriteBatch.Draw(_imgSquareWord, _puzzleSquares[i, j], _rectangleColor);
                    }

                    if (_sqPuzzleSquares[i, j].clBackColour.Equals(Color.Cyan))
                    {
                        _spriteBatch.Draw(_imgHighliteSquare, _puzzleSquares[i, j], _rectangleColor);
                    }

                    //small number font
                    //hack walking across object boundaries

                    if (_sqPuzzleSquares[i, j].clAcross != null)
                    {
                        if (_sqPuzzleSquares[i, j].clAcross.sqAnswerSquares[0] == _sqPuzzleSquares[i, j])
                        {
                            _spriteBatch.DrawString(_fntnumFont,
                                _sqPuzzleSquares[i, j].clAcross.nQuestionNumber.ToString(),
                                new Vector2(_puzzleSquares[i, j].X + CwSettings.SmlNumOffsetX,
                                    _puzzleSquares[i, j].Y + CwSettings.SmlNumOffsetY), Color.Black);
                        }
                    }

                    if (_sqPuzzleSquares[i, j].clDown != null)
                    {
                        if (_sqPuzzleSquares[i, j].clDown.sqAnswerSquares[0] == _sqPuzzleSquares[i, j])
                        {
                            _spriteBatch.DrawString(_fntnumFont, _sqPuzzleSquares[i, j].clDown.nQuestionNumber.ToString(),
                                new Vector2(_puzzleSquares[i, j].X + CwSettings.SmlNumOffsetX,
                                    _puzzleSquares[i, j].Y + CwSettings.SmlNumOffsetY), Color.Black);
                        }
                    }

                    //Char entered by user.
                    _spriteBatch.DrawString(_fntFont, char.ToUpper(_sqPuzzleSquares[i, j].chLetter).ToString(),
                        new Vector2(_puzzleSquares[i, j].X + CwSettings.SqCharOffsetX,
                            _puzzleSquares[i, j].Y + CwSettings.SqCharOffsetY), _sqPuzzleSquares[i, j].clForeColour);
                }
                else
                {
                    // Black square
                    _spriteBatch.Draw(_blackTexture, _puzzleSquares[i, j], _rectangleColor);
                }
            }
        }

        _spriteBatch.End();


        BNewBackFlush = false;
    }

    #endregion
}