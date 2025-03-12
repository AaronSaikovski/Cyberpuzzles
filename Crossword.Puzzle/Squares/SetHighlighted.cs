
using Crossword.Shared.Constants;
using Color = Microsoft.Xna.Framework.Color;


namespace Crossword.Puzzle.Squares;

public sealed partial class Square
{
    #region SetHighlighted

    /// <summary>
    /// Sets the background colour of a square
    /// </summary>
    /// <param name="highlightType"></param>
    // public void SetHighlighted(int highlightType)
    // {
    //     switch (highlightType)
    //     {
    //         case 1: //Current Letter
    //             if (!BackColour.Equals(UiConstants.SquareHighlightCurrent))
    //             {
    //                 BackColour = UiConstants.SquareHighlightCurrent;
    //                 IsDirty = true;
    //             }
    //
    //             break;
    //         case 2: //Current Word
    //             if (!BackColour.Equals(UiConstants.SquareHighlightWord))
    //             {
    //                 BackColour = UiConstants.SquareHighlightWord;
    //                 IsDirty = true;
    //             }
    //
    //             break;
    //         case 3: //Current None
    //             if (!BackColour.Equals(UiConstants.SquareHighlightNone))
    //             {
    //                 BackColour = UiConstants.SquareHighlightNone;
    //                 IsDirty = true;
    //             }
    //
    //             break;
    //         default: //Something went wrong....
    //             if (BackColour.Equals(UiConstants.SquareHighlightErr))
    //             {
    //                 //Console.WriteLine($"Bogus color: {highlightType}");
    //                 BackColour = UiConstants.SquareHighlightErr;
    //                 IsDirty = true;
    //             }
    //
    //             break;
    //     }
    // }
    
    //AI generated Code
    public void SetHighlighted(int highlightType)
    {
        Color targetColor;
    
        switch (highlightType)
        {
            case 1: // Current Letter
                targetColor = UiConstants.SquareHighlightCurrent;
                break;
            case 2: // Current Word
                targetColor = UiConstants.SquareHighlightWord;
                break;
            case 3: // Current None
                targetColor = UiConstants.SquareHighlightNone;
                break;
            default: // Something went wrong....
                targetColor = UiConstants.SquareHighlightErr;
                break;
        }
    
        if (!BackColour.Equals(targetColor))
        {
            BackColour = targetColor;
            IsDirty = true;
        }
    }

    // public void SetHighlighted(HighlightSquare SquareHighlightType)
    // {
    //     HighlightSquareSelColour = SquareHighlightType;
    //     IsDirty = true;
    // }

    #endregion
}