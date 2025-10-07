
using Crossword.Puzzle.Squares;

namespace Crossword.Puzzle.ClueAnswerMap;

public sealed partial class ClueAnswer
{
    #region SetObjectRef

    /// <summary>
    /// Sets the object reference.
    /// </summary>
    /// <param name="answer"></param>
    /// <param name="clue"></param>
    /// <param name="questionNumber"></param>
    /// <param name="isAcross"></param>
    /// <param name="SqAnswerSquares"></param>
    public void SetObjectRef(string answer, string clue, int questionNumber,
        bool isAcross, Square?[] SqAnswerSquares)
    {
        ArgumentNullException.ThrowIfNull(answer);
        ArgumentNullException.ThrowIfNull(clue);
        ArgumentNullException.ThrowIfNull(SqAnswerSquares);

        this.Answer = answer;
        this.Clue = clue;
        this.QuestionNumber = questionNumber;
        this.IsAcross = isAcross;

        //Initialise the answer squares array.
        this.SqAnswerSquares = new Square[answer.Length];

        //Copy the array
        var szAnswerLength = answer.Length;

        // Use regular loop instead of Parallel.For (answer length is typically small)
        for (var k = 0; k < szAnswerLength; k++)
        {
            this.SqAnswerSquares[k] = SqAnswerSquares[k];
            SqAnswerSquares[k]?.SetObjectRef(this.IsAcross, this);
        }
    }

    #endregion
}