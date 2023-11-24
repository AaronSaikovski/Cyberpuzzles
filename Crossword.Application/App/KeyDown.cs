
using System;
using Microsoft.Xna.Framework.Input;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region KeyDown
    /// <summary>
    /// Keypress event - Display the character in the square region
    /// </summary>
    /// <param name="keysDown"></param>
    /// <param name="keyInFocus"></param>
    public void KeyDown(Keys[] keysDown, Keys keyInFocus)
    {
        if (PuzzleFinished) return;
        //need to set the focus state
        //reset focus state
        FocusState = 0;

        try
        {
            //Spacebar pressed to change orientation...bIsAcross.
            GetSpaceKey(keyInFocus);

            //If the applet has the focus then allow the arrow keys to navigate around
            //NavigatePuzzle(keyInFocus);

            //Only allow list box navigation if they have the focus.
            //Up and down arrows for the listbox navigation
            if (FocusState is 1 or 2)
            {
                NavigateList(IsAcross, keyInFocus);
            }


            //If the applet has the focus then allow the arrow keys to navigate around
            if (FocusState == 0)
            {
                NavigatePuzzle(keyInFocus);
            }

            //Delete present square's contents if Delete key is pressed
            GetDeleteKey(keyInFocus);

            //Check to see if a backspace was entered
            GetBackspaceKey(keyInFocus);


            //Check that the char falls into our range.
            GetCharKey(keyInFocus);

            //update score
            UpdateCrosswordScore();
        }
        catch (Exception e)
        {

            //Catch the exception
            Console.WriteLine($"Exception {e} occurred in method keyDown");
        }
    }
    #endregion

    #region GetSpaceKey
    /// <summary>
    /// Spacebar pressed to change orientation...bIsAcross.
    /// </summary>
    /// <param name="keyInFocus"></param>
    private void GetSpaceKey(Keys keyInFocus)
    {
        //Spacebar pressed to change orientation...bIsAcross.
        if (keyInFocus != Keys.Space) return;
        //Deselect the listbox based on direction
        if (!IsAcross)
            LstClueDown.SelectedIndex = -1;
        else
            LstClueAcross.SelectedIndex = -1;

        //Sets the highlighting of the square.
        if (SqCurrentSquare == null) return;
        SqCurrentSquare.GetClueAnswerRef(IsAcross)?.HighlightSquares(SqCurrentSquare, false);

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
        SqCurrentSquare.GetClueAnswerRef(IsAcross)
            ?.HighlightSquares(SqCurrentSquare, true);
    }
    #endregion

    #region GetDeleteKey
    /// <summary>
    /// Delete present square's contents if Delete key is pressed
    /// </summary>
    /// <param name="keyInFocus"></param>
    private void GetDeleteKey(Keys keyInFocus)
    {
        //Delete present square's contents if Delete key is pressed
        if (keyInFocus == Keys.Delete)
        {
            SqCurrentSquare?.SetLetter(' ', IsAcross);
        }
    }
    #endregion

    #region GetBackspaceKey
    /// <summary>
    /// Gets backspace key press
    /// </summary>
    /// <param name="keyInFocus"></param>
    private void GetBackspaceKey(Keys keyInFocus)
    {
        //Check to see if a backspace was entered
        if (keyInFocus != Keys.Back) return;
        SqCurrentSquare?.SetLetter(' ', IsAcross);
        SqCurrentSquare = SqCurrentSquare?.GetPrevSq(IsAcross);
        SqCurrentSquare?.GetClueAnswerRef(IsAcross)?.HighlightSquares(SqCurrentSquare, true);
    }
    #endregion

    #region GetCharKey
    /// <summary>
    /// Check that the char falls into our range.
    /// </summary>
    /// <param name="keyInFocus"></param>
    private void GetCharKey(Keys keyInFocus)
    {
        //Check that the char falls into our range.
        //if ((key >= 'A' && key <= 'Z') || (key >= 'a' && key <= 'z')) {
        if (keyInFocus is < Keys.A or > Keys.Z) return;
        //Sets the letter in the current square
        SqCurrentSquare?.SetLetter(char.ToUpper((char)keyInFocus), IsAcross);

        //get next sq or myself(same sq)  if not available
        SqCurrentSquare = SqCurrentSquare?.GetNextSq(IsAcross);

        //Sets the highlighting of the square.
        SqCurrentSquare?.GetClueAnswerRef(IsAcross)?.HighlightSquares(SqCurrentSquare, true);
    }
    #endregion

}