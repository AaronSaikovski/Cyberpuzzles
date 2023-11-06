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

        bNewBackFlush = true;


        //Show the lists
        lstClueAcross.Visible = true;
        lstClueDown.Visible = true;

        //Set the initial active square
        sqCurrentSquare = caPuzzleClueAnswers[0].GetSquare();

        //Return the orientation
        bIsAcross = caPuzzleClueAnswers[0].BIsAcross;

        //Highlight the default square...if allowed
        caPuzzleClueAnswers[0].HighlightSquares(sqCurrentSquare, true);

        //Set the default across list item to be the first item in the list
        lstClueAcross.SelectedIndex = 0;


        //Forces dirty squares
        for (var i = 0; i < nNumRows; i++)
        {
            //down
            for (var j = 0; j < nNumCols; j++)
            {
                _sqPuzzleSquares[i, j].bIsDirty = true;
            }
        }


        //Set index to bubble out
        //nBubbleOut = 1;
        bBufferDirty = true;
        bNewBackFlush = true;

        //Get next puzzle ID
        bMorePuzzles = true; // getNextPuzzleData();
    }

    #endregion
}