
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
        sqPuzzleSquares = new Square[_NumRows, _NumCols];
        _puzzleSquares = new Rectangle[_NumRows, _NumCols];


        if (BNewBackFlush)
        {
            if (BInitCrossword)
                for (var i = 0; i < _NumRows; i++) //down
                for (var j = 0; j < _NumCols; j++) //across
                    sqPuzzleSquares[i, j].bIsDirty = true;
        }

        //Initialise the arrays
        for (var i = 0; i < _NumRows; i++)
        {
            for (var j = 0; j < _NumCols; j++)
            {
                sqPuzzleSquares[i, j] = new Square();
                sqPuzzleSquares[i, j].CreateSquare(nCrossOffsetX + i * CwSettings.nSquareWidth,
                    nCrossOffsetY + j * CwSettings.nSquareHeight);
            }
        }

        //Init ClueAnswers
        caPuzzleClueAnswers = new ClueAnswer[nNumQuestions]; //Need to work out dimensions

        for (var i = 0; i < nNumQuestions; i++)
        {
            //Need to build a temp object of sqAnswerSquares[]
            var sqAnswerSquares = new Square[_puzzleDataset[i].Answer.Length];
            for (var j = 0; j < _puzzleDataset[i].Answer.Length; j++)
            {
                //Need to work out number
                //Build the Clue/Answer sets
                if (_puzzleDataset[i].IsAcross)
                {
                    sqAnswerSquares[j] = sqPuzzleSquares[_puzzleDataset[i].CoordDown + j, _puzzleDataset[i].CoordAcross];
                    if (j == 0)
                        LstClueAcross.Items.Add(new ListItem(_puzzleDataset[i].QuestionNum + ". " + _puzzleDataset[i].Clue,
                            Color.White));
                }
                else
                {
                    sqAnswerSquares[j] = sqPuzzleSquares[_puzzleDataset[i].CoordDown, _puzzleDataset[i].CoordAcross + j];
                    if (j == 0)
                        LstClueDown.Items.Add(new ListItem(_puzzleDataset[i].QuestionNum + ". " + _puzzleDataset[i].Clue,
                            Color.White));
                }
            }

            //Build the Clue/Answer references
            caPuzzleClueAnswers[i] = new ClueAnswer();
            caPuzzleClueAnswers[i].setObjectRef(_puzzleDataset[i].Answer,
                _puzzleDataset[i].Clue, _puzzleDataset[i].QuestionNum,
                _puzzleDataset[i].IsAcross, sqAnswerSquares);
        }

        BInitCrossword = true;
    }

    #endregion
}