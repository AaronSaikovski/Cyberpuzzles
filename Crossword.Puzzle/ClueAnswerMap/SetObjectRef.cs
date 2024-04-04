using System;
using System.Threading.Tasks;
using Crossword.Puzzle.Squares;

namespace Crossword.Puzzle.ClueAnswerMap;

public sealed partial class ClueAnswer
{
    #region SetObjectRef

    /// <summary>
    /// Sets the object reference.
    /// </summary>
    /// <param name="Answer"></param>
    /// <param name="Clue"></param>
    /// <param name="QuestionNumber"></param>
    /// <param name="IsAcross"></param>
    /// <param name="SqAnswerSquares"></param>
    public void SetObjectRef(string Answer, string Clue, int QuestionNumber,
        bool IsAcross, Square?[]? SqAnswerSquares)
    {
        ArgumentNullException.ThrowIfNull(Answer);
        ArgumentNullException.ThrowIfNull(Clue);
        ArgumentNullException.ThrowIfNull(SqAnswerSquares);

        this.Answer = Answer;
        this.Clue = Clue;
        this.QuestionNumber = QuestionNumber;
        this.IsAcross = IsAcross;

        //Initialise the answer squares array.
        this.SqAnswerSquares = new Square[Answer.Length];

        //Copy the array
        // Assuming szAnswer and sqAnswerSquares are declared and initialized somewhere
        var szAnswerLength = Answer.Length;

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
            if (SqAnswerSquares is not null) SqAnswerSquares?[k]?.SetObjectRef(this.IsAcross, this);
        });
    }

    #endregion
}