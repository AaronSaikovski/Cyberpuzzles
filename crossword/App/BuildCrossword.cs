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
        _sqPuzzleSquares = new Square[nNumRows, nNumCols];
        PuzzleSquares = new Rectangle[nNumRows, nNumCols];


        if (bNewBackFlush)
        {
            if (bInitCrossword)
                for (var i = 0; i < nNumRows; i++) //down
                for (var j = 0; j < nNumCols; j++) //across
                    _sqPuzzleSquares[i, j].bIsDirty = true;
        }

        //Initialise the arrays
        for (var i = 0; i < nNumRows; i++)
        {
            for (var j = 0; j < nNumCols; j++)
            {
                _sqPuzzleSquares[i, j] = new Square();
                _sqPuzzleSquares[i, j].CreateSquare(nCrossOffsetX + i * CWSettings.SquareWidth,
                    nCrossOffsetY + j * CWSettings.SquareHeight);
            }
        }

        //Init ClueAnswers
        caPuzzleClueAnswers = new ClueAnswers[nNumQuestions]; //Need to work out dimensions

        for (var i = 0; i < nNumQuestions; i++)
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
                        lstClueAcross.Items.Add(new ListItem(_udtDataSet[i].QuestionNum + ". " + _udtDataSet[i].Clue,
                            Color.White));
                }
                else
                {
                    sqAnswerSquares[j] = _sqPuzzleSquares[_udtDataSet[i].CoordDown, _udtDataSet[i].CoordAcross + j];
                    if (j == 0)
                        lstClueDown.Items.Add(new ListItem(_udtDataSet[i].QuestionNum + ". " + _udtDataSet[i].Clue,
                            Color.White));
                }
            }

            //Build the Clue/Answer references
            caPuzzleClueAnswers[i] = new ClueAnswers();
            caPuzzleClueAnswers[i].SetObjectRef(_udtDataSet[i].Answer,
                _udtDataSet[i].Clue, _udtDataSet[i].QuestionNum,
                _udtDataSet[i].IsAcross, sqAnswerSquares);
        }

        bInitCrossword = true;
    }

    #endregion
}