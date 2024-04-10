
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
        // Assuming szAnswer and sqAnswerSquares are declared and initialized somewhere
        var szAnswerLength = answer.Length;

        //Parallel for loop
        Parallel.For(0, szAnswerLength, k =>
        {
            // Create a new Square instance
            var sqAnswerSquares = this.SqAnswerSquares;
            if (sqAnswerSquares is not null)
            {
                sqAnswerSquares[k] = new Square();
                sqAnswerSquares[k]?.CreateSquare(0, 0);
                sqAnswerSquares[k] = SqAnswerSquares[k];
            }

            // Assign the created Square to the array element
            // The original code `this.sqAnswerSquares[k] = sqAnswerSquares[k];` seems redundant, so omitted
            SqAnswerSquares[k]?.SetObjectRef(this.IsAcross, this);
        });
    }

    #endregion
}