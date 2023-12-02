using System;
using Crossword.PuzzleSquares;

namespace Crossword.ClueAnswer;

public sealed partial class ClueAnswerMap
{
    #region GetNextSq

    /// <summary>
    /// Returns the next square
    /// </summary>
    /// <param name="sq"></param>
    /// <returns></returns>
    public Square? GetNextSq(Square? sq)
    {
        ArgumentNullException.ThrowIfNull(sq);
        
        var i = 0;
        while (Answer is not null && i < Answer.Length)
        {
            if (SqAnswerSquares is not null && sq == SqAnswerSquares?[i])
                if (i < Answer.Length - 1)
                    return SqAnswerSquares?[i + 1];
            i++;
        }

        return sq;
    }

    #endregion
}