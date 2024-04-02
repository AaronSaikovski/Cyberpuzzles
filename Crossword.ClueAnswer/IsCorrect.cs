using System.Linq;

namespace Crossword.ClueAnswer;

public sealed partial class ClueAnswer
{
    #region IsCorrect

    /// <summary>
    /// Returns true if all answer letters are correct and false otherwise
    /// </summary>
    /// <returns></returns>
    public bool IsCorrect()
    {
        if (Answer is not null)
            return !Answer.Where((t, i) => SqAnswerSquares is not null && SqAnswerSquares[i]!.Letter != t).Any();
        return true;
    }

    #endregion
}