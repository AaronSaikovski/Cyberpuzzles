// using Crossword.Puzzle.ClueAnswerMap;
// using Crossword.Puzzle.Squares;
// using Crossword.Shared.Constants;
// using FontStashSharp;
// using Microsoft.Xna.Framework;
// using Microsoft.Xna.Framework.Graphics;
//
// namespace Crossword.App;
//
// public class DrawFont : IDrawFont
// {
//     /// <summary>
//     /// Draws a small font across
//     /// </summary>
//     /// <param name="clueAnswer"></param>
//     /// <param name="puzzleSquare"></param>
//     /// <param name="rectSquare"></param>
//     /// <param name="numFont"></param>
//     /// <param name="spriteBatch"></param>
//     public void DrawSmallFontAcross(ClueAnswer clueAnswer, Square puzzleSquare, Rectangle rectSquare, DynamicSpriteFont numFont,
//         SpriteBatch spriteBatch)
//     {
//         if (puzzleSquare.ClueAnswerAcross is null) return;
//         if (puzzleSquare.ClueAnswerAcross?.SqAnswerSquares?[0] != puzzleSquare) return;
//         
//         spriteBatch.DrawString(numFont,
//             puzzleSquare.ClueAnswerAcross?.QuestionNumber.ToString(),
//             new Vector2(rectSquare.X + UiConstants.SmlNumOffsetX,
//                 rectSquare.Y + UiConstants.SmlNumOffsetY), UiConstants.SmallFontColor);
//     }
//
//     //Draws a small font down
//     public void DrawSmallFontDown(ClueAnswer clueAnswer, Square puzzleSquare, Rectangle rectSquare, DynamicSpriteFont numFont,
//         SpriteBatch spriteBatch)
//     {
//         if (puzzleSquare.ClueAnswerDown is null) return;
//         if (puzzleSquare.ClueAnswerDown?.SqAnswerSquares?[0] != puzzleSquare) return;
//         spriteBatch.DrawString(numFont,
//             puzzleSquare.ClueAnswerDown?.QuestionNumber.ToString(),
//             new Vector2(rectSquare.X + UiConstants.SmlNumOffsetX,
//                 rectSquare.Y + UiConstants.SmlNumOffsetY), UiConstants.SmallFontColor);
//     }
// }