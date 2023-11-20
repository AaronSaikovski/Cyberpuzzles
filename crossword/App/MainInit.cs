namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region MainInit

    private void MainInit()
    {
        //load fonts
        LoadFonts();

        //Load images
        LoadImages();

        //Init the data
        InitData();

        //Init the controls
        InitControls();


        //build the crossword data
        BuildCrossword();

        BNewBackFlush = true;


        //Show the lists
        LstClueAcross.Visible = true;
        LstClueDown.Visible = true;

        //Set the initial active square
        sqCurrentSquare = caPuzzleClueAnswers[0].GetSquare();

        //Return the orientation
        bIsAcross = caPuzzleClueAnswers[0].IsAcross;

        //Highlight the default square...if allowed
        caPuzzleClueAnswers[0].HighlightSquares(sqCurrentSquare, true);

        //Set the default across list item to be the first item in the list
        LstClueAcross.SelectedIndex = 0;


        //Forces dirty squares
        for (var i = 0; i < _NumRows; i++)
        {
            //down
            for (var j = 0; j < _NumCols; j++)
            {
                sqPuzzleSquares[i, j].bIsDirty = true;
            }
        }


        //Set index to bubble out
        //nBubbleOut = 1;
        bBufferDirty = true;
        BNewBackFlush = true;

        //Get next puzzle ID
        _bMorePuzzles = true; // getNextPuzzleData();
    }

    #endregion
}