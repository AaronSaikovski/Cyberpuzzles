using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region InitControls

    /// <summary>
    /// Inits the controls
    /// </summary>
    private void InitControls()
    {
        //Init the main rectangle
        rectCrossWord = new Rectangle(nCrossOffsetX, nCrossOffsetY, _nCrosswordWidth, _nCrosswordHeight);

        //List box elements
        InitListBoxes();

        //Init Hint Button
        InitHintButton();

        //Init next puzzle button
        InitGetNextPuzzleButton();

        //CrosswordApp.Application Parsed Dataset
        //
        //Dimension array for crossword data
        _puzzleDataset = new PuzzleState.PuzzleState[NumQuestions];
        for (var i = 0; i < NumQuestions; i++)
            _puzzleDataset[i] = new PuzzleState.PuzzleState(_rowRef[i], _colRef[i], _szAnswers[i], _szClues[i], _bDataIsAcross[i],
                _quesNum[i]);

        // init labels
        _currentScoreLabel = new Label();
        _maxScoreLabel = new Label();
    }

    #endregion
}