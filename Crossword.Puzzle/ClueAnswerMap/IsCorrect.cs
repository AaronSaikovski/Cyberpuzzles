
namespace Crossword.Puzzle.ClueAnswerMap;

public sealed partial class ClueAnswer
{
    #region IsCorrect

    /// <summary>
    /// Returns true if all answer letters are correct and false otherwise
    /// Optimized to use simple loop instead of LINQ to avoid allocations
    /// </summary>
    /// <returns></returns>
    public bool IsCorrect()
    {
        if (Answer is null || SqAnswerSquares is null)
            return true;

        // Simple loop - no LINQ allocations
        for (int i = 0; i < Answer.Length; i++)
        {
            if (SqAnswerSquares[i]?.Letter != Answer[i])
                return false;
        }
        return true;
    }

    #endregion
}