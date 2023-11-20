////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:             ClueAnswer.cs                                 //
//      Authors:            Aaron Saikovski & Bryan Richards              //
//      Original Date:      26/02/97                                      //
//      Version:            1.0                                           //
//      Purpose:            Clue + Answer references class                //
//                                                                        //
////////////////////////////////////////////////////////////////////////////

using System;
using System.Linq;
using System.Threading.Tasks;
using CyberPuzzles.Crossword.Constants;
using CyberPuzzles.Crossword.App.Squares;

namespace CyberPuzzles.Crossword.App.ClueAnswers;

/// <summary>
/// ClueAnswer Class
/// </summary>
public sealed class ClueAnswer 
{
    #region getters_setters

    public string? Answer { get; set; }
    public string? Clue { get; set; }
    
    public int QuestionNumber { get; set; }

    public bool IsAcross { get; set; } = true;
    
    public Square[]? SqAnswerSquares { get; set; }
    
    #endregion
    

    #region HighlightSquares
    /// <summary>
    /// /Highlights the current word and sets active square
    /// </summary>
    /// <param name="sq"></param>
    /// <param name="setHighLighted"></param>
    public void HighlightSquares(Square sq, bool setHighLighted)
    {
        if (Answer == null) return;
        for (var i = 0; i < Answer.Length; i++)
        {
            if (!setHighLighted)
                SqAnswerSquares?[i].SetHighlighted(CwSettings.nCURRENT_NONE);
            else
            {
                SqAnswerSquares?[i].SetHighlighted(SqAnswerSquares?[i] == sq
                    ? CwSettings.nCURRENT_LETTER
                    : CwSettings.nCURRENT_WORD);
            }
        }
    }
    #endregion

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
                                bool IsAcross, Square[] SqAnswerSquares)
    {

        this.Answer = Answer;
        this.Clue = Clue;
        this.QuestionNumber = QuestionNumber;
        this.IsAcross = IsAcross;

        //Initialise the answer squares array.
        this.SqAnswerSquares = new Square[Answer.Length];
        
        //Copy the array
        try {
            
            // Assuming szAnswer and sqAnswerSquares are declared and initialized somewhere
            int szAnswerLength = Answer.Length;

            //Parallel for loop
            Parallel.For(0, szAnswerLength, k =>
            {
                // Create a new Square instance
                this.SqAnswerSquares[k] = new Square();
                this.SqAnswerSquares[k].CreateSquare(0, 0);
                this.SqAnswerSquares[k] = SqAnswerSquares[k];

                // Assign the created Square to the array element
                // The original code `this.sqAnswerSquares[k] = sqAnswerSquares[k];` seems redundant, so omitted
                SqAnswerSquares[k].SetObjectRef(this.IsAcross, this);
            });
        }
        catch (Exception e) {
            Console.WriteLine("Exception " + e + "occurred in method setObjectRef");
        }
    }
    #endregion

    #region GetSquare
    /// <summary>
    /// Gets the first square referenced by my answer.
    /// </summary>
    /// <returns></returns>
    public Square GetSquare()
    {
        return SqAnswerSquares?[0];
    }
    #endregion

    #region GetNextSq
    /// <summary>
    /// Returns the next square
    /// </summary>
    /// <param name="sq"></param>
    /// <returns></returns>
    public Square GetNextSq(Square sq)
    {
        var i = 0;
        while (Answer != null && i < Answer.Length){
            if (sq == SqAnswerSquares?[i])
                if (i < Answer.Length - 1)
                    return SqAnswerSquares[i + 1];
            i++;
        }
        return sq;

    }
    #endregion

    #region GetPrevSq
    /// <summary>
    /// Returns the previous square
    /// </summary>
    /// <param name="sq"></param>
    /// <returns></returns>
    public Square GetPrevSq(Square sq)
    {
        if (Answer == null) return sq;
        var i = (Answer.Length -1);
        while (i > -1){
            if (sq == SqAnswerSquares?[i]) return i != 0 ? SqAnswerSquares[i - 1] : sq;
            i--;
        }

        return sq;
    }
    #endregion

    #region IsCorrect
    /// <summary>
    /// Returns true if all answer letters are correct and false otherwise
    /// </summary>
    /// <returns></returns>
    public bool IsCorrect()
    {
        if (Answer != null) return !Answer.Where((t, i) => SqAnswerSquares != null && SqAnswerSquares[i].Letter != t).Any();
        return true;
    }
    #endregion

    #region CheckHint
    /// <summary>
    /// Sets the Hint letter if Get Letter is pressed
    /// </summary>
    /// <param name="hintLetter"></param>
    /// <returns></returns>
    public bool CheckHint(char hintLetter){
        if (hintLetter <= 0) throw new ArgumentOutOfRangeException(nameof(hintLetter));
        var foundResult = false;
        
        // Assuming szAnswer and sqAnswerSquares are declared and initialized somewhere
        int szAnswerLength = Answer.Length;

        //Parallel for loop
        Parallel.For(0, szAnswerLength, i =>
        {
            if (SqAnswerSquares != null && (Answer[i] == hintLetter) && (SqAnswerSquares[i].Letter != hintLetter))
            {
                SqAnswerSquares[i].SetLetter(hintLetter, IsAcross);
                foundResult = true;
            }
        });

        return foundResult;
    }
    #endregion

    #region CheckWord
    /// <summary>
    /// Sets the letter colour if Check words is pressed.
    /// </summary>
    public void CheckWord()
    {
        if (Answer == null) return;
        for (var i = 0; i < Answer.Length; i++)
            SqAnswerSquares?[i].CheckLetter(Answer[i]);
    }
    #endregion
    
}