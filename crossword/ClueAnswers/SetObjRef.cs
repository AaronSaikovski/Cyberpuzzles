using System;
using CyberPuzzles.Crossword.Squares;

namespace CyberPuzzles.Crossword.ClueAnswer;

public sealed partial class ClueAnswers
{
    #region SetObjectRef

    public void SetObjectRef(string szAnswer, string szClue, int questionNumber,
        bool bIsAcross, Square[] sqAnswerSquares)
    {
        SzAnswer = szAnswer;
        SzClue = szClue;
        QuestionNumber = questionNumber;
        BIsAcross = bIsAcross;

        //Initialise the answer squares array.
        SqAnswerSquares = new Square[szAnswer.Length];

        try
        {
            for (var i = 0; i < szAnswer.Length; i++)
            {
                SqAnswerSquares[i] = new Square();
                SqAnswerSquares[i].CreateSquare(0, 0);

                //Copy the array
                SqAnswerSquares[i] = sqAnswerSquares[i];

                //setup reference pointers back to me for each square
                sqAnswerSquares[i].SetObjectRef(BIsAcross, this);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception {e}occurred in method setObjectRef");
        }
    }

    #endregion
}