
using Microsoft.Xna.Framework.Input;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
        #region KeyDown
        
        //Keypress event - Display the character in the square region
        public void KeyDown(Keys[] keysDown, Keys keyInFocus)
        {
            //if puzzle is finished...eat the event
            if (IsPuzzleFinished) return;
            switch (keyInFocus)
            {
                //Spacebar pressed to change orientation...bIsAcross.
                case Keys.Space:
                {
                    //Deselect the listbox based on direction
                    if (!IsAcross)
                        LstClueDown.SelectedIndex = -1;
                    else
                        LstClueAcross.SelectedIndex = -1;

                    //Sets the highlighting of the square.
                    SqCurrentSquare.GetClueAnswerRef(IsAcross).HighlightSquares(SqCurrentSquare, false);

                    //Change orientation if possible
                    if (IsAcross)
                    {
                        if (SqCurrentSquare.CanFlipDirection(IsAcross))
                            IsAcross = false;
                    }
                    else
                    {
                        if (SqCurrentSquare.CanFlipDirection(IsAcross))
                            IsAcross = true;
                    }

                    //Sets the highlighting of the square.
                    SqCurrentSquare.GetClueAnswerRef(IsAcross).HighlightSquares(SqCurrentSquare, true);
                    break;
                }
                //Set the focus if the tab key is pressed
                case Keys.Tab when NTabPress == 0:
                    //Give the Across list the focus
                    LstClueAcross.SelectedIndex = 0;
                    NTabPress = 1;
                    NFocusState = 1;
                    break;
                //Give the Down list the focus
                case Keys.Tab when NTabPress == 1:
                    LstClueDown.SelectedIndex = 0;
                    NTabPress = 2;
                    NFocusState = 2;
                    break;
                //Give the applet back the focus
                case Keys.Tab:
                {
                    if (NTabPress == 2)
                    {
                        NTabPress = 0;
                        NFocusState = 0;
                    }

                    break;
                }
            }

            //Only allow list box navigation if they have the focus.
            //Up and down arrows for the listbox navigation
            // if (lstClueAcross.IsKeyboardFocused || lstClueAcross.IsMouseInside)
            // {
            //     NavigateList(bIsAcross, keyInFocus);
            // }
            // else if (nFocusState == 0)
            // {
            //     NavigatePuzzle(keyInFocus);
            // }
            //Only allow list box navigation if they have the focus.
            //Up and down arrows for the listbox navigation
            if (NFocusState is 1 or 2)
            {
                NavigateList(IsAcross, keyInFocus);
            }


            //If the applet has the focus then allow the arrow keys to navigate around
            if (NFocusState == 0)
            {
                NavigatePuzzle(keyInFocus);
            }


            switch (keyInFocus)
            {
                //Delete present square's contents if Delete key is pressed
                case Keys.Delete:
                    SqCurrentSquare.SetLetter(' ', IsAcross);
                    break;
                //Check to see if a backspace was entered
                case Keys.Back:
                    SqCurrentSquare.SetLetter(' ', IsAcross);
                    SqCurrentSquare = SqCurrentSquare.GetPrevSq(IsAcross);
                    SqCurrentSquare.GetClueAnswerRef(IsAcross).HighlightSquares(SqCurrentSquare, true);
                    break;
                case >= Keys.A and <= Keys.Z:
                    //Sets the letter in the current square
                    SqCurrentSquare.SetLetter(char.ToUpper((char)keyInFocus), IsAcross);

                    //get next sq or myself(same sq)  if not available
                    SqCurrentSquare = SqCurrentSquare.GetNextSq(IsAcross);

                    //Sets the highlighting of the square.
                    SqCurrentSquare.GetClueAnswerRef(IsAcross).HighlightSquares(SqCurrentSquare, true);
                    break;
            }


            //update score
            UpdateCrosswordScore();
        }
        
        #endregion

}