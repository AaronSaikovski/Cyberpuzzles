using System;
using System.Threading.Tasks;

namespace Crossword.ClueAnswer;

public sealed partial class ClueAnswerMap
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
        if (Answer == null) return foundResult;
        var szAnswerLength = Answer.Length;

        //Parallel for loop
        Parallel.For(0, szAnswerLength, i =>
        {
            if (SqAnswerSquares == null || Answer[i] != hintLetter ||
                SqAnswerSquares[i]!.Letter == hintLetter) return;
            SqAnswerSquares[i]?.SetLetter(hintLetter, IsAcross);
            foundResult = true;
        });

        return foundResult;
    }

    #endregion
}