using System;
using Crossword.Puzzle.Squares;

namespace Crossword.Puzzle.ClueAnswerMap;

public sealed partial class ClueAnswer
{
    #region GetPrevSq

    /// <summary>
    /// Returns the previous square
    /// </summary>
    /// <param name="sq"></param>
    /// <returns></returns>
    public Square? GetPrevSq(Square? sq)
    {
        ArgumentNullException.ThrowIfNull(sq);
        
        if (Answer is null) return sq;
        var i = Answer.Length - 1;
        while (i > -1)
        {
            if (sq == SqAnswerSquares?[i]) return i != 0 ? SqAnswerSquares?[i - 1] : sq;
            i--;
        }

        return sq;
    }

    #endregion
}