using System;
using CyberPuzzles.Crossword.Constants;
using Microsoft.Xna.Framework.Input;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
        #region KeyDown
        
        //Keypress event - Display the character in the square region
        public void KeyDown(Keys[] keysDown, Keys keyInFocus)
        {
            //if puzzle is finished...eat the event
            if (bPuzzleFinished) return;
            switch (keyInFocus)
            {
                //Spacebar pressed to change orientation...bIsAcross.
                case Keys.Space:
                {
                    //Deselect the listbox based on direction
                    if (!bIsAcross)
                        lstClueDown.SelectedIndex = -1;
                    else
                        lstClueAcross.SelectedIndex = -1;

                    //Sets the highlighting of the square.
                    sqCurrentSquare.GetClueAnswerRef(bIsAcross).HighlightSquares(sqCurrentSquare, false);

                    //Change orientation if possible
                    if (bIsAcross)
                    {
                        if (sqCurrentSquare.CanFlipDirection(bIsAcross))
                            bIsAcross = false;
                    }
                    else
                    {
                        if (sqCurrentSquare.CanFlipDirection(bIsAcross))
                            bIsAcross = true;
                    }

                    //Sets the highlighting of the square.
                    sqCurrentSquare.GetClueAnswerRef(bIsAcross).HighlightSquares(sqCurrentSquare, true);
                    break;
                }
                //Set the focus if the tab key is pressed
                case Keys.Tab when nTabPress == 0:
                    //Give the Across list the focus
                    lstClueAcross.SelectedIndex = 0;
                    nTabPress = 1;
                    nFocusState = 1;
                    break;
                //Give the Down list the focus
                case Keys.Tab when nTabPress == 1:
                    lstClueDown.SelectedIndex = 0;
                    nTabPress = 2;
                    nFocusState = 2;
                    break;
                //Give the applet back the focus
                case Keys.Tab:
                {
                    if (nTabPress == 2)
                    {
                        nTabPress = 0;
                        nFocusState = 0;
                    }

                    break;
                }
            }

            //Only allow list box navigation if they have the focus.
            //Up and down arrows for the listbox navigation
            if (nFocusState is 1 or 2)
            {
                NavigateList(bIsAcross, keyInFocus);
            }


            //If the applet has the focus then allow the arrow keys to navigate around
            if (nFocusState == 0)
            {
                NavigatePuzzle(keyInFocus);
            }


            switch (keyInFocus)
            {
                //Delete present square's contents if Delete key is pressed
                case Keys.Delete:
                    sqCurrentSquare.SetLetter(' ', bIsAcross);
                    break;
                //Check to see if a backspace was entered
                case Keys.Back:
                    sqCurrentSquare.SetLetter(' ', bIsAcross);
                    sqCurrentSquare = sqCurrentSquare.GetPrevSq(bIsAcross);
                    sqCurrentSquare.GetClueAnswerRef(bIsAcross).HighlightSquares(sqCurrentSquare, true);
                    break;
                case >= Keys.A and <= Keys.Z:
                    //Sets the letter in the current square
                    sqCurrentSquare.SetLetter(char.ToUpper((char)keyInFocus), bIsAcross);

                    //get next sq or myself(same sq)  if not available
                    sqCurrentSquare = sqCurrentSquare.GetNextSq(bIsAcross);

                    //Sets the highlighting of the square.
                    sqCurrentSquare.GetClueAnswerRef(bIsAcross).HighlightSquares(sqCurrentSquare, true);
                    break;
            }


            //update score
            UpdateCrosswordScore();
        }
        
        #endregion

}