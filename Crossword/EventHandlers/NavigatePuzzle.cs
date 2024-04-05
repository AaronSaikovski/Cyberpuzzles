using System;
using Microsoft.Xna.Framework.Input;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region NavigatePuzzle
    /// <summary>
    /// Navigates the puzzle
    /// </summary>
    /// <param name="keyInFocus"></param>
    private void NavigatePuzzle(Keys keyInFocus)
    {
        try
        {
            _logger.LogInformation("Start NavigatePuzzle()");

            //Deselect the listbox based on direction
            DeselectListBox();

            //Sets the highlighting of the square.
            _sqCurrentSquare?.GetClueAnswerRef(_isAcross)?.HighlightSquares(_sqCurrentSquare, false);

            //If left arrow key pressed get prev sq
            GetLeftArrow(keyInFocus);

            //If right arrow pressed get next sq
            GetRightArrow(keyInFocus);

            //If up arrow key pressed
            GetUpArrow(keyInFocus);

            //If down arrow pressed get next sq
            GetDownArrow(keyInFocus);

            //Sets the highlighting of the square.
            _sqCurrentSquare?.GetClueAnswerRef(_isAcross)?.HighlightSquares(_sqCurrentSquare, true);

            //Listbox linkage stuff
            UpdateListBoxLinkage();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
    #endregion

    #region DeselectListBox
    /// <summary>
    /// Deselect the listbox based on direction
    /// </summary>
    private void DeselectListBox()
    {
        try
        {
            _logger.LogInformation("Start DeselectListBox()");

            //Deselect the listbox based on direction
            if (!_isAcross)
                _lstClueDown.SelectedIndex = -1;
            else
                _lstClueAcross.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }

    }
    #endregion

    #region UpdateListBoxLinkage
    /// <summary>
    /// Find index to Clue Answer for highlighting in List boxes
    /// </summary>
    private void UpdateListBoxLinkage()
    {
        try
        {
            _logger.LogInformation("Start UpdateListBoxLinkage()");

            ///////////////////////////////////////
            //Listbox linkage stuff
            //
            //Find index to Clue Answer for highlighting in List boxes
            var tmp = _sqCurrentSquare?.GetClueAnswerRef(_isAcross);
            var clueAnswerIdx = 0;
            for (var k = 0; k < _numQuestions; k++)
            {
                if (tmp != _caPuzzleClueAnswers[k]) continue;
                clueAnswerIdx = k;
                break;
            }

            //Selects the item in the list box relative to the ClueAnswerMap
            //and the orientation.
            if (_isAcross)
                _lstClueAcross.SelectedIndex = clueAnswerIdx;
            else
                _lstClueDown.SelectedIndex = clueAnswerIdx - _lstClueAcross.Items.Count;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
    #endregion

    #region GetDownArrow
    /// <summary>
    /// Down Arrow handler
    /// </summary>
    /// <param name="keyInFocus"></param>
    private void GetDownArrow(Keys keyInFocus)
    {
        try
        {
            _logger.LogInformation("Start GetDownArrow()");

            //If down arrow pressed get next sq
            if (keyInFocus != Keys.Down) return;
            if (_isAcross)
            {
                _sqCurrentSquare = _sqCurrentSquare?.GetNextSq(!_isAcross);
                if (_sqCurrentSquare?.ClueAnswerAcross is null)
                {
                    _isAcross = !_isAcross;
                }
            }
            else
            {
                _sqCurrentSquare = _sqCurrentSquare?.GetNextSq(_isAcross);
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }

    }
    #endregion

    #region GetUpArrow
    /// <summary>
    /// Up Arrow handler
    /// </summary>
    /// <param name="keyInFocus"></param>
    private void GetUpArrow(Keys keyInFocus)
    {
        try
        {
            _logger.LogInformation("Start GetUpArrow()");

            //If up arrow key pressed
            if (keyInFocus != Keys.Up) return;
            if (_isAcross)
            {
                _sqCurrentSquare = _sqCurrentSquare?.GetPrevSq(!_isAcross);
                if (_sqCurrentSquare?.ClueAnswerAcross is null)
                {
                    _isAcross = !_isAcross;
                }
            }
            else
            {
                _sqCurrentSquare = _sqCurrentSquare?.GetPrevSq(_isAcross);
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }

    }
    #endregion

    #region GetRightArrow
    /// <summary>
    /// Right Arrow handler
    /// </summary>
    /// <param name="keyInFocus"></param>
    private void GetRightArrow(Keys keyInFocus)
    {
        try
        {
            _logger.LogInformation("Start GetRightArrow()");

            //If right arrow pressed get next sq
            if (keyInFocus != Keys.Right) return;
            if (_isAcross)
            {
                _sqCurrentSquare = _sqCurrentSquare?.GetNextSq(_isAcross);
            }
            else
            {
                _sqCurrentSquare = _sqCurrentSquare?.GetNextSq(!_isAcross);
                if (_sqCurrentSquare?.ClueAnswerDown is null)
                    _isAcross = !_isAcross;
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }

    }
    #endregion

    #region GetLeftArrow
    /// <summary>
    /// Left Arrow handler
    /// </summary>
    /// <param name="keyInFocus"></param>
    private void GetLeftArrow(Keys keyInFocus)
    {
        try
        {
            _logger.LogInformation("Start GetLeftArrow()");

            //If left arrow key pressed get prev sq
            if (keyInFocus != Keys.Left) return;
            if (!_isAcross)
            {
                _sqCurrentSquare = _sqCurrentSquare?.GetPrevSq(!_isAcross);
                if (_sqCurrentSquare?.ClueAnswerDown is null)
                    _isAcross = !_isAcross;
            }
            else
            {
                _sqCurrentSquare = _sqCurrentSquare?.GetPrevSq(_isAcross);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }

    }
    #endregion


}