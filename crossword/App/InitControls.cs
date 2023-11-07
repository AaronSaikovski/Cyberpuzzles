using CyberPuzzles.Crossword.Constants;
using CyberPuzzles.Crossword.Datasets;
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

        // HintButton = new TextButton();
        // HintButton.Text = "Get Hint"; 
        // HintButton.Id = "HintButton";
        // //HintButton..Background = Color.Gray;
        // HintButton.TextColor = Color.White;
        // //HintButton.ApplyWidgetStyle(new LabelStyle(new ButtonStyle(());
        // HintButton.Left = RectCrossWord.Left;
        // HintButton.Top = RectCrossWord.Bottom + CwSettings.ClListSpacer * 2;
        // _mainPanel.Widgets.Add(HintButton);
        
        
        //Crossword Parsed Dataset
        //
        //Dimension array for crossword data
         _udtDataSet = new DatasetUdt[NNumQuestions];
         for (var i = 0; i < NNumQuestions; i++)
             _udtDataSet[i] = new DatasetUdt(_rowRef[i], _colRef[i], _szAnswers[i], _szClues[i], _bDataIsAcross[i],
                 _quesNum[i]);

        // init labels
        _currentScoreLabel = new Label();
        _maxScoreLabel = new Label();
    }

    #endregion
}