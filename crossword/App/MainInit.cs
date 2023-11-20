namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region MainInit

    /// <summary>
    /// MainInit - Main initialiser
    /// </summary>
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

        NewBackFlush = true;


        //Show the lists
        LstClueAcross.Visible = true;
        LstClueDown.Visible = true;

        //Set the initial active square
        SqCurrentSquare = caPuzzleClueAnswers[0].GetSquare();

        //Return the orientation
        IsAcross = caPuzzleClueAnswers[0].IsAcross;

        //Highlight the default square...if allowed
        caPuzzleClueAnswers[0].HighlightSquares(SqCurrentSquare, true);

        //Set the default across list item to be the first item in the list
        LstClueAcross.SelectedIndex = 0;

        //Forces dirty squares
        // for (var i = 0; i < _NumRows; i++)
        // {
        //     //down
        //     for (var j = 0; j < _NumCols; j++)
        //     {
        //         sqPuzzleSquares[i, j].IsDirty = true;
        //     }
        // }
        ForceDirtySquares();


        //Set index to bubble out
        //nBubbleOut = 1;
        bBufferDirty = true;
        NewBackFlush = true;

        //Get next puzzle ID
        _bMorePuzzles = true; // getNextPuzzleData();
    }

    /// <summary>
    /// Forces dirty squares
    /// </summary>
    private void ForceDirtySquares()
    {
        //Forces dirty squares
        for (var i = 0; i < _NumRows; i++)
        {
            //down
            for (var j = 0; j < _NumCols; j++)
            {
                sqPuzzleSquares[i, j].IsDirty = true;
            }
        }
    }

    #endregion
}