//////////////////////////////////////////////////////////////////////////////
//                                                                          //
//      Module:     PuzzleData.cs                                           //
//      Authors:    Aaron Saikovski & Bryan Richards                        //
//      Date:       23/01/97                                                //
//      Version:    1.0                                                     //
//      Purpose:    Utilizes a String Tokenizer to parse the crossword      //
//                  puzzle components from a data set string.               //
//                                                                          //
//////////////////////////////////////////////////////////////////////////////


namespace CrosswordParser;

public sealed partial class PuzzleData
{
    #region Fields
    
    //Instance variables for holding parsed QuickCrossword data
    public string? PuzzleType { get; set; }
    public int NumCols { get; set; }
    public int NumRows { get; set; }
    public int NumAcross { get; set; }
    public int NumDown { get; set; }
    public int PuzzleId { get; set; }
    public int[]? ColRef { get; set; }
    public int[]? RowRef { get; set; }
    public int[]? IsAcross { get; set; }
    public int[]? QuesNum { get; set; }
    public string[]? Clues { get; set; }
    public string[]? Answers { get; set; }

    //public int[]? Costs { get; } = [0, 0, 0, 0, 0, 0];
    public int[]? Costs { get; set; }

    public string? GetLetters { get; set; }
    public string? Blurb { get; set; }
    public int NumQuestions { get; set; }

    public int NumBytes { get; set; }

    #endregion

}