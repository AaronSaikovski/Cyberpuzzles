using System;
using CyberPuzzles.Shared;

namespace CyberPuzzles.Crossword.App.PuzzleSquares;

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
                if (!BackColour.Equals(Constants.SquareHighlightCurrent))
                {
                    BackColour = Constants.SquareHighlightCurrent;
                    IsDirty = true;
                }

                break;
            case 2: //Current Word
                if (!BackColour.Equals(Constants.SquareHighlightWord))
                {
                    BackColour = Constants.SquareHighlightWord;
                    IsDirty = true;
                }

                break;
            case 3: //Current None
                if (!BackColour.Equals(Constants.SquareHighlightNone))
                {
                    BackColour = Constants.SquareHighlightNone;
                    IsDirty = true;
                }

                break;
            default: //Something went wrong....
                if (BackColour.Equals(Constants.SquareHighlightErr))
                {
                    Console.WriteLine($"Bogus color: {highlightType}");
                    BackColour = Constants.SquareHighlightErr;
                    IsDirty = true;
                }

                break;
        }
    }

    #endregion
}