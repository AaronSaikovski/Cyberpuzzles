using System.Linq;

namespace CyberPuzzles.Crossword.ClueAnswer;

public sealed partial class ClueAnswers
{
    #region IsCorrect

    public bool IsCorrect()
    {
        return !SzAnswer.Where((t, i) => SqAnswerSquares[i].ChLetter != t).Any();
    }

    #endregion
}