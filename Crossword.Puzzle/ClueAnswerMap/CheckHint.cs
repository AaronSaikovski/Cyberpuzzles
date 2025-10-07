
namespace Crossword.Puzzle.ClueAnswerMap;

public sealed partial class ClueAnswer
{
    #region CheckHint

    /// <summary>
    /// Sets the Hint letter if Get Letter is pressed
    /// </summary>
    /// <param name="hintLetter"></param>
    /// <returns></returns>
    public bool CheckHint(char hintLetter)
    {
        if (hintLetter <= 0) throw new ArgumentOutOfRangeException(nameof(hintLetter));

        var foundResult = false;

        // Assuming szAnswer and sqAnswerSquares are declared and initialized somewhere
        if (Answer is null || SqAnswerSquares is null)
            return foundResult;

        var szAnswerLength = Answer.Length;

        // Use regular loop instead of Parallel.For (answer length is typically small)
        for (var i = 0; i < szAnswerLength; i++)
        {
            if (Answer[i] == hintLetter && SqAnswerSquares[i]!.Letter != hintLetter)
            {
                SqAnswerSquares[i]?.SetLetter(hintLetter);
                foundResult = true;
            }
        }

        return foundResult;
    }

    #endregion
}