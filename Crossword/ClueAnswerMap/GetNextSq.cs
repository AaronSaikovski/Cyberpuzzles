using System;
using Crossword.PuzzleSquares;

namespace Crossword.ClueAnswerMap;

public sealed partial class ClueAnswer
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
        while (Answer != null && i < Answer.Length){
            if (SqAnswerSquares != null && sq == SqAnswerSquares[i])
                if (i < Answer.Length - 1)
                    return SqAnswerSquares[i + 1];
            i++;
        }
        return sq;
        
        // ArgumentNullException.ThrowIfNull(sq);
        // var i = 0;
        // while (i < Answer.Length){
        //     if (sq == SqAnswerSquares[i])
        //         if (i < Answer.Length - 1)
        //             return SqAnswerSquares[i + 1];
        //     i++;
        // }
        // return sq;
    }

    #endregion
}