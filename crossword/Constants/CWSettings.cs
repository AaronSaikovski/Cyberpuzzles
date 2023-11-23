
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
        public const int FntMed = 15;
        public const int FntLge = 18;

        //Crossword dimension constants
        public const int NMaxCrossWidth = 291;
        public const int NMaxCrossHeight = 291;


        //main game offsets
        public const int MainOffsetX = 30;
        public const int MainOffsetY = 30;


        //Small number offset
        public const float SmlNumOffsetX = 1.6f;
        public const float SmlNumOffsetY = 1.5f;


        //Square char offset
        public const float SqCharOffsetX = 9f;
        public const float SqCharOffsetY = 8.5f;

        //ClueList offsets/sizes
        public const int ClLabelHeight = 20;
        public const int ClListboxHeight = 180;
        public const int ClListSpacer = 5;

        //Colors for square letters
        public static Color SqCorrect = Color.White;
        public static Color SqError = Color.Red;
        
        //default puzzledata
        public static string DefaultPuzzleData = "761*QX000001*0909*0 0 1 1#4 1 1 6#0 2 1 7#2 3 1 9#0 5 1 11#4 6 1 16#0 7 1 17#4 8 1 18#0 0 2 1#2 0 2 2#4 0 2 3#6 0 2 4#8 0 2 5#3 2 2 8#5 3 2 10#0 5 2 11#2 5 2 12#4 5 2 13#6 5 2 14#8 5 2 15*Forward#Strictly accurate#Australian marsupial#Moving to avoid#Not accepted conduct#Astonish greatly#Provide meals#Occurrence#Pretend#Public way#Beer froth#Full-length dress#Adult male deer#Crazy#Metric unit of mass#Skin irritation#Friend#Uncommon#Inland body of water#Bench*FORTH#EXACT#KOALA#DODGING#IMMORAL#AMAZE#CATER#EVENT#FAKE#ROAD#HEAD#MAXI#STAG#LOCO#GRAM#ITCH#MATE#RARE#LAKE#SEAT*ZCDEFGHIKLMNORSTVXA*30 1 1 0 1 5*Use the clues to solve this crossword and earn CyberSilver. If you have not played our crosswords before and want help, then click the HELP button. Have fun!";

    }
}


