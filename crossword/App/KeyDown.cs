
using System;
using Microsoft.Xna.Framework.Input;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
        #region KeyDown
        
        //Keypress event - Display the character in the square region
        // public void KeyDown(Keys[] keysDown, Keys keyInFocus)
        // {
        //     //if puzzle is finished...eat the event
        //     if (IsPuzzleFinished) return;
        //
        //     //reset focus state
        //     NFocusState = 0;
        //     
        //     switch (keyInFocus)
        //     {
        //         //Spacebar pressed to change orientation...bIsAcross.
        //         case Keys.Space:
        //         {
        //             //Deselect the listbox based on direction
        //             if (!IsAcross)
        //                 LstClueDown.SelectedIndex = -1;
        //             else
        //                 LstClueAcross.SelectedIndex = -1;
        //
        //             //Sets the highlighting of the square.
        //             SqCurrentSquare.getClueAnswerRef(IsAcross).HighlightSquares(SqCurrentSquare, false);
        //
        //             //Change orientation if possible
        //             if (IsAcross)
        //             {
        //                 if (SqCurrentSquare.CanFlipDirection(IsAcross))
        //                     IsAcross = false;
        //             }
        //             else
        //             {
        //                 if (SqCurrentSquare.CanFlipDirection(IsAcross))
        //                     IsAcross = true;
        //             }
        //
        //             //Sets the highlighting of the square.
        //             SqCurrentSquare.getClueAnswerRef(IsAcross).HighlightSquares(SqCurrentSquare, true);
        //             break;
        //         }
        //         //Set the focus if the tab key is pressed
        //         // case Keys.Tab when NTabPress == 0:
        //         //     //Give the Across list the focus
        //         //     LstClueAcross.SelectedIndex = 0;
        //         //     NTabPress = 1;
        //         //     NFocusState = 1;
        //         //     break;
        //         // //Give the Down list the focus
        //         // case Keys.Tab when NTabPress == 1:
        //         //     LstClueDown.SelectedIndex = 0;
        //         //     NTabPress = 2;
        //         //     NFocusState = 2;
        //         //     break;
        //         //Give the applet back the focus
        //         // case Keys.Tab:
        //         // {
        //         //     if (NTabPress == 2)
        //         //     {
        //         //         NTabPress = 0;
        //         //         NFocusState = 0;
        //         //     }
        //         //
        //         //     break;
        //         // }
        //     }
        //
        //     //Only allow list box navigation if they have the focus.
        //     //Up and down arrows for the listbox navigation
        //     // if (lstClueAcross.IsKeyboardFocused || lstClueAcross.IsMouseInside)
        //     // {
        //     //     NavigateList(bIsAcross, keyInFocus);
        //     // }
        //     // else if (nFocusState == 0)
        //     // {
        //     //     NavigatePuzzle(keyInFocus);
        //     // }
        //     
        //
        //     //Only allow list box navigation if they have the focus.
        //     //Up and down arrows for the listbox navigation
        //     // if (NFocusState is 1 or 2)
        //     // {
        //     //     NavigateList(IsAcross, keyInFocus);
        //     // }
        //
        //     //TODO: suspect a bug here - NFocusState
        //     //If the applet has the focus then allow the arrow keys to navigate around
        //     // if (NFocusState == 0)
        //     // {
        //     //     NavigatePuzzle(keyInFocus);
        //     // }
        //     NavigatePuzzle(keyInFocus);
        //
        //     //BUG:??
        //     switch (keyInFocus)
        //     {
        //         //Delete present square's contents if Delete key is pressed
        //         case Keys.Delete:
        //             SqCurrentSquare.setLetter(' ', IsAcross);
        //             break;
        //         //Check to see if a backspace was entered
        //         case Keys.Back:
        //             SqCurrentSquare.setLetter(' ', IsAcross);
        //             SqCurrentSquare = SqCurrentSquare.getPrevsq(IsAcross);
        //             SqCurrentSquare.getClueAnswerRef(IsAcross).HighlightSquares(SqCurrentSquare, true);
        //             break;
        //         case >= Keys.A and <= Keys.Z:
        //             //Sets the letter in the current square
        //             SqCurrentSquare.setLetter(char.ToUpper((char)keyInFocus), IsAcross);
        //
        //             //get next sq or myself(same sq)  if not available
        //             SqCurrentSquare = SqCurrentSquare.getNextsq(IsAcross);
        //
        //             //Sets the highlighting of the square.
        //             SqCurrentSquare.getClueAnswerRef(IsAcross).HighlightSquares(SqCurrentSquare, true);
        //             break;
        //     }
        //
        //
        //     //update score
        //     UpdateCrosswordScore();
        // }
        
        public void KeyDown(Keys[] keysDown, Keys keyInFocus)
        {
            if (!IsPuzzleFinished)
            {
                //reset focus state
                NFocusState = 0;
                
                try
                {
                    //Spacebar pressed to change orientation...bIsAcross.
                    if (keyInFocus == Keys.Space){

                        //Deselect the listbox based on direction
                        if (!IsAcross)
                            LstClueDown.SelectedIndex = -1;
                        else
                            LstClueAcross.SelectedIndex = -1;

                        //Sets the highlighting of the square.
                        SqCurrentSquare.getClueAnswerRef(IsAcross).HighlightSquares(SqCurrentSquare, false);

                        //Change orientation if possible
                        if(IsAcross){
                            if (SqCurrentSquare.CanFlipDirection(IsAcross))
                                IsAcross = false;
                        }
                        else{
                            if (SqCurrentSquare.CanFlipDirection(IsAcross))
                                IsAcross = true;
                        }

                        //Sets the highlighting of the square.
                        SqCurrentSquare.getClueAnswerRef(IsAcross).HighlightSquares(SqCurrentSquare, true);
                    }
                    
                    //If the applet has the focus then allow the arrow keys to navigate around
                    NavigatePuzzle(keyInFocus);
                    
                    //Delete present square's contents if Delete key is pressed
                    if (keyInFocus == Keys.Delete){
                        SqCurrentSquare.setLetter(' ', IsAcross);
                    }
                    
                    //Check to see if a backspace was entered
                    if (keyInFocus == Keys.Back){
                        SqCurrentSquare.setLetter(' ', IsAcross);
                        SqCurrentSquare = SqCurrentSquare.getPrevsq(IsAcross);
                        SqCurrentSquare.getClueAnswerRef(IsAcross).HighlightSquares(SqCurrentSquare, true);
                     
                    }
                    
                    //Check that the char falls into our range.
                    //if ((key >= 'A' && key <= 'Z') || (key >= 'a' && key <= 'z')) {
                    if ((keyInFocus >= Keys.A && keyInFocus <= Keys.Z)) 
                    {
                        //Sets the letter in the current square
                        SqCurrentSquare.setLetter(char.ToUpper((char)keyInFocus), IsAcross);

                        //get next sq or myself(same sq)  if not available
                        SqCurrentSquare = SqCurrentSquare.getNextsq(IsAcross);

                        //Sets the highlighting of the square.
                        SqCurrentSquare.getClueAnswerRef(IsAcross).HighlightSquares(SqCurrentSquare, true);

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