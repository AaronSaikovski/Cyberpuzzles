using System;
using Crossword.ClueAnswer;
using Crossword.PuzzleSquares;
using Microsoft.Xna.Framework;

namespace Crossword.App;

public sealed partial class CrosswordMain
{
    #region InitialiseCrossword
    /// <summary>
    /// Builds the crossword objects
    /// </summary>
    private void InitialiseCrossword()
    {
        try
        {
            _logger.LogInformation("Start BuildCrossword()");
            
            //Init squares
            sqPuzzleSquares = new Square[_NumRows, _NumCols];
            _puzzleSquares = new Rectangle[_NumRows, _NumCols];

            //Init ClueAnswers
            caPuzzleClueAnswers = new ClueAnswerMap[NumQuestions]; 

            //Initialise the arrays
            InitArrays();

            //Init the ClueAnswers
            InitClueAnswers();

            InitCrossword = true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
            throw;
        }
       
    }
    #endregion
}