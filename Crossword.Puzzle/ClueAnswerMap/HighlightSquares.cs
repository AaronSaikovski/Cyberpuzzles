
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

        if (Answer is null) return;
        

        Parallel.For(0, Answer.Length, i =>
        {
            if (!setHighLighted)
                SqAnswerSquares?[i]?.SetHighlighted((int)HighlightSquare.CurrentNone);
            else
            {
                SqAnswerSquares?[i]
                    ?.SetHighlighted(SqAnswerSquares?[i] == sq
                        ? (int)HighlightSquare.CurrentLetter
                        : (int)HighlightSquare.CurrentWord);
            }
        });


    }

    #endregion
}