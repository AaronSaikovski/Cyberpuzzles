using CyberPuzzles.Shared;

namespace CyberPuzzles.Crossword.App.PuzzleSquares;

public sealed partial class Square
{
    #region CheckLetter

    /// <summary>
    /// Check for correctness of letter based on input char parameter and toggles colour accordingly
    /// </summary>
    /// <param name="correctLetter"></param>
    public void CheckLetter(char correctLetter)
    {
        if (Letter == ' ') return;
        ForeColour = Letter == correctLetter ? Constants.SqCorrect : Constants.SqError;
        IsDirty = true;
    }

    #endregion
}