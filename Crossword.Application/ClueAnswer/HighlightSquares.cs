using CyberPuzzles.Crossword.App.PuzzleSquares;
using CyberPuzzles.Shared;

namespace CyberPuzzles.Crossword.App.ClueAnswer;

public sealed partial class ClueAnswerMap
{
    #region HighlightSquares

    /// <summary>
    /// /Highlights the current word and sets active square
    /// </summary>
    /// <param name="sq"></param>
    /// <param name="setHighLighted"></param>
    public void HighlightSquares(Square? sq, bool setHighLighted)
    {
        if (Answer == null) return;
        for (var i = 0; i < Answer.Length; i++)
        {
            if (!setHighLighted)
                SqAnswerSquares?[i]?.SetHighlighted(Constants.nCURRENT_NONE);
            else
            {
                SqAnswerSquares?[i]
                    ?.SetHighlighted(SqAnswerSquares?[i] == sq
                        ? Constants.nCURRENT_LETTER
                        : Constants.nCURRENT_WORD);
            }
        }
    }

    #endregion
}