using System;
using Crossword.Shared.Constants;

namespace Crossword.Square;

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
                if (!BackColour.Equals(UIConstants.SquareHighlightCurrent))
                {
                    BackColour = UIConstants.SquareHighlightCurrent;
                    IsDirty = true;
                }

                break;
            case 2: //Current Word
                if (!BackColour.Equals(UIConstants.SquareHighlightWord))
                {
                    BackColour = UIConstants.SquareHighlightWord;
                    IsDirty = true;
                }

                break;
            case 3: //Current None
                if (!BackColour.Equals(UIConstants.SquareHighlightNone))
                {
                    BackColour = UIConstants.SquareHighlightNone;
                    IsDirty = true;
                }

                break;
            default: //Something went wrong....
                if (BackColour.Equals(UIConstants.SquareHighlightErr))
                {
                    Console.WriteLine($"Bogus color: {highlightType}");
                    BackColour = UIConstants.SquareHighlightErr;
                    IsDirty = true;
                }

                break;
        }
    }

    #endregion
}