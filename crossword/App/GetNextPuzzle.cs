using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Serialization;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    /// <summary>
    ///  //Get the next puzzle.
    /// </summary>
    private void GetNextPuzzle()
    {
      //TODO: still testing  
     //Reset everything and reinitialise
        
        //Puzzle State machines
       PuzzleFinished = false;
       SetFinished = false;
       
        //Next Puzzle is currently unavailable flag
        IsNextPuzzleReady = true;

        //String for Puzzle ID of last puzzle in set
        //PuzzleData = null;

        //Repaint variables
        bBufferDirty = true;
        InitCrossword = true;

        //Image imBackBuffer;
        NewBackFlush = true;

        //Data set variables
        // PuzzleType = null;
        // _NumCols = 0;
        // _NumRows = 0;
        // _NumAcross = 0;
        // _NumDown = 0;
        // _PuzzleId = 0;
        // _colRef=null;
        // _rowRef=null;
        // _quesNum=null;
        // _bDataIsAcross = null;
        // _szClues = null;
        // _szAnswers = null;
        // _nCosts = [0, 0, 0, 0, 0, 0];
       
        // _szGetLetters = null;
        // _szTmpGetLetters = null;
        // _szBlurb = null;
        // NumQuestions = 0;

        //Puzzle Dataset instance
        // _puzzleDataset = null;

        //Square instance variable
        //sqPuzzleSquares = null;

        //ClueAnswer Instance variable
        //caPuzzleClueAnswers = null;


        //string[,] strGuesses = null;
        //SqCurrentSquare = null;

        IsFinished = false;

      
        //Status of row/column orientation (Across or Down)
       //IsAcross = true;

        //Component focus variable
        FocusState=0;

        // Crossword score
       CrosswordScore =0;

        //More puzzles in set boolean flag
        _bMorePuzzles = true;

        //Parser class
        //_mrParserData = null;



        //list boxes
        // LstClueAcross.Items.Clear();
        //  LstClueDown.Items.Clear();


        //Puzzle squares
        //_puzzleSquares = null;



        //Crossword Rectangles for mouse handling
        //Rectangle variable
        //rectCrossWord=null;

        //call main init
        //MainInit();
        
        // //Init the data
        // InitData();
        //
        // //Init the controls
        // InitControls();
        //
        // //build the crossword data
        // BuildCrossword();

        NewBackFlush = true;


        //Show the lists
        // LstClueAcross.Visible = true;
        // LstClueDown.Visible = true;

        //Set the initial active square
        //SqCurrentSquare = caPuzzleClueAnswers[0].GetSquare();

        //Return the orientation
        //IsAcross = caPuzzleClueAnswers[0].IsAcross;

        //Highlight the default square...if allowed
        //caPuzzleClueAnswers[0].HighlightSquares(SqCurrentSquare, true);

        //Set the default across list item to be the first item in the list
        LstClueAcross.SelectedIndex = 0;

        //Forces dirty squares
        ForceDirtySquares();

        //Set index to bubble out
        bBufferDirty = true;
        NewBackFlush = true;

        //Get next puzzle ID
        _bMorePuzzles = true; // getNextPuzzleData();
    }
}