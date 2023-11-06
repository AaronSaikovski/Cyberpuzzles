using CyberPuzzles.Crossword.Squares;

namespace CyberPuzzles.Crossword.ClueAnswer;

public sealed partial class ClueAnswers
{
    #region GetSquare

    public Square GetSquare()
    {
        return SqAnswerSquares[0];
    }

    #endregion

    #region GetNextPrevSquares

    public Square GetNextSq(Square sq)
    {
        var i = 0;
        while (i < SzAnswer.Length)
        {
            if (sq == SqAnswerSquares[i])
                if (i < SzAnswer.Length - 1)
                    return SqAnswerSquares[i + 1];
            i++;
        }

        return sq;
    }

    public Square GetPrevSq(Square sq)
    {
        var i = SzAnswer.Length - 1;
        while (i > -1)
        {
            if (sq == SqAnswerSquares[i])
                if (i != 0)
                {
                    return SqAnswerSquares[i - 1];
                }
                else
                {
                    return sq;
                }

            i--;
        }

        return sq;
    }

    #endregion
}