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
        public bool BPuzzleFinished, BSetFinished;

        //Next Puzzle is currently unavailable flag
        public bool BIsNextPuzzleReady = true;

        //String for Puzzle ID of last puzzle in set
        public string SzPuzData;

        //Repaint variables
        public bool BBufferDirty , BInitCrossword;

        //Image imBackBuffer;
        public bool BNewBackFlush;

        //Data set variables
        public string SzPuzzleType;
        public int NNumCols , NNumRows, NNumAcross, NNumDown, PuzzleId;
        private int[] _colRef, _rowRef, _quesNum;
        private bool[] _bDataIsAcross;
        private string[] _szClues , _szAnswers;
        readonly int[] _nCosts = { 0, 0, 0, 0, 0, 0 };
        private string _szGetLetters, _szTmpGetLetters, _szBlurb;
        private int NNumQuestions;

        //Data set instance variable
        private DatasetUdt[] _udtDataSet;

        //Square instance variable
        private Square[,] _sqPuzzleSquares;

        //ClueAnswer Instance variable
        private ClueAnswers[] CaPuzzleClueAnswers;

        //Highlight Constants
        private int NCurrentLetter = 1;
        private int NCurrentWord = 2;
        private int NCurrentNone = 3;

        //Crossword dimension constants
        private int NMaxCrossWidth = 291;
        private int NMaxCrossHeight = 291;

        //string[,] strGuesses = null;
        public Square SqCurrentSquare;

        public bool BIsFinished;

        //Square width and height constants
        private static int NSquareWidth;
        private static int NSquareHeight;

        //X and Y Offsets for the square's answer number.
        private int NXnumOffset = 2, NYnumOffset = 9;



        

        //Status of row/column orientation (Across or Down)
        private bool BIsAcross = true;  

        //Mouse Coords
        public int NMouseX;
        public int NMouseY;

        //Tab key variable
        private int NTabPress;

        //Scoring variable
        private int NScore;
 

        //Component focus variable
        private int NFocusState;    

        //mouseMove String
        private string SzPuzzleTitle;

        //Number of times Hint has been accessed by the user
        //int nUserHintPress;

        // Crossword score
        private int NCrosswordScore;

        //More puzzles in set boolean flag
        private bool _bMorePuzzles;

        //Parser class
        private CrosswordParser _mrParser;

        //Images to use forx Crossword squares
        private Texture2D _imgSquareWord;
        private Texture2D _imgHighliteSquare;
        private Texture2D _imgNormalSquare;

     
        //list boxes
        private ListBox LstClueAcross;
        private ListBox LstClueDown;

        //Panel for UI
        private Panel _mainPanel;


        //Puzzle squares
        private Rectangle[,] _puzzleSquares;

        // Monogame graphics
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Desktop _desktop;


        // Define a color for the rectangles
        private Color _rectangleColor = Color.White;
        private Color _rectangleBlack = Color.Black;
        private Texture2D _blackTexture;

        //Fonts
        private DynamicSpriteFont _fntnumFont;   //small number font
        private DynamicSpriteFont _fntFont;      //Char entered by user.
        private DynamicSpriteFont _fntScore;     //Crossword score
        private DynamicSpriteFont _fntListhead;  //Across/Down listbox Headers
        private DynamicSpriteFont _fntListFont;  // ListBox font


        //Keyboard handler
        private readonly KeyboardInput _keyboardInput;
        private readonly KeyboardInputHandler _keyboardInputHandler;

        //Mouse handler
        private readonly MouseInput _mouseInput;
        private readonly MouseInputHandler _mouseInputHandler;

        //Labels
        private Label _currentScoreLabel;
        private Label _maxScoreLabel;
        private Label _clueAcrossLabel;
        private Label _clueDownLabel;

        //Crossword Rectangles for mouse handling
        //Rectangle variable
        public Rectangle RectCrossWord;
        
        
        //Crossword Width and Height variables
        private int _nCrosswordWidth, _nCrosswordHeight, _nCrosswordOffset=6;
        
        //Offset constants
        private int _nCrossBorderWidth = 3;
        private int _nCrossOffsetX = 5;
        private int _nCrossOffsetY = 5;
        
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
            _keyboardInputHandler = new KeyboardInputHandler(this); //Pass in crossword instance object
            _keyboardInput.Subscribe(_keyboardInputHandler);

            //Mouse handlers
            _mouseInput = new MouseInput();
            _mouseInputHandler = new MouseInputHandler(this); //Pass in crossword instance object
            _mouseInput.Subscribe(_mouseInputHandler);
        }
        #endregion
       
    }
}