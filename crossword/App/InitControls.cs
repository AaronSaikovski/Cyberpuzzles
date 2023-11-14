using CyberPuzzles.Crossword.Constants;
using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;
using Myra.Graphics2D.UI.Styles;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region InitControls

    private void InitControls()
    {
        //Init the main rectangle
        RectCrossWord = new Rectangle(_nCrossOffsetX, _nCrossOffsetY, _nCrosswordWidth, _nCrosswordHeight);

        //List box elements
        InitListBoxes();
      
        //Init Hint Button
        InitHintButton();
        
        //Init next puzzle button
        InitGetNextPuzzleButton();
        
        //Crossword Parsed Dataset
        //
        //Dimension array for crossword data
         _udtDataSet = new nDatasetUDT[_NumQuestions];
         for (var i = 0; i < _NumQuestions; i++)
             _udtDataSet[i] = new nDatasetUDT(_rowRef[i], _colRef[i], _szAnswers[i], _szClues[i], _bDataIsAcross[i],
                 _quesNum[i]);

        // init labels
        _currentScoreLabel = new Label();
        _maxScoreLabel = new Label();
    }

    #endregion
}