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
        _spriteBatch.Draw(_blackTexture, rectCrossWord, _rectangleColor);

        //Build the squares
        for (var i = 0; i < _NumRows; i++)
        {
            for (var j = 0; j < _NumCols; j++)
            {
                if (sqPuzzleSquares != null)
                {
                    _puzzleSquares[i, j] = new Rectangle(sqPuzzleSquares[i, j].xCoord, sqPuzzleSquares[i, j].yCoord,
                        CwSettings.nSquareWidth, CwSettings.nSquareHeight);

                    //Check to see if a char is allowed
                    if (sqPuzzleSquares[i, j].IsCharAllowed)
                    {
                        //Check to see if a repaint is required
                        if (!sqPuzzleSquares[i, j].IsDirty) continue;
                        if (sqPuzzleSquares[i, j].BackColour.Equals(Color.White))
                        {
                            _spriteBatch.Draw(_imgNormalSquare, _puzzleSquares[i, j], _rectangleColor);
                        }

                        if (sqPuzzleSquares[i, j].BackColour.Equals(Color.Yellow))
                        {
                            _spriteBatch.Draw(_imgSquareWord, _puzzleSquares[i, j], _rectangleColor);
                        }

                        if (sqPuzzleSquares[i, j].BackColour.Equals(Color.Cyan))
                        {
                            _spriteBatch.Draw(_imgHighliteSquare, _puzzleSquares[i, j], _rectangleColor);
                        }

                        //small number font
                        //hack walking across object boundaries

                        if (sqPuzzleSquares[i, j].ClueAnswerAcross != null)
                        {
                            if (sqPuzzleSquares[i, j].ClueAnswerAcross?.SqAnswerSquares?[0] == sqPuzzleSquares[i, j])
                            {
                                _spriteBatch.DrawString(_fntnumFont,
                                    sqPuzzleSquares[i, j].ClueAnswerAcross?.QuestionNumber.ToString(),
                                    new Vector2(_puzzleSquares[i, j].X + CwSettings.SmlNumOffsetX,
                                        _puzzleSquares[i, j].Y + CwSettings.SmlNumOffsetY), Color.Black);
                            }
                        }

                        if (sqPuzzleSquares?[i, j].ClueAnswerDown != null)
                        {
                            if (sqPuzzleSquares[i, j].ClueAnswerDown?.SqAnswerSquares?[0] == sqPuzzleSquares[i, j])
                            {
                                _spriteBatch.DrawString(_fntnumFont,
                                    sqPuzzleSquares[i, j].ClueAnswerDown?.QuestionNumber.ToString(),
                                    new Vector2(_puzzleSquares[i, j].X + CwSettings.SmlNumOffsetX,
                                        _puzzleSquares[i, j].Y + CwSettings.SmlNumOffsetY), Color.Black);
                            }
                        }

                        //Char entered by user.
                        if (sqPuzzleSquares != null)
                            _spriteBatch.DrawString(_fntFont, char.ToUpper(sqPuzzleSquares[i, j].Letter).ToString(),
                                new Vector2(_puzzleSquares[i, j].X + CwSettings.SqCharOffsetX,
                                    _puzzleSquares[i, j].Y + CwSettings.SqCharOffsetY),
                                sqPuzzleSquares[i, j].ForeColour);
                    }
                    else
                    {
                        // Black square
                        _spriteBatch.Draw(_blackTexture, _puzzleSquares[i, j], _rectangleColor);
                    }
                }
            }
        }

        _spriteBatch.End();


        BNewBackFlush = false;
    }

    #endregion
}