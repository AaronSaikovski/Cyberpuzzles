using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Serialization;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region GetNextPuzzle

    

    
    /// <summary>
    ///  //Get the next puzzle.
    /// </summary>
    private void GetNextPuzzle()
    { 
        //Reset everything and reinitialise
     
         //Repaint variables
         bBufferDirty = true;
         InitCrossword = true;
         IsFinished = true;
         NewBackFlush = true;
         PuzzleFinished = false;
         SetFinished = false;

         //get the new data set
         _mrParserData = null;
         InitPuzzleData();
           
        //Next Puzzle is currently unavailable flag
        IsNextPuzzleReady = true;

        //list boxes
        LstClueAcross.Items.Clear();
        LstClueDown.Items.Clear();
           
        //Init the data
        InitData();
        
        //remove all widgets from the main panel
        _mainPanel.Widgets.Clear();

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
        ForceDirtySquares();

        //Set index to bubble out
        bBufferDirty = true;
        NewBackFlush = true;

        //Get next puzzle ID
        _bMorePuzzles = true;

        IsFinished = false;

        //Cleanup
        System.GC.Collect();

    }
    #endregion
}