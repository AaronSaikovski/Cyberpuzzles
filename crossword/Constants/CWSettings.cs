
////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:     CWSettings.cs                                          //
//      Authors:    Aaron Saikovski                                       //
//      Date:       31/10/202                                             //
//      Version:    1.0                                                   //
//      Purpose:    Global constants.                                     //
//                                                                        //
////////////////////////////////////////////////////////////////////////////


using Microsoft.Xna.Framework;

namespace CyberPuzzles.Crossword.Constants
{
    public class CwSettings
    {

        //Square width and height constants
        public const int nSquareWidth = 32;
        public const int nSquareHeight = 32;

        //Highlight Constants
        public const int nCURRENT_LETTER = 1;
        public const int nCURRENT_WORD = 2;
        public const int nCURRENT_NONE = 3;


        //Font sizes
        public const int FntSml = 9;
        public const int FntMed = 14;
        public const int FntLge = 18;
        
        //Crossword dimension constants
        public const int NMaxCrossWidth = 291;
        public const int NMaxCrossHeight = 291;


        //main game offsets
        public const int MainOffsetX = 30;
        public const int MainOffsetY = 30;


        //Small number offset
        public const float SmlNumOffsetX = 1.5f;
        public const float SmlNumOffsetY = 1.5f;


        //Square char offset
        public const float SqCharOffsetX = 9f;
        public const float SqCharOffsetY = 7f;

        //ClueList offsets/sizes
        public const int ClLabelHeight = 20;
        public const int ClListboxHeight = 180;
        public const int ClListSpacer = 5;
        
        //Colors for square letters
        public static Color SqCorrect = Color.White;
        public static Color SqError = Color.Red;

    }
}


