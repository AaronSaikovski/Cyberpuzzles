using System;
using System.IO;
using FontStashSharp;
using InputHandlers.Keyboard;
using InputHandlers.Mouse;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.UI;

//Custom namespaces
using CyberPuzzles.Crossword.InputHandlers;
using CyberPuzzles.Crossword.ClueAnswer;
using CyberPuzzles.Crossword.Parser;
using CyberPuzzles.Crossword.Squares;
using CyberPuzzles.Crossword.Datasets;

////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:     crossword.cs                                          //
//      Authors:    Aaron Saikovski & Bryan Richards                      //
//      Date:       24/03/97                                              //
//      Purpose:    A crossword Applet based on the well known crossword. //
//                  Part of the OzEmail Cyber puzzles suite.              //
//                                                                        //
////////////////////////////////////////////////////////////////////////////

namespace CyberPuzzles.Crossword.App
{
    public sealed partial class Crossword : Game
    {
        #region Fields       

        //Puzzle State machines
        public bool bPuzzleFinished, bSetFinished;

        //Next Puzzle is currently unavailable flag
        public bool bIsNextPuzzleReady = true;

        //String for Puzzle ID of last puzzle in set
        public string szPuzData;

        //Repaint variables
        public bool bBufferDirty , bInitCrossword;

        //Image imBackBuffer;
        public bool bNewBackFlush;

        //Data set variables
        public string szPuzzleType;
        public int nNumCols , nNumRows, nNumAcross, nNumDown, puzzleId;
        int[] _colRef, _rowRef, _quesNum;
        bool[] _bDataIsAcross;
        string[] _szClues , _szAnswers;
        readonly int[] nCosts = { 0, 0, 0, 0, 0, 0 };
        string _szGetLetters, _szTmpGetLetters, _szBlurb;
        public int nNumQuestions;

        //Data set instance variable
        DatasetUdt[] _udtDataSet;

        //Square instance variable
        Square[,] _sqPuzzleSquares;

        //ClueAnswer Instance variable
        public ClueAnswers[] caPuzzleClueAnswers;

        //Highlight Constants
        public int nCURRENT_LETTER = 1;
        public int nCURRENT_WORD = 2;
        public int nCURRENT_NONE = 3;

        //Crossword dimension constants
        public int nMAX_CROSS_WIDTH = 291;
        public int nMAX_CROSS_HEIGHT = 291;

        //string[,] strGuesses = null;
        public Square sqCurrentSquare;

        public bool bIsFinished;

        //Square width and height constants
        public static int nSquareWidth;
        public static int nSquareHeight;

        //X and Y Offsets for the square's answer number.
        public int nXNUM_OFFSET = 2, nYNUM_OFFSET = 9;



        

        //Status of row/column orientation (Across or Down)
        public bool bIsAcross = true;  

        //Mouse Coords
        public int nMouseX;
        public int nMouseY;

        //Tab key variable
        public int nTabPress;

        //Scoring variable
        public int nScore;
 

        //Component focus variable
        public int nFocusState;    

        //mouseMove String
        public string szPuzzleTitle;

        //Number of times Hint has been accessed by the user
        //int nUserHintPress;

        // Crossword score
        public int nCrosswordScore;

        //More puzzles in set boolean flag
        bool bMorePuzzles;

        //Parser class
        private CrosswordParser _mrParser;

        //Images to use forx Crossword squares
        private Texture2D imgSquareWord;
        private Texture2D imgHighliteSquare;
        private Texture2D imgNormalSquare;

     
        //list boxes
        public ListBox lstClueAcross;
        public ListBox lstClueDown;

        //Panel for UI
        private Panel _MainPanel;


        //Puzzle squares
        private Rectangle[,] PuzzleSquares;

        // Monogame graphics
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Desktop _desktop;


        // Define a color for the rectangles
        Color rectangleColor = Color.White;
        Color rectangleBlack = Color.Black;
        Texture2D blackTexture;

        //Fonts
        private DynamicSpriteFont fntnumFont;   //small number font
        private DynamicSpriteFont fntFont;      //Char entered by user.
        private DynamicSpriteFont fntScore;     //Crossword score
        private DynamicSpriteFont fntListhead;  //Across/Down listbox Headers
        private DynamicSpriteFont fntListFont;  // ListBox font


        //Keyboard handler
        readonly KeyboardInput _keyboardInput;
        readonly KeyboardHandler _keyboardHandler;

        //Mouse handler
        readonly MouseInput _mouseInput;
        readonly MouseHandler _mouseHandler;

        //Labels
        private Label CurrentScoreLabel;
        private Label MaxScoreLabel;
        private Label ClueAcrossLabel;
        private Label ClueDownLabel;

        //Crossword Rectangles for mouse handling
        //Rectangle variable
        public Rectangle RectCrossWord;
        
        
        //Crossword Width and Height variables
        private int nCrosswordWidth, nCrosswordHeight, nCrosswordOffset=6;
        
        //Offset constants
        private int nCROSS_BORDER_WIDTH = 3;
        private int nCrossOffsetX = 5;
        private int nCrossOffsetY = 5;
        
        #endregion

        #region main_constructor
        // Main crossword constructor
        public Crossword()
        {
            //Prepare Graphics
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            //Keyboard handlers
            _keyboardInput = new KeyboardInput();
            _keyboardHandler = new KeyboardHandler(this); //Pass in crossword instance object
            _keyboardInput.Subscribe(_keyboardHandler);

            //Mouse handlers
            _mouseInput = new MouseInput();
            _mouseHandler = new MouseHandler(this); //Pass in crossword instance object
            _mouseInput.Subscribe(_mouseHandler);
        }
        #endregion
       
    }
}