////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:     Square.java                                           //
//      Author:     Aaron Saikovski                                       //
//      Date:       23/01/97                                              //
//      Version:    1.0                                                   //
//      Purpose:    Defines a Square and it's attributes                  //
//                                                                        //
////////////////////////////////////////////////////////////////////////////

using System;
using Microsoft.Xna.Framework;
using CyberPuzzles.Crossword.App.ClueAnswers;
using CyberPuzzles.Crossword.Constants;

namespace CyberPuzzles.Crossword.App.Squares;



/*---------------------------------------------------------------*/

//Square class
public sealed class Square  {
    
    #region getters_setters
    
    public int nXCoord { get; set; }
    public int nYCoord { get; set; }
    
    //public int nXCharOffset { get; set; }
    
    //public int nYCharOffset { get; set; }
    
    public char chLetter { get; set; }
    
    //public char chNumber { get; set; }

    public Color clForeColour { get; set; } = Color.Black;
    public Color clBackColour { get; set; } = Color.Black;

    public bool bIsDirty { get; set; } = true;

    public bool bIsCharAllowed { get; set; }

    public ClueAnswer? clAcross { get; set; }
    public ClueAnswer? clDown { get; set; }
    
    #endregion
  
    /*---------------------------------------------------------------*/

    //Allocates graphics memory for blank square
    public void CreateSquare(int xCoord, int yCoord){
        nXCoord = xCoord;
        nYCoord = yCoord;
    }

    /*---------------------------------------------------------------*/

    //Checks to see if the current action occurs within a square.
    // public bool IsClickInsideMe(int nXMouseCoord, int nYMouseCoord){
    //     if((nXCoord + 1 <= nXMouseCoord) && (nXMouseCoord <= (nXCoord + (CwSettings.nSquareWidth) - 1))
    //             && (nYCoord +1 <= nYMouseCoord) && (nYMouseCoord <= (nYCoord + (CwSettings.nSquareHeight)) - 1))
    //         return true;
    //     else
    //         return false;
    // }

    /*---------------------------------------------------------------*/

    //Set the object reference to clueanswer object
    public void setObjectRef(bool bIsAcross, ClueAnswer cl){
        if (bIsAcross)
            clAcross = cl;
        else
            clDown = cl;

        bIsCharAllowed = true;
        bIsDirty = true;
        clBackColour = Color.White;

    }

    /*---------------------------------------------------------------*/

    //Sets the background colour of a square
    public void setHighlighted(int nHighlightType){
        switch (nHighlightType) {
            case 1 : //Current Letter
                if (!clBackColour.Equals(Color.Cyan)){
                    clBackColour = Color.Cyan;
                    bIsDirty = true;
                }
                break;
            case 2 : //Current Word
                if (!clBackColour.Equals(Color.Yellow)){
                    clBackColour = Color.Yellow;
                    bIsDirty = true;
                }
                break;
            case 3 : //Current None
                if (!clBackColour.Equals(Color.White)){
                    clBackColour = Color.White;
                    bIsDirty = true;
                }
                break;
            default : //Something went wrong....
                if (clBackColour.Equals(Color.Red)){
                    Console.WriteLine($"Bogus color: {nHighlightType}");
                    clBackColour = Color.Red;
                    bIsDirty = true;
                }

                break;
            }

    }

    /*---------------------------------------------------------------*/

    //returns the Clue/Answer reference
    public ClueAnswer? getClueAnswerRef(bool bIsAcross)
    {
        return bIsAcross ? clAcross : clDown;
        
        // if (bIsAcross)
        //     return clAcross;
        // else
        //     return clDown;
    }

    /*---------------------------------------------------------------*/

    //Can the current orientation be flipped.
    public bool CanFlipDirection(bool bIsAcross)
    {
        switch (bIsAcross)
        {
            //if square is an intersection
            case true when clDown != null:
            case false when clAcross != null:
                return true;
            default:
                return false;
        }
        
        // if ((bIsAcross) && (clDown != null))
        //     return true;
        // else if ((!bIsAcross) && (clAcross != null))
        //     return true;
        // else
        //     return false;
    }

    /*---------------------------------------------------------------*/

    //Check for correctness of letter based on input char parameter and toggles colour accordingly
    public void checkLetter(char chCorrectLetter)
    {
        if (chLetter == ' ') return;
        clForeColour = chLetter == chCorrectLetter ? CwSettings.SqCorrect : CwSettings.SqError;
        bIsDirty = true;
        
        // if(chLetter != ' '){
        //     if(chLetter == chCorrectLetter)
        //         clForeColour = Color.Green;
        //     else
        //         clForeColour = Color.Red;
        //
        //     bIsDirty = true;
        // }
    }

    /*---------------------------------------------------------------*/

    //Set the colour for a letter.
    //
    ////Set the colour for a letter..based also on assistant state
    //public void setLetter(char ch, boolean bIsAcross, boolean bIsAssistantOn){
    public void setLetter(char ch, bool bIsAcross){
        chLetter = ch;
        bIsDirty = true;
        clForeColour = Color.Black;
        // if (bIsAcross) {
        //     // if (clAcross.getChar(this).Equals(char.ToUpper(chLetter)))
        //     // {
        //     //     clForeColour = Color.Black;
        //     // }
        //     //
        //     // else {
        //     //     clForeColour = Color.Black;
        //     // }
        //     clForeColour = Color.Black;
        //
        // }
        // else {
        //
        //     // if (clDown.getChar(this).Equals(char.ToUpper(chLetter)))
        //     // {
        //     //     clForeColour = Color.Black;
        //     // }
        //     // else {
        //     //     clForeColour = Color.Black;
        //     // }
        //     clForeColour = Color.Black;
        // }

    }

    /*---------------------------------------------------------------*/

    //Gets the next available square
    public Square getNextsq(bool bIsAcross)
    {
        if (bIsAcross)
            return clAcross != null ? clAcross.GetNextsq(this) : this;
        return clDown != null ? clDown.GetNextsq(this) : this;

        // if (bIsAcross)
        //     if(clAcross != null)
        //         return clAcross.getNextsq(this);
        //     else
        //         return this;
        // else
        // if(clDown != null)
        //     return clDown.getNextsq(this);
        // else
        //     return this;
    }

    /*---------------------------------------------------------------*/

    //Gets the previous available square
    public Square getPrevsq(bool bIsAcross){
        if (bIsAcross)
            return clAcross != null ? clAcross.GetPrevsq(this) : this;
        else
            return clDown != null ? clDown.GetPrevsq(this) : this;
        
        // if (bIsAcross)
        //     if(clAcross != null)
        //         return clAcross.getPrevsq(this);
        //     else
        //         return this;
        // else
        // if(clDown != null)
        //     return clDown.getPrevsq(this);
        // else
        //     return this;
    }

    /*---------------------------------------------------------------*/

    //Returns boolean true/false based on square's contents
    public bool isPopulated()
    {
        return chLetter != ' ';
        
        // if (chLetter == ' '){
        //     return false;
        // }
        // else{
        //     return true;
        // }
    }

    /*---------------------------------------------------------------*/

}

