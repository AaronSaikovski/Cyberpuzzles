using System.Threading.Tasks;

namespace Crossword.ClueAnswerMap;

public sealed partial class ClueAnswer
{
    #region CheckWord

    /// <summary>
    /// Sets the letter colour if Check words is pressed.
    /// </summary>
    public void CheckWord()
    {
        if (Answer is null) return;
<<<<<<< HEAD:Crossword/ClueAnswerMap/CheckWord.cs
        // for (var i = 0; i < Answer.Length; i++)
        // {
        //     SqAnswerSquares?[i]?.CheckLetter(Answer[i]);
        // }

        Parallel.For(0, Answer.Length, i =>
=======
        for (var i = 0; i < Answer.Length; i++)
>>>>>>> main:Crossword/ClueAnswer/CheckWord.cs
        {
            SqAnswerSquares?[i]?.CheckLetter(Answer[i]);
        }


        // Parallel.For(0, Answer.Length, i =>
        // {
        //     SqAnswerSquares?[i]?.CheckLetter(Answer[i]);
        // });
    }

    #endregion
}