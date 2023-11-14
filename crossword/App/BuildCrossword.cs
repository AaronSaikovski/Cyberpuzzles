
using CyberPuzzles.Crossword.Constants;

using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region BuildCrossword

    private void BuildCrossword()
    {
        //Init squares
        _sqPuzzleSquares = new Square[_NumRows, _NumCols];
        _puzzleSquares = new Rectangle[_NumRows, _NumCols];


        if (BNewBackFlush)
        {
            if (BInitCrossword)
                for (var i = 0; i < _NumRows; i++) //down
                for (var j = 0; j < _NumCols; j++) //across
                    _sqPuzzleSquares[i, j].bIsDirty = true;
        }

        //Initialise the arrays
        for (var i = 0; i < _NumRows; i++)
        {
            for (var j = 0; j < _NumCols; j++)
            {
                _sqPuzzleSquares[i, j] = new Square();
                _sqPuzzleSquares[i, j].CreateSquare(_nCrossOffsetX + i * CwSettings.nSquareWidth,
                    _nCrossOffsetY + j * CwSettings.nSquareHeight);
            }
        }

        //Init ClueAnswers
        CaPuzzleClueAnswers = new ClueAnswer[_NumQuestions]; //Need to work out dimensions

        for (var i = 0; i < _NumQuestions; i++)
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
            CaPuzzleClueAnswers[i] = new ClueAnswer();
            CaPuzzleClueAnswers[i].setObjectRef(_udtDataSet[i].Answer,
                _udtDataSet[i].Clue, _udtDataSet[i].QuestionNum,
                _udtDataSet[i].IsAcross, sqAnswerSquares);
        }

        BInitCrossword = true;
    }

    #endregion
}