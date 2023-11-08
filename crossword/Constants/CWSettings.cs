
////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:     CWSettings.cs                                          //
//      Authors:    Aaron Saikovski                                       //
//      Date:       31/10/202                                             //
//      Version:    1.0                                                   //
//      Purpose:    Global constants.                                     //
//                                                                        //
////////////////////////////////////////////////////////////////////////////

namespace CyberPuzzles.Crossword.Constants
{
    public class CwSettings
    {

        //Square width and height constants
        public const int SquareWidth = 27;
        public const int SquareHeight = 27;

        //Highlight Constants
        public const int NCurrentLetter = 1;
        public const int NCurrentWord = 2;
        public const int NCurrentNone = 3;


        //Font sizes
        public const int FntSml = 8;
        public const int FntMed = 16;
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
        public const float SqCharOffsetX = 8f;
        public const float SqCharOffsetY = 8f;

        //ClueList offsets/sizes
        public const int ClLabelHeight = 20;
        public const int ClListboxHeight = 180;
        public const int ClListSpacer = 5;
        
    }
}


