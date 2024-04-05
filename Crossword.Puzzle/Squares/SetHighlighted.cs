
using Crossword.Shared.Constants;
using Crossword.Shared.enums;

namespace Crossword.Puzzle.Squares;

public sealed partial class Square
{
    #region SetHighlighted

    /// <summary>
    /// Sets the background colour of a square
    /// </summary>
    /// <param name="highlightType"></param>
    public void SetHighlighted(int highlightType)
    {
        switch (highlightType)
        {
            case 1: //Current Letter
                if (!BackColour.Equals(UiConstants.SquareHighlightCurrent))
                {
                    BackColour = UiConstants.SquareHighlightCurrent;
                    IsDirty = true;
                }
    
                break;
            case 2: //Current Word
                if (!BackColour.Equals(UiConstants.SquareHighlightWord))
                {
                    BackColour = UiConstants.SquareHighlightWord;
                    IsDirty = true;
                }
    
                break;
            case 3: //Current None
                if (!BackColour.Equals(UiConstants.SquareHighlightNone))
                {
                    BackColour = UiConstants.SquareHighlightNone;
                    IsDirty = true;
                }
    
                break;
            default: //Something went wrong....
                if (BackColour.Equals(UiConstants.SquareHighlightErr))
                {
                    //Console.WriteLine($"Bogus color: {highlightType}");
                    BackColour = UiConstants.SquareHighlightErr;
                    IsDirty = true;
                }
    
                break;
        }
    }
    
    // public void SetHighlighted(HighlightSquare SquareHighlightType)
    // {
    //     HighlightSquareSelColour = SquareHighlightType;
    //     IsDirty = true;
    // }

    #endregion
}