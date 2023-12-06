namespace Crossword.PuzzleState;

/// <summary>
/// CrosswordMain dataset to map clues to answers.
/// </summary>
/// <remarks>
/// constructor
/// </remarks>
/// <param name="coordAcross"></param>
/// <param name="coordDown"></param>
/// <param name="answer"></param>
/// <param name="clue"></param>
/// <param name="isAcross"></param>
/// <param name="questionNum"></param>
public sealed class PuzzleState(int coordAcross, int coordDown, string answer, string clue, bool isAcross, int questionNum)
{
    #region getters_setters
    // public int CoordAcross { get; set; } = coordAcross;
    // public int CoordDown { get; set; } = coordDown;
    // public string Answer { get; set; } = answer;
    // public string Clue { get; set; } = clue;
    // public bool IsAcross { get; set; } = isAcross;
    // public int QuestionNum { get; set; } = questionNum;

    public int CoordAcross { get;} = coordAcross;
    public int CoordDown { get;  } = coordDown;
    public string Answer { get;  } = answer;
    public string Clue { get;  } = clue;
    public bool IsAcross { get;  } = isAcross;
    public int QuestionNum { get; } = questionNum;
    
    #endregion
}