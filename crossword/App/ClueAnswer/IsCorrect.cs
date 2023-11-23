using System.Linq;

namespace CyberPuzzles.Crossword.App.ClueAnswer;

public sealed partial class ClueAnswerMap
{
    #region IsCorrect

    /// <summary>
    /// Returns true if all answer letters are correct and false otherwise
    /// </summary>
    /// <returns></returns>
    public bool IsCorrect()
    {
        if (Answer != null)
            return !Answer.Where((t, i) => SqAnswerSquares != null && SqAnswerSquares[i]!.Letter != t).Any();
        return true;
    }

    #endregion
}