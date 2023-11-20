////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:             Square.cs                                     //
//      Authors:            Aaron Saikovski & Bryan Richards              //
//      Original Date:      23/01/97                                      //
//      Version:            1.0                                           //
//      Purpose:           Defines a Square and it's attributes            //
//                                                                        //
////////////////////////////////////////////////////////////////////////////

using System;
using Microsoft.Xna.Framework;
using CyberPuzzles.Crossword.App.ClueAnswers;
using CyberPuzzles.Crossword.Constants;

namespace CyberPuzzles.Crossword.App.Squares;

//Square class
public sealed class Square 
{
    #region getters_setters
    
    public int xCoord { get; set; }
    public int yCoord { get; set; }
    
   
    public char Letter { get; set; }
    

    public Color ForeColour { get; set; } = Color.Black;
    public Color BackColour { get; set; } = Color.Black;

    public bool IsDirty { get; set; } = true;

    public bool IsCharAllowed { get; set; }

    public ClueAnswer? ClueAnswerAcross { get; set; }
    public ClueAnswer? ClueAnswerDown { get; set; }
    
    #endregion

    #region CreateSquare
    /// <summary>
    /// Allocates  memory for blank square
    /// </summary>
    /// <param name="xCoord"></param>
    /// <param name="yCoord"></param>
    public void CreateSquare(int xCoord, int yCoord){
        this.xCoord = xCoord;
        this.yCoord = yCoord;
    }
    
    #endregion

    #region SetObjectRef
    /// <summary>
    /// Set the object reference to clueanswer object
    /// </summary>
    /// <param name="isAcross"></param>
    /// <param name="clueAnswer"></param>
    public void SetObjectRef(bool isAcross, ClueAnswer clueAnswer){
        if (isAcross)
            ClueAnswerAcross = clueAnswer;
        else
            ClueAnswerDown = clueAnswer;

        IsCharAllowed = true;
        IsDirty = true;
        BackColour = Color.White;

    }
    #endregion

    #region SetHighlighted
    /// <summary>
    /// Sets the background colour of a square
    /// </summary>
    /// <param name="highlightType"></param>
    public void SetHighlighted(int highlightType){
        switch (highlightType) {
            case 1 : //Current Letter
                if (!BackColour.Equals(Color.Cyan)){
                    BackColour = Color.Cyan;
                    IsDirty = true;
                }
                break;
            case 2 : //Current Word
                if (!BackColour.Equals(Color.Yellow)){
                    BackColour = Color.Yellow;
                    IsDirty = true;
                }
                break;
            case 3 : //Current None
                if (!BackColour.Equals(Color.White)){
                    BackColour = Color.White;
                    IsDirty = true;
                }
                break;
            default : //Something went wrong....
                if (BackColour.Equals(Color.Red)){
                    Console.WriteLine($"Bogus color: {highlightType}");
                    BackColour = Color.Red;
                    IsDirty = true;
                }

                break;
            }

    }
    #endregion

    #region GetClueAnswerRef
    /// <summary>
    /// returns the Clue/Answer reference
    /// </summary>
    /// <param name="isAcross"></param>
    /// <returns></returns>
    public ClueAnswer? GetClueAnswerRef(bool isAcross)
    {
        return isAcross ? ClueAnswerAcross : ClueAnswerDown;
    }
    #endregion

    #region CanFlipDirection
    /// <summary>
    /// Can the current orientation be flipped.
    /// </summary>
    /// <param name="isAcross"></param>
    /// <returns></returns>
    public bool CanFlipDirection(bool isAcross)
    {
        switch (isAcross)
        {
            //if square is an intersection
            case true when ClueAnswerDown != null:
            case false when ClueAnswerAcross != null:
                return true;
            default:
                return false;
        }
    }
    #endregion

    #region CheckLetter
    /// <summary>
    /// Check for correctness of letter based on input char parameter and toggles colour accordingly
    /// </summary>
    /// <param name="correctLetter"></param>
    public void CheckLetter(char correctLetter)
    {
        if (Letter == ' ') return;
        ForeColour = Letter == correctLetter ? CwSettings.SqCorrect : CwSettings.SqError;
        IsDirty = true;
    }
    #endregion

    #region SetLetter
    /// <summary>
    /// Set the colour for a letter.
    /// </summary>
    /// <param name="letter"></param>
    /// <param name="isAcross"></param>
    public void SetLetter(char letter, bool isAcross){
        Letter = letter;
        IsDirty = true;
        ForeColour = Color.Black;
    }
    #endregion

    #region GetNextSq
    /// <summary>
    /// Gets the next available square
    /// </summary>
    /// <param name="isAcross"></param>
    /// <returns></returns>
    public Square GetNextSq(bool isAcross)
    {
        if (isAcross)
            return ClueAnswerAcross != null ? ClueAnswerAcross.GetNextSq(this) : this;
        return ClueAnswerDown != null ? ClueAnswerDown.GetNextSq(this) : this;
    }
   
    #endregion
    
    #region GetPrevSq
    /// <summary>
    /// /Gets the previous available square
    /// </summary>
    /// <param name="isAcross"></param>
    /// <returns></returns>
    public Square GetPrevSq(bool isAcross){
        if (isAcross)
            return ClueAnswerAcross != null ? ClueAnswerAcross.GetPrevSq(this) : this;
        else
            return ClueAnswerDown != null ? ClueAnswerDown.GetPrevSq(this) : this;
    }
    #endregion
    
}