namespace Crossword.Entities;

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
public sealed class CrosswordState(int coordAcross, int coordDown, string answer, string clue, bool isAcross, int questionNum)
{
    #region getters_setters

    public int CoordAcross { get;} = coordAcross;
    public int CoordDown { get;  } = coordDown;
    public string Answer { get;  } = answer;
    public string Clue { get;  } = clue;
    public bool IsAcross { get;  } = isAcross;
    public int QuestionNum { get; } = questionNum;
    
    #endregion
}