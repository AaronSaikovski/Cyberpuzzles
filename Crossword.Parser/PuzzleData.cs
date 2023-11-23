//////////////////////////////////////////////////////////////////////////////
//                                                                          //
//      Module:     PuzzleData.cs                                      //
//      Authors:    Aaron Saikovski & Bryan Richards                        //
//      Date:       23/01/97                                                //
//      Version:    1.0                                                     //
//      Purpose:    Utilizes a String Tokenizer to parse the crossword      //
//                  puzzle components from a data set string.               //
//                                                                          //
//////////////////////////////////////////////////////////////////////////////


namespace CyberPuzzles.Crossword.Parser;

public sealed partial class PuzzleData
{
    #region Fields
    
    // public int CoordAcross { get; set; } = coordAcross;
    // public int CoordDown { get; set; } = coordDown;
    // public string Answer { get; set; } = answer;
    // public string Clue { get; set; } = clue;
    // public bool IsAcross { get; set; } = isAcross;
    // public int QuestionNum { get; set; } = questionNum;

    //Instance variables for holding parsed QuickCrossword data
    public string? PuzzleType { get; set; }
    public int NumCols { get; set; }
    public int NumRows { get; set; }
    public int NumAcross { get; }
    public int NumDown { get; }
    public int PuzzleId { get; set; }
    public int[]? ColRef { get; set; }
    public int[]? RowRef { get; set; }
    public int[]? IsAcross { get; set; }
    public int[]? QuesNum { get; set; }
    public string[]? Clues { get; set; }
    public string[]? Answers { get; set; }

    public int[]? Costs { get; } = [0, 0, 0, 0, 0, 0];

    public string? GetLetters { get; set; }
    public string? Blurb { get; set; }
    public int NumQuestions { get; set; }

    public int NumBytes { get; set; }

    #endregion

}