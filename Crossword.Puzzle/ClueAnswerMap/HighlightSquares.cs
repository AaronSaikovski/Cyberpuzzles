
using Crossword.Puzzle.Squares;
using Crossword.Shared.Constants;

namespace Crossword.Puzzle.ClueAnswerMap;

public sealed partial class ClueAnswer
{
    #region HighlightSquares

    /// <summary>
    /// /Highlights the current word and sets active square
    /// </summary>
    /// <param name="sq"></param>
    /// <param name="setHighLighted"></param>
    public void HighlightSquares(Square? sq, bool setHighLighted)
    {
        ArgumentNullException.ThrowIfNull(sq);

        if (Answer is null) return;
        // for (var i = 0; i < Answer.Length; i++)
        // {
        //     if (!setHighLighted)
        //         SqAnswerSquares?[i]?.SetHighlighted(CWSettings.CurrentNone);
        //     else
        //     {
        //         SqAnswerSquares?[i]
        //             ?.SetHighlighted(SqAnswerSquares?[i] == sq
        //                 ? CWSettings.CurrentLetter
        //                 : CWSettings.CurrentWord);
        //     }
        // }

        Parallel.For(0, Answer.Length, i =>
        {
            if (!setHighLighted)
                SqAnswerSquares?[i]?.SetHighlighted(UiConstants.CurrentNone);
            else
            {
                SqAnswerSquares?[i]
                ?.SetHighlighted(SqAnswerSquares?[i] == sq
                ? UiConstants.CurrentLetter
                : UiConstants.CurrentWord);
            }
        });
    }

    #endregion
}