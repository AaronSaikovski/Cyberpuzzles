////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:     ClueAnswer.cs                                         //
//      Authors:    Aaron Saikovski & Bryan Richards                      //
//      Date:       26/02/97                                              //
//      Version:    1.0                                                   //
//      Purpose:    Clue + Answer references class                        //
//                                                                        //
////////////////////////////////////////////////////////////////////////////

using System;
using CyberPuzzles.Crossword.Constants;
using CyberPuzzles.Crossword.App.Squares;

namespace CyberPuzzles.Crossword.App.ClueAnswers;

/*---------------------------------------------------------------*/

//ClueAnswer Class
public sealed class ClueAnswer {
    public string szAnswer = null;
    public string szClue = null;
    public int nQuestionNumber = 0;
    public bool bIsAcross = true;
    public Square[] sqAnswerSquares= null;

    /*---------------------------------------------------------------*/

    //ClueAnswer Constructor
    public ClueAnswer(){
    }

    /*---------------------------------------------------------------*/

    //Highlights the current word and sets active square.
    public void HighlightSquares(Square sq, bool bSetHighLighted){
        for (int i=0; i<szAnswer.Length; i++) {
            if (!bSetHighLighted)
                sqAnswerSquares[i].setHighlighted(CwSettings.nCURRENT_NONE);
            else {
                if (sqAnswerSquares[i] == sq)
                    sqAnswerSquares[i].setHighlighted(CwSettings.nCURRENT_LETTER);
                else
                    sqAnswerSquares[i].setHighlighted(CwSettings.nCURRENT_WORD);
            }

        }

    }

    /*---------------------------------------------------------------*/

    //Sets the object reference.
    public void setObjectRef(string szAnswer, string szClue, int nQuestionNumber,
                                bool bIsAcross, Square[] sqAnswerSquares){

        this.szAnswer = szAnswer;
        this.szClue = szClue;
        this.nQuestionNumber = nQuestionNumber;
        this.bIsAcross = bIsAcross;

        //Initialise the answer squares array.
        this.sqAnswerSquares = new Square[szAnswer.Length];

        for(int i=0; i<szAnswer.Length; i++) {
            this.sqAnswerSquares[i] = new Square();
            this.sqAnswerSquares[i].CreateSquare(0, 0);
        }


	    //Copy the array
        try {
            for (int k = 0; k<szAnswer.Length; k++)
            {
                this.sqAnswerSquares[k] = sqAnswerSquares[k];
            }
        }
        catch (Exception e) {
            Console.WriteLine("Exception " + e + "occurred in method setObjectRef");
        }


        //setup reference pointers back to me for each square
        for (int i=0; i<szAnswer.Length;i++){
            sqAnswerSquares[i].setObjectRef(this.bIsAcross, this);
        }
    }

    /*---------------------------------------------------------------*/

    //Returns the Answer/char match
    public char getChar(Square sq){
        int i = 0;
        while (i < szAnswer.Length){
            if (sq == sqAnswerSquares[i])
                return szAnswer[0];
            i++;
        }
        return '@';
    }

    /*---------------------------------------------------------------*/

    //Gets the first square referenced by my answer.
    public Square getSquare(){
        return sqAnswerSquares[0];
    }

    /*---------------------------------------------------------------*/

    //Returns the next square
    public Square getNextsq(Square sq){
        int i = 0;
        while (i < szAnswer.Length){
            if (sq == sqAnswerSquares[i])
                if (i < szAnswer.Length - 1)
                    return sqAnswerSquares[i + 1];
            i++;
        }
        return sq;

    }

    /*---------------------------------------------------------------*/

    //Returns the previous square
    public Square getPrevsq(Square sq){
        int i = (szAnswer.Length -1);
        while (i > -1){
            if (sq == sqAnswerSquares[i])
                if (i != 0){
                    return sqAnswerSquares[i - 1];

                }
                else{
                    return sq;
                }
            i--;
        }
        return sq;

    }

    /*---------------------------------------------------------------*/

    //Returns true if all answer letters are correct and false otherwise
    public bool isCorrect(){
        for(int i = 0; i < szAnswer.Length; i++){
            if(sqAnswerSquares[i].chLetter != szAnswer[i])
                return false;
        }
        return true;
    }

    /*---------------------------------------------------------------*/

    //Sets the Hint letter if Get Letter is pressed
    public bool checkHint(char chHintLetter){
        bool bResult = false;
        for(int i = 0; i < szAnswer.Length; i++)
            if((szAnswer[i] == chHintLetter)&&(sqAnswerSquares[i].chLetter != chHintLetter)){
                sqAnswerSquares[i].setLetter(chHintLetter, bIsAcross);
                bResult = true;
            }
        return bResult;
    }

    /*---------------------------------------------------------------*/

    //Sets the letter colour if Check words is pressed.
    public void checkWord(){
        for(int i = 0; i < szAnswer.Length; i++)
            sqAnswerSquares[i].checkLetter(szAnswer[i]);
    }

    /*---------------------------------------------------------------*/

    //Checks if the Answer squares are populated with chars.
    public bool isPopulated(){
        for(int i = 0; i < szAnswer.Length; i++){
            if((sqAnswerSquares[i].clAcross==null)||(sqAnswerSquares[i].clDown==null))
                if(sqAnswerSquares[i].isPopulated())
                    return true;
        }
        return false;
    }

    /*---------------------------------------------------------------*/

    //Resets the current word squares - Simply overtypes the current
    //sq contents with ' ' chars.
    public void ResetWord(bool bIsAcross){
        for(int i = 0; i < szAnswer.Length; i++){
            if((sqAnswerSquares[i].clAcross!=null)&&(sqAnswerSquares[i].clDown!=null)){
                if(bIsAcross){
                    if(!sqAnswerSquares[i].clDown.isPopulated()){
                        sqAnswerSquares[i].chLetter = ' ';
                        sqAnswerSquares[i].bIsDirty = true;
                    }
                }
                else{
                    if(!sqAnswerSquares[i].clAcross.isPopulated()){
                        sqAnswerSquares[i].chLetter = ' ';
                        sqAnswerSquares[i].bIsDirty = true;
                    }
                }
            }else{
                sqAnswerSquares[i].chLetter = ' ';
                sqAnswerSquares[i].bIsDirty = true;
            }
        }
    }

    /*---------------------------------------------------------------*/
}
