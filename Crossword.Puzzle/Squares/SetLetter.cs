using Crossword.Shared.Constants;

namespace Crossword.Puzzle.Squares;

public sealed partial class Square
{
    #region SetLetter


    // public void SetLetter(char letter, bool isAcross)
    // {
    //     Letter = letter;
    //     IsDirty = true;
    //     ForeColour = UIConstants.SquareHighlightDefault;
    // }

    /// <summary>
    /// Set the colour for a letter.
    /// </summary>
    /// <param name="letter"></param>
    public void SetLetter(char letter)
    {
        Letter = letter;
        IsDirty = true;
        ForeColour = UiConstants.SquareHighlightDefault;
    }

    #endregion
}