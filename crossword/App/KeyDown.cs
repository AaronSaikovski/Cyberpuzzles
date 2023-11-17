
using System;
using Microsoft.Xna.Framework.Input;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
        #region KeyDown
        
        //Keypress event - Display the character in the square region
        public void KeyDown(Keys[] keysDown, Keys keyInFocus)
        {
            if (!bPuzzleFinished)
            {
                //need to set the focus state
                //reset focus state
                nFocusState = 0;
                
                try
                {
                    //Spacebar pressed to change orientation...bIsAcross.
                    if (keyInFocus == Keys.Space){
                        
                        //Deselect the listbox based on direction
                        if (!bIsAcross)
                            LstClueDown.SelectedIndex = -1;
                        else
                            LstClueAcross.SelectedIndex = -1;

                        //Sets the highlighting of the square.
                        sqCurrentSquare.getClueAnswerRef(bIsAcross).HighlightSquares(sqCurrentSquare, false);

                        //Change orientation if possible
                        if(bIsAcross){
                            if (sqCurrentSquare.CanFlipDirection(bIsAcross))
                                bIsAcross = false;
                        }
                        else{
                            if (sqCurrentSquare.CanFlipDirection(bIsAcross))
                                bIsAcross = true;
                        }

                        //Sets the highlighting of the square.
                        sqCurrentSquare.getClueAnswerRef(bIsAcross).HighlightSquares(sqCurrentSquare, true);
                    }
                    
                    //If the applet has the focus then allow the arrow keys to navigate around
                    //NavigatePuzzle(keyInFocus);
                    
                    
                    //Only allow list box navigation if they have the focus.
                    //Up and down arrows for the listbox navigation
                    if ((nFocusState == 1) || (nFocusState == 2)) {
                        NavigateList(bIsAcross, keyInFocus);
                    }


                    //If the applet has the focus then allow the arrow keys to navigate around
                    if (nFocusState == 0){
                        NavigatePuzzle(keyInFocus);
                    }
                    
                    //Delete present square's contents if Delete key is pressed
                    if (keyInFocus == Keys.Delete){
                        sqCurrentSquare.setLetter(' ', bIsAcross);
                    }
                    
                    //Check to see if a backspace was entered
                    if (keyInFocus == Keys.Back){
                        sqCurrentSquare.setLetter(' ', bIsAcross);
                        sqCurrentSquare = sqCurrentSquare.getPrevsq(bIsAcross);
                        sqCurrentSquare.getClueAnswerRef(bIsAcross).HighlightSquares(sqCurrentSquare, true);
                     
                    }
                    
                    //Check that the char falls into our range.
                    //if ((key >= 'A' && key <= 'Z') || (key >= 'a' && key <= 'z')) {
                    if ((keyInFocus >= Keys.A && keyInFocus <= Keys.Z)) 
                    {
                        //Sets the letter in the current square
                        sqCurrentSquare.setLetter(char.ToUpper((char)keyInFocus), bIsAcross);

                        //get next sq or myself(same sq)  if not available
                        sqCurrentSquare = sqCurrentSquare.getNextsq(bIsAcross);

                        //Sets the highlighting of the square.
                        sqCurrentSquare.getClueAnswerRef(bIsAcross).HighlightSquares(sqCurrentSquare, true);

                    }
                    //update score
                    UpdateCrosswordScore();
                }
                catch (Exception e) {

                    //Catch the exception
                    Console.WriteLine("Exception " + e + " occurred in method keyDown");
                }
                
            }
        }
        #endregion

}