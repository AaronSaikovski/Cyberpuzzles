using System;
using CyberPuzzles.Crossword.Constants;
using Microsoft.Xna.Framework;

namespace CyberPuzzles.Crossword.App;

////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:     Square.java                                           //
//      Author:     Aaron Saikovski                                       //
//      Date:       23/01/97                                              //
//      Version:    1.0                                                   //
//      Purpose:    Defines a Square and it's attributes                  //
//                                                                        //
////////////////////////////////////////////////////////////////////////////

/*---------------------------------------------------------------*/

//Square class
public class Square  {
    public int nXCoord= 0 , nYCoord = 0, nXCharOffset = 0, nYCharOffset = 0;

    //implement wrapper functions to get these variables
    public char chLetter = ' ';
    public char chNumber = ' ';
    public Color clForeColour = Color.Black;
    public Color clBackColour = Color.Black;
    public bool bIsDirty = true, bIsCharAllowed = false;
    public ClueAnswer clAcross = null, clDown = null;

    //private final static int i = QuickCrossword.nCURRENT_LETTER;

    /*---------------------------------------------------------------*/

    //Square Constructor
    public Square() {
    }

    /*---------------------------------------------------------------*/

    //Allocates graphics memory for blank square
    public void CreateSquare(int nXCoord, int nYCoord){
        this.nXCoord = nXCoord;
        this.nYCoord = nYCoord;
    }

    /*---------------------------------------------------------------*/

    //Checks to see if the current action occurs within a square.
    public bool IsClickInsideMe(int nXMouseCoord, int nYMouseCoord){
        if((nXCoord + 1 <= nXMouseCoord) && (nXMouseCoord <= (nXCoord + (CwSettings.nSquareWidth) - 1))
                && (nYCoord +1 <= nYMouseCoord) && (nYMouseCoord <= (nYCoord + (CwSettings.nSquareHeight)) - 1))
            return true;
        else
            return false;
    }

    /*---------------------------------------------------------------*/

    //Set the object reference to clueanswer object
    public void setObjectRef(bool bIsAcross, ClueAnswer cl){
        if (bIsAcross)
            this.clAcross = cl;
        else
            this.clDown = cl;

        bIsCharAllowed = true;
        bIsDirty = true;
        clBackColour = Color.White;

    }

    /*---------------------------------------------------------------*/

    //Sets the background colour of a square
    public void setHighlighted(int nHighlightType){
        switch (nHighlightType) {
        case 1 : //Current Letter
            if (!this.clBackColour.Equals(Color.Cyan)){
                this.clBackColour = Color.Cyan;
                bIsDirty = true;
            }
            break;
        case 2 : //Current Word
            if (!this.clBackColour.Equals(Color.Yellow)){
                this.clBackColour = Color.Yellow;
                bIsDirty = true;
            }
            break;
        case 3 : //Current None
            if (!this.clBackColour.Equals(Color.White)){
                this.clBackColour = Color.White;
                bIsDirty = true;
            }
            break;
        default : //Something went wrong....
            if (!this.clBackColour.Equals(Color.Red)){
                Console.WriteLine("Bogus color: " + nHighlightType);
                this.clBackColour = Color.Red;
                bIsDirty = true;
            }

            break;
        }

    }

    /*---------------------------------------------------------------*/

    //returns the Clue/Answer reference
    public ClueAnswer getClueAnswerRef(bool bIsAcross){
        if (bIsAcross)
            return clAcross;
        else
            return clDown;
    }

    /*---------------------------------------------------------------*/

    //Can the current orientation be flipped.
    public bool CanFlipDirection(bool bIsAcross){
        //if square is an intersection
        if ((bIsAcross) && (clDown != null))
            return true;
        else if ((!bIsAcross) && (clAcross != null))
            return true;
        else
            return false;
    }

    /*---------------------------------------------------------------*/

    //Check for correctness of letter based on input char parameter and toggles colour accordingly
    public void checkLetter(char chCorrectLetter){
        if(chLetter != ' '){
            if(chLetter == chCorrectLetter)
                clForeColour = Color.Green;
            else
                clForeColour = Color.Red;

            bIsDirty = true;
        }
    }

    /*---------------------------------------------------------------*/

    //Set the colour for a letter.
    //
    ////Set the colour for a letter..based also on assistant state
    //public void setLetter(char ch, boolean bIsAcross, boolean bIsAssistantOn){
    public void setLetter(char ch, bool bIsAcross){
        chLetter = ch;
        bIsDirty = true;

        if (bIsAcross) {
            if (clAcross.getChar(this).Equals(char.ToUpper(chLetter)))
            {
                
            //if (String.valueOf((char)clAcross.getChar(this)).equals(String.valueOf((char)chLetter).toUpperCase())){
                //If assistant is On then set correct colour to Green
                //if (bIsAssistantOn) {
                //    clForeColour = Color.green;
                //}
                //else {
                    clForeColour = Color.Black;
                //}

            }

            else {
                //if (bIsAssistantOn) {
                //    clForeColour = Color.red;
                //}
                //else {
                    clForeColour = Color.Black;
                //}
            }

        }
        else {

            if (clDown.getChar(this).Equals(char.ToUpper(chLetter)))
            {
                
                
            //if (String.valueOf((char)clDown.getChar(this)).equals(String.valueOf((char)chLetter).toUpperCase())){

                //If assistant is On then set correct colour to Green
                /*if (bIsAssistantOn) {
                    clForeColour = Color.green;
                }*/
                //else{
                    clForeColour = Color.Black;
                //}
            }
            else {
                /*if (bIsAssistantOn) { //Change colour based on Assistant state
                    clForeColour = Color.red;
                }*/
                //else {
                    clForeColour = Color.Black;
                //}

            }
        }

    }

    /*---------------------------------------------------------------*/

    //Gets the next available square
    public Square getNextsq(bool bIsAcross){
        if (bIsAcross)
            if(clAcross != null)
                return clAcross.getNextsq(this);
            else
                return this;
        else
            if(clDown != null)
                return clDown.getNextsq(this);
            else
                return this;
    }

    /*---------------------------------------------------------------*/

    //Gets the previous available square
    public Square getPrevsq(bool bIsAcross){
        if (bIsAcross)
            if(clAcross != null)
                return clAcross.getPrevsq(this);
            else
                return this;
        else
            if(clDown != null)
                return clDown.getPrevsq(this);
            else
                return this;
    }

    /*---------------------------------------------------------------*/

    //Returns boolean true/false based on square's contents
    public bool isPopulated(){
        if (chLetter == ' '){
            return false;
        }
        else{
            return true;
        }
    }

    /*---------------------------------------------------------------*/

}

