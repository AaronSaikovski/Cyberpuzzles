using CyberPuzzles.Crossword.App.PuzzleSquares;
using CyberPuzzles.Crossword.Constants;

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
                SqAnswerSquares?[i]?.SetHighlighted(CwSettings.nCURRENT_NONE);
            else
            {
                SqAnswerSquares?[i]
                    ?.SetHighlighted(SqAnswerSquares?[i] == sq
                        ? CwSettings.nCURRENT_LETTER
                        : CwSettings.nCURRENT_WORD);
            }
        }
    }

    #endregion
}