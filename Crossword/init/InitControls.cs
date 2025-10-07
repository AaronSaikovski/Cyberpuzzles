using System;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;

using Crossword.Entities;
namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region InitControls

    /// <summary>
    /// Inits the controls
    /// </summary>
    private void InitControls()
    {
        try
        {
            _logger.LogInformation("Start InitControls()");

            //Init the main rectangle
            rectCrossWord = new Rectangle(_nCrossOffsetX, _nCrossOffsetY, _nCrosswordWidth, _nCrosswordHeight);

            //List box elements
            InitListBoxes();

            //Dimension array for crossword data
            _puzzleDataset = new CrosswordState[_numQuestions];

            // Use regular loop instead of Parallel.For (_numQuestions is typically small)
            for (var i = 0; i < _numQuestions; i++)
            {
                _puzzleDataset[i] = new CrosswordState(_rowRef![i], _colRef![i], _szAnswers![i], _szClues![i], _bDataIsAcross![i],
                _quesNum![i]);
            }

            // init labels
            _currentScoreLabel = new Label();
            _maxScoreLabel = new Label();
            _creditsLabel = new Label();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }

    #endregion
}