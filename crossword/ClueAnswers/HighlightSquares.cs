using CyberPuzzles.Crossword.Constants;
using CyberPuzzles.Crossword.Squares;

namespace CyberPuzzles.Crossword.ClueAnswer;

public sealed partial class ClueAnswers
{
    #region HighlightSquares

    public void HighlightSquares(Square sq, bool bSetHighLighted)
    {
        for (var i = 0; i < SzAnswer.Length; i++)
        {
            if (!bSetHighLighted)
                SqAnswerSquares[i].SetHighlighted(CwSettings.NCurrentNone);
            else
            {
                SqAnswerSquares[i].SetHighlighted(SqAnswerSquares[i] == sq
                    ? CwSettings.NCurrentLetter
                    : CwSettings.NCurrentWord);
            }
        }
    }

    #endregion
}