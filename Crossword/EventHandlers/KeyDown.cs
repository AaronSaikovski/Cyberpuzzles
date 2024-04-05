using System;
using Microsoft.Xna.Framework.Input;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region KeyDown

    /// <summary>
    /// Keypress event - Display the character in the square region
    /// </summary>
    /// <param name="keyInFocus"></param>
    public void KeyDown(Keys keyInFocus)
    {
        if (_puzzleFinished) return;
        //need to set the focus state
        //reset focus state
        _focusState = 0;

        try
        {
            _logger.LogInformation("Start KeyDown()");

            //Spacebar pressed to change orientation...bIsAcross.
            GetSpaceKey(keyInFocus);

            //Only allow list box navigation if they have the focus.
            //Up and down arrows for the listbox navigation
            if (_focusState is 1 or 2)
            {
                NavigateList(_isAcross, keyInFocus);
            }


            //If the applet has the focus then allow the arrow keys to navigate around
            if (_focusState == 0)
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
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
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
        try
        {
            _logger.LogInformation("Start GetSpaceKey()");

            //Spacebar pressed to change orientation...bIsAcross.
            if (keyInFocus != Keys.Space) return;
            //Deselect the listbox based on direction
            if (!_isAcross)
                _lstClueDown.SelectedIndex = -1;
            else
                _lstClueAcross.SelectedIndex = -1;

            //Sets the highlighting of the square.
            if (_sqCurrentSquare is null) return;
            _sqCurrentSquare.GetClueAnswerRef(_isAcross)?.HighlightSquares(_sqCurrentSquare, false);

            //Change orientation if possible
            if (_isAcross)
            {
                if (_sqCurrentSquare.CanFlipDirection(_isAcross))
                    _isAcross = false;
            }
            else
            {
                if (_sqCurrentSquare.CanFlipDirection(_isAcross))
                    _isAcross = true;
            }

            //Sets the highlighting of the square.
            _sqCurrentSquare.GetClueAnswerRef(_isAcross)
                ?.HighlightSquares(_sqCurrentSquare, true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
    #endregion

    #region GetDeleteKey
    /// <summary>
    /// Delete present square's contents if Delete key is pressed
    /// </summary>
    /// <param name="keyInFocus"></param>
    private void GetDeleteKey(Keys keyInFocus)
    {
        try
        {
            _logger.LogInformation("Start GetDeleteKey()");

            //Delete present square's contents if Delete key is pressed
            if (keyInFocus == Keys.Delete)
            {
                //SqCurrentSquare?.SetLetter(' ', IsAcross);
                _sqCurrentSquare?.SetLetter(' ');
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
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
        try
        {
            _logger.LogInformation("Start GetBackspaceKey()");

            //Check to see if a backspace was entered
            if (keyInFocus != Keys.Back) return;
            //SqCurrentSquare?.SetLetter(' ', IsAcross);
            _sqCurrentSquare?.SetLetter(' ');
            _sqCurrentSquare = _sqCurrentSquare?.GetPrevSq(_isAcross);
            _sqCurrentSquare?.GetClueAnswerRef(_isAcross)?.HighlightSquares(_sqCurrentSquare, true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }

    }
    #endregion

    #region GetCharKey
    /// <summary>
    /// Check that the char falls into our range.
    /// </summary>
    /// <param name="keyInFocus"></param>
    private void GetCharKey(Keys keyInFocus)
    {
        try
        {
            _logger.LogInformation("Start GetCharKey()");

            //Check that the char falls into our range.
            if (keyInFocus is < Keys.A or > Keys.Z) return;

            //Sets the letter in the current square
            //SqCurrentSquare?.SetLetter(char.ToUpper((char)keyInFocus), IsAcross);
            _sqCurrentSquare?.SetLetter(char.ToUpper((char)keyInFocus));

            //get next sq or myself(same sq)  if not available
            _sqCurrentSquare = _sqCurrentSquare?.GetNextSq(_isAcross);

            //Sets the highlighting of the square.
            _sqCurrentSquare?.GetClueAnswerRef(_isAcross)?.HighlightSquares(_sqCurrentSquare, true);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
    #endregion

}