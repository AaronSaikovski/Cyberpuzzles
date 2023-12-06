using System;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;

namespace Crossword.App;

public sealed partial class CrosswordMain
{
    #region InitControls

    /// <summary>
    /// Inits the controls
    /// </summary>
    private void InitControls()
    {
        try
        {
            //Init the main rectangle
            rectCrossWord = new Rectangle(nCrossOffsetX, nCrossOffsetY, _nCrosswordWidth, _nCrosswordHeight);

            //List box elements
            InitListBoxes();
            
            //Dimension array for crossword data
            _puzzleDataset = new PuzzleState.PuzzleState[NumQuestions];
             Parallel.For(0, NumQuestions, i =>
            {
                _puzzleDataset[i] = new PuzzleState.PuzzleState(_rowRef[i], _colRef[i], _szAnswers[i], _szClues[i], _bDataIsAcross[i],
                _quesNum[i]);
            });

            // init labels
            _currentScoreLabel = new Label();
            _maxScoreLabel = new Label();
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion
}