namespace CyberPuzzles.Crossword.App.Datasets;

/// <summary>
/// Crossword dataset to map clues to answers.
/// </summary>
public sealed class PuzzleDataset
{
    public int CoordAcross { get; set; }
    public int CoordDown { get; set; }
    public string Answer { get; set; } 
    public string Clue{ get; set; }
    public bool IsAcross { get; set; }
    public int QuestionNum { get; set; }

    
    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="coordAcross"></param>
    /// <param name="coordDown"></param>
    /// <param name="answer"></param>
    /// <param name="clue"></param>
    /// <param name="isAcross"></param>
    /// <param name="questionNum"></param>
    public PuzzleDataset(int coordAcross,int coordDown,string answer,string clue, bool isAcross,int questionNum)
    {
        CoordAcross = coordAcross;
        CoordDown = coordDown;
        Answer = answer;
        Clue = clue;
        IsAcross = isAcross;
        QuestionNum = questionNum;
    }
}