using Crossword.Puzzle.ClueAnswerMap;
using Crossword.Puzzle.Squares;
using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Crossword.UI.SmallFont;

#region IDrawSmallFont

/// <summary>
/// Small font drawing interface
/// </summary>
public interface IDrawSmallFont
{
    void DrawSmallFontAcross(ClueAnswer clueAnswer, Square puzzleSquare, Rectangle rectSquare,
        DynamicSpriteFont numFont, SpriteBatch spriteBatch);

    void DrawSmallFontDown(ClueAnswer clueAnswer, Square puzzleSquare, Rectangle rectSquare,
        DynamicSpriteFont numFont, SpriteBatch spriteBatch);
}
#endregion