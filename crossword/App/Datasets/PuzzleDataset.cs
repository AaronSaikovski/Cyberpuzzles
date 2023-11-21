namespace CyberPuzzles.Crossword.App.Datasets;

/// <summary>
/// Crossword dataset to map clues to answers.
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
public sealed class PuzzleDataset(int coordAcross, int coordDown, string answer, string clue, bool isAcross, int questionNum)
{
    #region getters_setters
    public int CoordAcross { get; set; } = coordAcross;
    public int CoordDown { get; set; } = coordDown;
    public string Answer { get; set; } = answer;
    public string Clue { get; set; } = clue;
    public bool IsAcross { get; set; } = isAcross;
    public int QuestionNum { get; set; } = questionNum;

    #endregion
}