//////////////////////////////////////////////////////////////////////////////
//                                                                          //
//      Module:     CrosswordParser.cs                                      //
//      Authors:    Aaron Saikovski & Bryan Richards                        //
//      Date:       23/01/97                                                //
//      Version:    1.0                                                     //
//      Purpose:    Utilizes a String Tokenizer to parse the crossword      //
//                  puzzle components from a data set string.               //
//                                                                          //
//////////////////////////////////////////////////////////////////////////////


using CyberPuzzles.Crossword.Parsers;

namespace CyberPuzzles.Crossword.Parser
{

    ///////////////////////////////
    // Example data set String
    // "1075*QXW2410*0909*0 0 1 1#6 0 1 4#3 2 1 6#0 3 1 8#3 5 1 11#0 6 1 13#0 8 1 15#4 8 1 16#1 0 2 2#4 0 2 3#6 0 2 4#8 0 2 5#3 2 2 6#5 2 2 7#7 4 2 9#0 5 2 10#4 5 2 12#2 6 2 14*Bread maker#Skill#Receive#Calm#Real#Taunts#Apple _ _ _#Midday meal#Irritate#Wealthy#Queen,King,__ __ __#Ballet skirt#Book of maps#100 make a dollar#Conjuring#Cease#Prison room#Length of life*BAKER#ART#ACCEPT#SOOTHE#ACTUAL#TEASES#PIE#LUNCH#ANNOY#RICH#ACE#TUTU#ATLAS#CENTS#MAGIC#STOP#CELL#AGE*ABCEGHIKLMNOPRSTUY*30 1 1 0 1*Use the clues to solve this crossword and earn CyberSilver. If you have not played our crosswords before and want help, then click the HELP button. Have fun!"

    //Jim's New Dataset as at 03/01/97
    // "645*QX000000*0909*0 0 1 1#6 0 1 4#3 2 1 6#0 3 1 8#3 5 1 11#0 6 1 13#0 8 1 15#4 8 1 16#1 0 2 2#4 0 2 3#6 0 2 4#8 0 2 5#3 2 2 6#5 2 2 7#7 4 2 9#0 5 2 10#4 5 2 12#2 6 2 14*Bread maker#Skill#Receive#Calm#Real#Taunts#Apple _ _ _#Midday meal#Irritate#Wealthy#Queen,King,__ __ __#Ballet skirt#Book of maps#100 make a dollar#Conjuring#Cease#Prison room#Length of life*BAKER#ART#ACCEPT#SOOTHE#ACTUAL#TEASES#PIE#LUNCH#ANNOY#RICH#ACE#TUTU#ATLAS#CENTS#MAGIC#STOP#CELL#AGE*ABCEGHIKLMNOPRSTUY*30 1 1 0 1 5*Use the clues to solve this crossword and earn CyberSilver. If you have not played our crosswords before and want help, then click the HELP button. Have fun!"

    
    public sealed partial class CrosswordParser
    {
        
        #region Fields

        //Instance variables for holding parsed QuickCrossword data
        public string PuzzleType { get; set; }
        public int NumCols { get; set; }
        public int NumRows { get; set; }
        public int NumAcross { get; }
        public int NumDown { get; }
        public int PuzzleId { get; set; }
        public int[] ColRef { get; set; }
        public int[] RowRef { get; set; }
        public int[] IsAcross { get; set; }
        public int[] QuesNum { get; set; }
        public string[] SzClues { get; set; }
        public string[] SzAnswers { get; set; }

        public int[] Costs { get; } = { 0, 0, 0, 0, 0, 0 };

        public string SzGetLetters { get; set; }
        public string SzBlurb { get; set; }
        public int NumQuestions { get; set; }

        public int NumBytes { get; set; }

        #endregion


       
    }


}