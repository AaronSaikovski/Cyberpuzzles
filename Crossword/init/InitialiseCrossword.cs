using System;
using Crossword.Puzzle.ClueAnswerMap;
using Crossword.Puzzle.Squares;
using Microsoft.Xna.Framework;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region InitialiseCrossword
    /// <summary>
    /// Builds the crossword objects
    /// </summary>
    private void InitialiseCrossword()
    {
        try
        {
            logger.LogInformation("Start BuildCrossword()");
            
            //Init squares
            sqPuzzleSquares = new Square[_NumRows, _NumCols];
            _puzzleSquares = new Rectangle[_NumRows, _NumCols];

            //Init ClueAnswers
            caPuzzleClueAnswers = new ClueAnswer[NumQuestions]; 

            //Initialise the arrays
            InitArrays();

            //Init the ClueAnswers
            InitClueAnswers();

            InitCrossword = true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex,ex.Message);
            throw;
        }
       
    }
    #endregion
}