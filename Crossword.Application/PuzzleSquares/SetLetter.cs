using Crossword.Shared.Constants;

namespace CyberPuzzles.Crossword.App.PuzzleSquares;

public sealed partial class Square
{
    #region SetLetter

    /// <summary>
    /// Set the colour for a letter.
    /// </summary>
    /// <param name="letter"></param>
    /// <param name="isAcross"></param>
    public void SetLetter(char letter, bool isAcross)
    {
        Letter = letter;
        IsDirty = true;
        ForeColour = CWSettings.SquareHighlightDefault;
    }

    #endregion
}