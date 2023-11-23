
using CyberPuzzles.Crossword.Constants;
using CyberPuzzles.Crossword.App.ClueAnswer;
using CyberPuzzles.Crossword.App.PuzzleSquares;

using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region BuildCrossword
    /// <summary>
    /// Builds the crossword object
    /// </summary>
    private void BuildCrossword()
    {
        //Init squares
        sqPuzzleSquares = new Square[_NumRows, _NumCols];
        _puzzleSquares = new Rectangle[_NumRows, _NumCols];

        //Init ClueAnswers
        caPuzzleClueAnswers = new ClueAnswerMap[NumQuestions]; //Need to work out dimensions

        //Initialise the arrays
        InitArrays();

        //Init the ClueAnswers
        InitClueAnswers();

        InitCrossword = true;
    }
    #endregion

    #region InitClueAnswers
    /// <summary>
    /// Inits the ClueAnswers
    /// </summary>
    private void InitClueAnswers()
    {
        for (var i = 0; i < NumQuestions; i++)
        {
            //Need to build a temp object of sqAnswerSquares[]
            var sqAnswerSquares = new Square?[_puzzleDataset[i].Answer.Length];
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
            caPuzzleClueAnswers[i] = new ClueAnswerMap();
            caPuzzleClueAnswers[i].SetObjectRef(_puzzleDataset[i].Answer,
                _puzzleDataset[i].Clue, _puzzleDataset[i].QuestionNum,
                _puzzleDataset[i].IsAcross, sqAnswerSquares);
        }
    }
    #endregion

    #region InitArrays
    /// <summary>
    /// Inits the arrays
    /// </summary>
    private void InitArrays()
    {
        for (var i = 0; i < _NumRows; i++)
        {
            for (var j = 0; j < _NumCols; j++)
            {
                if (sqPuzzleSquares != null)
                {
                    sqPuzzleSquares[i, j] = new Square();

                    //Set SQs to dirty
                    if (NewBackFlush || InitCrossword)
                    {
                        sqPuzzleSquares[i, j]!.IsDirty = true;
                    }

                    //Create squares
                    sqPuzzleSquares[i, j]
                        ?.CreateSquare(nCrossOffsetX + i * CwSettings.nSquareWidth,
                        nCrossOffsetY + j * CwSettings.nSquareHeight);
                }
            }
        }
    }
    #endregion
}