using CyberPuzzles.Crossword.Constants;
using CyberPuzzles.Crossword.Datasets;
using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region InitControls

    private void InitControls()
    {
        //Init the main rectangle
        RectCrossWord = new Rectangle(nCrossOffsetX, nCrossOffsetY, nCrosswordWidth, nCrosswordHeight);


        //List box elements
        InitListBoxes();
        
        //Crossword Parsed Dataset
        //
        //Dimension array for crossword data
         _udtDataSet = new DatasetUdt[nNumQuestions];
         for (var i = 0; i < nNumQuestions; i++)
             _udtDataSet[i] = new DatasetUdt(_rowRef[i], _colRef[i], _szAnswers[i], _szClues[i], _bDataIsAcross[i],
                 _quesNum[i]);

        // init labels
        CurrentScoreLabel = new Label();
        MaxScoreLabel = new Label();
    }

    #endregion
}