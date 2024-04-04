using System;
using System.Threading.Tasks;

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
        if (Answer is null) return foundResult;
        var szAnswerLength = Answer.Length;

        //Parallel for loop
        Parallel.For(0, szAnswerLength, i =>
        {
            if (SqAnswerSquares is null || Answer[i] != hintLetter ||
                SqAnswerSquares[i]!.Letter == hintLetter) return;
            //SqAnswerSquares[i]?.SetLetter(hintLetter, IsAcross);
            SqAnswerSquares[i]?.SetLetter(hintLetter);
            foundResult = true;
        });

        return foundResult;
    }

    #endregion
}