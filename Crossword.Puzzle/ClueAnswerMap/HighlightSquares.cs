
using Crossword.Puzzle.Squares;
using Crossword.Shared.enums;

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

        if (Answer is null || SqAnswerSquares is null)
            return;

        // Use regular loop instead of Parallel.For (answer length is typically small)
        for (var i = 0; i < Answer.Length; i++)
        {
            if (!setHighLighted)
            {
                SqAnswerSquares[i]?.SetHighlighted((int)HighlightSquare.CurrentNone);
            }
            else
            {
                var highlightType = SqAnswerSquares[i] == sq
                    ? (int)HighlightSquare.CurrentLetter
                    : (int)HighlightSquare.CurrentWord;
                SqAnswerSquares[i]?.SetHighlighted(highlightType);
            }
        }
    }

    #endregion
}