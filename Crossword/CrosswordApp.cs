using System;
using Crossword.Entities;
using Crossword.Puzzle.ClueAnswerMap;
using Crossword.Puzzle.Squares;
using Crossword.Shared.Constants;
using Crossword.Parser;
using FontStashSharp;
using InputHandlers.Keyboard;
using InputHandlers.Mouse;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.UI;
using Crossword.Shared.Logger;

using Crossword.Shared.Config;

////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:     crossword.cs                                          //
//      Authors:    Aaron Saikovski & Bryan Richards                      //
//      Date:       24/03/97                                              //
//      Purpose:    A crossword Applet based on the well known crossword. //
//                  Part of the OzEmail Cyber puzzles suite.              //
//                                                                        //
////////////////////////////////////////////////////////////////////////////

namespace Crossword.App;

public sealed partial class CrosswordApp : Game
{
    #region Fields       

    //Puzzle State machines
    private bool _puzzleFinished;
    private bool _setFinished;

    //String for Puzzle ID of last puzzle in set
    private string? _puzzleData;

    //Repaint variables
    private bool _bBufferDirty;
    private bool _initCrossword;

    //Image imBackBuffer;
    private bool _newBackFlush;

    //Data set variables
    public string? PuzzleType;
    public int _NumCols, _NumRows, _NumAcross, _NumDown, _PuzzleId;
    private int[]? _colRef, _rowRef, _quesNum;
    private bool[]? _bDataIsAcross;
    private string[]? _szClues, _szAnswers;
    private int[]? _nCosts = [0, 0, 0, 0, 0, 0];
    private string? _szGetLetters;
    private string? _szTmpGetLetters;
    private int _numQuestions;

    //Puzzle Dataset instance
    private CrosswordState[]? _puzzleDataset;

    //Square instance variable
    private Square[,]? _sqPuzzleSquares;

    //ClueAnswerMap Instance variable
    private ClueAnswer[]? _caPuzzleClueAnswers;


    //string[,] strGuesses = null;
    private Square? _sqCurrentSquare;

    public bool IsFinished;



    //Status of row/column orientation (Across or Down)
    private bool _isAcross = true;




    //Component focus variable
    private int _focusState;



    // CrosswordApp.Application score
    private int _crosswordScore;



    //Parser class
    private CrosswordParser? _crosswordParser;

    //Crossword data
    private CrosswordData? _mrParserData;


    //Images to use forx CrosswordApp.Application squares
    private Texture2D? _imgSquareWord;
    private Texture2D? _imgHighliteSquare;
    private Texture2D? _imgNormalSquare;
    private Texture2D? _imgBlackSquare;


    //Link buttons
    private PuzzleButton? _HintButton;
    private Texture2D? _imgHintButton;
    private PuzzleButton? _NextPuzzButton;
    private Texture2D? _imgNextPuzzButton;

    //list boxes
    private ListBox? _lstClueAcross;
    private ListBox? _lstClueDown;
    // private ListView LstClueAcross;
    // private ListView LstClueDown;

    //Panel for UI
    private Panel? _mainPanel;


    //Puzzle squares
    private Rectangle[,]? _puzzleSquares;

    // Monogame graphics
    public readonly GraphicsDeviceManager? _graphics;
    public SpriteBatch? _spriteBatch;
    public Desktop? _desktop;


    // Define a color for the rectangles
    private readonly Color _rectangleColor = Color.White;
    private Texture2D? _blackTexture;

    //Fonts
    private DynamicSpriteFont? _fntnumFont;   //small number font
    private DynamicSpriteFont? _fntFont;      //Char entered by user.
    private DynamicSpriteFont? _fntScore;     //CrosswordApp.Application score
    private DynamicSpriteFont? _fntListhead;  //Across/Down listbox Headers
    private DynamicSpriteFont? _fntListFont;  // ListBox font
    private DynamicSpriteFont? _fntCredits;  // Credits


    //Keyboard handler
    private readonly KeyboardInput? _keyboardInput;
    private readonly KeyboardInputHandler? _keyboardInputHandler;

    //Mouse handler
    private readonly MouseInput? _mouseInput;
    private readonly MouseInputHandler? _mouseInputHandler;

    //Labels
    private Label? _currentScoreLabel;
    private Label? _maxScoreLabel;
    private Label? _clueAcrossLabel;
    private Label? _clueDownLabel;
    private Label? _creditsLabel;

    //CrosswordApp.Application Rectangles for mouse handling
    //Rectangle variable
    public Rectangle rectCrossWord;




    //CrosswordApp.Application Width and Height variables
    private int _nCrosswordWidth;
    private int _nCrosswordHeight;


    //Offset constants
    //private readonly int _nCrossBorderWidth = 3;
    private int _nCrossOffsetX = 5;
    private int _nCrossOffsetY = 5;

    //Logging implementation
    private SerilogLogger _logger;


    #endregion

    #region main_constructor
    // Main crossword constructor
    public CrosswordApp()
    {
        //Init the logger and get the active config
        _logger = new SerilogLogger(ConfigurationHelper.ActiveConfiguration);

        //Prepare Graphics
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";

        // Set the desired window size here
        _graphics.PreferredBackBufferWidth = UiConstants.CrosswordWindowWidth; // Width
        _graphics.PreferredBackBufferHeight = UiConstants.CrosswordWindowHeight; // Height
        IsMouseVisible = true;

        IsFixedTimeStep = true; // Set to true to use fixed time step
        TargetElapsedTime = TimeSpan.FromMilliseconds(1000.0 / 30); // Set the desired refresh rate (e.g., 30 FPS)

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
