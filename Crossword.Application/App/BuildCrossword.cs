using System;
using Crossword.ClueAnswer;
using Crossword.PuzzleSquares;
using Crossword.Shared.Constants;
using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;

namespace Crossword.App;

public sealed partial class CrosswordMain
{
    #region BuildCrossword
    /// <summary>
    /// Builds the crossword objects
    /// </summary>
    private void BuildCrossword()
    {
        try
        {
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
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }
    #endregion
}