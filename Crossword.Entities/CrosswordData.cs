
namespace Crossword.Entities;

public sealed class CrosswordData
{
    #region Fields
    
    //Instance variables for holding parsed QuickCrossword data
    public string? PuzzleType { get; set; }
    public int NumCols { get; set; }
    public int NumRows { get; set; }
    // public int NumAcross { get; set; }
    // public int NumDown { get; set; }
    
    public int NumAcross { get; }
    public int NumDown { get;  }
    public int PuzzleId { get; set; }
    public int[]? ColRef { get; set; }
    public int[]? RowRef { get; set; }
    public int[]? IsAcross { get; set; }
    public int[]? QuesNum { get; set; }
    public string[]? Clues { get; set; }
    public string[]? Answers { get; set; }
    
    //public int[]? Costs { get; set; }
    public int[]? Costs { get; }

    public string? GetLetters { get; set; }
    public string? Blurb { get; set; }
   
    public int NumQuestions { get; set; }

    public int NumBytes { get; set; }

    

    #endregion

}