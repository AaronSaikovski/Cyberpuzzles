
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
    public class CWSettings
    {

        //Square width and height constants
        public const int SquareWidth = 27;
        public const int SquareHeight = 27;

        //Highlight Constants
        public const int nCURRENT_LETTER = 1;
        public const int nCURRENT_WORD = 2;
        public const int nCURRENT_NONE = 3;


        //Font sizes
        public const int FNT_SML = 8;
        public const int FNT_MED = 14;
        public const int FNT_LGE = 16;
        
        //Crossword dimension constants
        public const int nMAX_CROSS_WIDTH = 291;
        public const int nMAX_CROSS_HEIGHT = 291;


        //main game offsets
        public const int MAIN_OFFSET_X = 30;
        public const int MAIN_OFFSET_Y = 30;


        //Small number offset
        public const float SML_NUM_OFFSET_X = 1.5f;
        public const float SML_NUM_OFFSET_Y = 1.5f;


        //Square char offset
        public const float SQ_CHAR_OFFSET_X = 8f;
        public const float SQ_CHAR_OFFSET_Y = 8f;

        //ClueList offsets/sizes
        public const int CL_LABEL_HEIGHT = 20;
        public const int CL_LISTBOX_HEIGHT = 180;
        public const int CL_LIST_SPACER = 5;
        
    }
}


