using Crossword.Shared.Constants;

namespace Crossword.Puzzle.Squares;

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
        ForeColour = UIConstants.SquareHighlightDefault;
    }

    #endregion
}