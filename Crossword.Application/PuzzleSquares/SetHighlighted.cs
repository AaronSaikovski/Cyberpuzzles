using System;
using Crossword.Shared.Constants;

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
                if (!BackColour.Equals(CWSettings.SquareHighlightCurrent))
                {
                    BackColour = CWSettings.SquareHighlightCurrent;
                    IsDirty = true;
                }

                break;
            case 2: //Current Word
                if (!BackColour.Equals(CWSettings.SquareHighlightWord))
                {
                    BackColour = CWSettings.SquareHighlightWord;
                    IsDirty = true;
                }

                break;
            case 3: //Current None
                if (!BackColour.Equals(CWSettings.SquareHighlightNone))
                {
                    BackColour = CWSettings.SquareHighlightNone;
                    IsDirty = true;
                }

                break;
            default: //Something went wrong....
                if (BackColour.Equals(CWSettings.SquareHighlightErr))
                {
                    Console.WriteLine($"Bogus color: {highlightType}");
                    BackColour = CWSettings.SquareHighlightErr;
                    IsDirty = true;
                }

                break;
        }
    }

    #endregion
}