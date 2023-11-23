
using FontStashSharp;
using InputHandlers.Keyboard;
using InputHandlers.Mouse;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.UI;

//Custom namespaces
using CyberPuzzles.Crossword.InputHandlers;
using CyberPuzzles.Crossword.App.ClueAnswer;
using CyberPuzzles.Crossword.App.PuzzleSquares;
using CyberPuzzles.Crossword.App.Datasets;


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
        public bool PuzzleFinished, SetFinished;

        //Next Puzzle is currently unavailable flag
        public bool IsNextPuzzleReady = true;

        //String for Puzzle ID of last puzzle in set
        public string? PuzzleData;

        //Repaint variables
        public bool bBufferDirty, InitCrossword;

        //Image imBackBuffer;
        public bool NewBackFlush;

        //Data set variables
        public string? PuzzleType;
        public int _NumCols, _NumRows, _NumAcross, _NumDown, _PuzzleId;
        private int[] _colRef, _rowRef, _quesNum;
        private bool[] _bDataIsAcross;
        private string[] _szClues, _szAnswers;
        private int[] _nCosts = [0, 0, 0, 0, 0, 0];
        private string? _szGetLetters;
        private string? _szTmpGetLetters;
        private string? _szBlurb;
        public int NumQuestions;

        //Puzzle Dataset instance
        private PuzzleDataset[] _puzzleDataset;

        //Square instance variable
        public Square?[,] sqPuzzleSquares;

        //ClueAnswer Instance variable
        private ClueAnswerMap[] caPuzzleClueAnswers;

        //Highlight Constants
        private readonly int CurrentLetter = 1;
        private readonly int CurrentWord = 2;
        private readonly int CurrentNone = 3;

        //Crossword dimension constants
        private readonly int MaxCrossWidth = 291;
        private readonly int MaxCrossHeight = 291;

        //string[,] strGuesses = null;
        public Square? SqCurrentSquare;

        public bool IsFinished;

        //Square width and height constants
        private static readonly int SquareWidth;
        private static readonly int SquareHeight;

        //X and Y Offsets for the square's answer number.
        //private int NXnumOffset = 2, NYnumOffset = 9;


        //Status of row/column orientation (Across or Down)
        public bool IsAcross = true;

        //Mouse Coords
        public int NMouseX;
        public int NMouseY;

        //Tab key variable
        //private readonly int NTabPress;

        //Scoring variable
        //private int Score;


        //Component focus variable
        public int FocusState;

        //mouseMove String
        private readonly string PuzzleTitle;

        //Number of times Hint has been accessed by the user
        //int nUserHintPress;

        // Crossword score
        private int CrosswordScore;

        //More puzzles in set boolean flag
        private bool _bMorePuzzles;

        //Parser class
        private Parser.PuzzleData _mrParserData;

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
        private Rectangle[,]? _puzzleSquares;

        // Monogame graphics
        private readonly GraphicsDeviceManager _graphics;
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
        public Rectangle rectCrossWord;

        //Hint Button
        public TextButton HintButton;

        //Get Next Puzzle Button
        public TextButton GetNextPuzzleButton;


        //Crossword Width and Height variables
        private int _nCrosswordWidth;
        private int _nCrosswordHeight;
        private readonly int _nCrosswordOffset = 6;

        //Offset constants
        private readonly int _nCrossBorderWidth = 3;
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