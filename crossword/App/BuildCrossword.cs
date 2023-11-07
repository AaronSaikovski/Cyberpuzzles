using CyberPuzzles.Crossword.ClueAnswer;
using CyberPuzzles.Crossword.Constants;
using CyberPuzzles.Crossword.Squares;
using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region BuildCrossword

    private void BuildCrossword()
    {
        //Init squares
        _sqPuzzleSquares = new Square[NNumRows, NNumCols];
        _puzzleSquares = new Rectangle[NNumRows, NNumCols];


        if (BNewBackFlush)
        {
            if (BInitCrossword)
                for (var i = 0; i < NNumRows; i++) //down
                for (var j = 0; j < NNumCols; j++) //across
                    _sqPuzzleSquares[i, j].BIsDirty = true;
        }

        //Initialise the arrays
        for (var i = 0; i < NNumRows; i++)
        {
            for (var j = 0; j < NNumCols; j++)
            {
                _sqPuzzleSquares[i, j] = new Square();
                _sqPuzzleSquares[i, j].CreateSquare(_nCrossOffsetX + i * CwSettings.SquareWidth,
                    _nCrossOffsetY + j * CwSettings.SquareHeight);
            }
        }

        //Init ClueAnswers
        CaPuzzleClueAnswers = new ClueAnswers[NNumQuestions]; //Need to work out dimensions

        for (var i = 0; i < NNumQuestions; i++)
        {
            //Need to build a temp object of sqAnswerSquares[]
            var sqAnswerSquares = new Square[_udtDataSet[i].Answer.Length];
            for (var j = 0; j < _udtDataSet[i].Answer.Length; j++)
            {
                //Need to work out number
                //Build the Clue/Answer sets
                if (_udtDataSet[i].IsAcross)
                {
                    sqAnswerSquares[j] = _sqPuzzleSquares[_udtDataSet[i].CoordDown + j, _udtDataSet[i].CoordAcross];
                    if (j == 0)
                        LstClueAcross.Items.Add(new ListItem(_udtDataSet[i].QuestionNum + ". " + _udtDataSet[i].Clue,
                            Color.White));
                }
                else
                {
                    sqAnswerSquares[j] = _sqPuzzleSquares[_udtDataSet[i].CoordDown, _udtDataSet[i].CoordAcross + j];
                    if (j == 0)
                        LstClueDown.Items.Add(new ListItem(_udtDataSet[i].QuestionNum + ". " + _udtDataSet[i].Clue,
                            Color.White));
                }
            }

            //Build the Clue/Answer references
            CaPuzzleClueAnswers[i] = new ClueAnswers();
            CaPuzzleClueAnswers[i].SetObjectRef(_udtDataSet[i].Answer,
                _udtDataSet[i].Clue, _udtDataSet[i].QuestionNum,
                _udtDataSet[i].IsAcross, sqAnswerSquares);
        }

        BInitCrossword = true;
    }

    #endregion
}