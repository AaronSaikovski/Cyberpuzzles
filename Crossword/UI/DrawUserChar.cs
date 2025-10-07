using System;
using Crossword.Shared.Constants;
using FontStashSharp;
using Microsoft.Xna.Framework;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region DrawUserChar

    /// <summary>
    /// Draws char entered by user - optimized to avoid string allocations
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    private void DrawUserChar(int i, int j)
    {
        //check for null
        if (_puzzleSquares is null || _sqPuzzleSquares is null || _fntFont is null)
            return;

        // Use cached character string to avoid ToString() allocation
        var charUpper = char.ToUpper(_sqPuzzleSquares[i, j].Letter);
        var charIndex = charUpper - 'A';

        if (charIndex >= 0 && charIndex < 26)
        {
            _spriteBatch!.DrawString(_fntFont, _charCache[charIndex],
                new Vector2(_puzzleSquares[i, j].X + UiConstants.SqCharOffsetX,
                    _puzzleSquares[i, j].Y + UiConstants.SqCharOffsetY),
                _sqPuzzleSquares[i, j].ForeColour);
        }
    }

    #endregion
}