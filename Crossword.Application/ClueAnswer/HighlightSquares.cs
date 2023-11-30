using System;
using CyberPuzzles.Crossword.App.PuzzleSquares;
using CyberPuzzles.Shared.Constants;

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
        ArgumentNullException.ThrowIfNull(sq);
        
        if (Answer == null) return;
        for (var i = 0; i < Answer.Length; i++)
        {
            if (!setHighLighted)
                SqAnswerSquares?[i]?.SetHighlighted(CWSettings.nCURRENT_NONE);
            else
            {
                SqAnswerSquares?[i]
                    ?.SetHighlighted(SqAnswerSquares?[i] == sq
                        ? CWSettings.nCURRENT_LETTER
                        : CWSettings.nCURRENT_WORD);
            }
        }
    }

    #endregion
}