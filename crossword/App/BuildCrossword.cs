
using CyberPuzzles.Crossword.Constants;
using CyberPuzzles.Crossword.App.ClueAnswers;
using CyberPuzzles.Crossword.App.Squares;

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
            var sqAnswerSquares = new Square[_udtDataSet[i].szAnswer.Length];
            for (var j = 0; j < _udtDataSet[i].szAnswer.Length; j++)
            {
                //Need to work out number
                //Build the Clue/Answer sets
                if (_udtDataSet[i].IsAcross)
                {
                    sqAnswerSquares[j] = _sqPuzzleSquares[_udtDataSet[i].nCoordDown + j, _udtDataSet[i].nCoordAcross];
                    if (j == 0)
                        LstClueAcross.Items.Add(new ListItem(_udtDataSet[i].nQuestionNum + ". " + _udtDataSet[i].szClue,
                            Color.White));
                }
                else
                {
                    sqAnswerSquares[j] = _sqPuzzleSquares[_udtDataSet[i].nCoordDown, _udtDataSet[i].nCoordAcross + j];
                    if (j == 0)
                        LstClueDown.Items.Add(new ListItem(_udtDataSet[i].nQuestionNum + ". " + _udtDataSet[i].szClue,
                            Color.White));
                }
            }

            //Build the Clue/Answer references
            CaPuzzleClueAnswers[i] = new ClueAnswer();
            CaPuzzleClueAnswers[i].setObjectRef(_udtDataSet[i].szAnswer,
                _udtDataSet[i].szClue, _udtDataSet[i].nQuestionNum,
                _udtDataSet[i].IsAcross, sqAnswerSquares);
        }

        BInitCrossword = true;
    }

    #endregion
}