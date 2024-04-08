

using Color = Microsoft.Xna.Framework.Color;

namespace Crossword.Shared.Constants;

/// <summary>
/// UI Constants
/// </summary>
public static class UiConstants
{

    //Crossword dimension constants
    public const int CrosswordWindowHeight = 600;
    public const int CrosswordWindowWidth = 800;

    //Square width and height constants
    public const int SquareWidth = 40;
    public const int SquareHeight = 40;
    public const float SquareSpacer = 1.5f;


    //Font sizes
    public const int FntSml = 9;
    public const int FntMed = 15;
    public const int FntLge = 20;
    public const int FntCredits = 13;



    //main game offsets
    public const int MainOffsetX = 30;
    public const int MainOffsetY = 30;


    //Small number offset
    public const float SmlNumOffsetX = 1.8f;
    public const float SmlNumOffsetY = 1.7f;


    //Square char offset
    public const float SqCharOffsetX = 12.5f;
    public const float SqCharOffsetY = 12f;

    //ClueList offsets/sizes
    public const int ClLabelHeight = 20;
    public const int ClListboxHeight = 180;
    public const int ClListSpacer = 5;

    //Colors for square letters
    public static Color SqCorrect = Color.Green;
    public static Color SqError = Color.Black;

    //Puzzle tile images
    public const string BlackSquare = "images/tile_black";
    public const string HighliteSquare = "images/tile_yellow";
    public const string SquareWord = "images/tile_orange";
    public const string NormalSquare = "images/tile_grey";

    //Link Buttons
    public const string HintButtonImage = "images/btn_get_hint";
    public const string NextPuzzleButtonImage = "images/btn_next_puzzle";


    //Fonts
    public const string HelveticaBold = "content/fonts/Helvetica-Bold.ttf";
    public const string HelveticaPlain = "content/fonts/Helvetica.ttf";


    //Score color
    public static Color ScoreColor = Color.Red;

    //Credits Colo
    public static Color CreditsColor = Color.Black;
    
    //Listbox text colors
    public static Color ListBoxTextColor = Color.Black;

    //Square highlight colors
    public static Color SquareHighlightCurrent = Color.Cyan;
    public static Color SquareHighlightWord = Color.Yellow;
    public static Color SquareHighlightNone = Color.White;
    public static Color SquareHighlightErr = Color.Red;
    public static Color SquareHighlightDefault = Color.Black;

    //Font colors
    public static Color SmallFontColor = Color.Black;

}