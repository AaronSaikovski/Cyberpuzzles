using System;
using Microsoft.Xna.Framework.Input;

namespace Crossword.App;

public sealed partial class CrosswordMain
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
            SqCurrentSquare?.GetClueAnswerRef(IsAcross)?.HighlightSquares(SqCurrentSquare, false);

            //If left arrow key pressed get prev sq
            GetLeftArrow(keyInFocus);

            //If right arrow pressed get next sq
            GetRightArrow(keyInFocus);

            //If up arrow key pressed
            GetUpArrow(keyInFocus);

            //If down arrow pressed get next sq
            GetDownArrow(keyInFocus);

            //Sets the highlighting of the square.
            SqCurrentSquare?.GetClueAnswerRef(IsAcross)?.HighlightSquares(SqCurrentSquare, true);

            //Listbox linkage stuff
            UpdateListBoxLinkage();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
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
            if (!IsAcross)
                LstClueDown.SelectedIndex = -1;
            else
                LstClueAcross.SelectedIndex = -1;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
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
            var tmp = SqCurrentSquare?.GetClueAnswerRef(IsAcross);
            var clueAnswerIdx = 0;
            for (var k = 0; k < NumQuestions; k++)
            {
                if (tmp != caPuzzleClueAnswers[k]) continue;
                clueAnswerIdx = k;
                break;
            }

            //Selects the item in the list box relative to the ClueAnswer
            //and the orientation.
            if (IsAcross)
                LstClueAcross.SelectedIndex = clueAnswerIdx;
            else
                LstClueDown.SelectedIndex = clueAnswerIdx - LstClueAcross.Items.Count;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
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
            if (IsAcross)
            {
                SqCurrentSquare = SqCurrentSquare?.GetNextSq(!IsAcross);
                if (SqCurrentSquare?.ClueAnswerAcross is null)
                {
                    IsAcross = !IsAcross;
                }
            }
            else
            {
                SqCurrentSquare = SqCurrentSquare?.GetNextSq(IsAcross);
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
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
            if (IsAcross)
            {
                SqCurrentSquare = SqCurrentSquare?.GetPrevSq(!IsAcross);
                if (SqCurrentSquare?.ClueAnswerAcross is null)
                {
                    IsAcross = !IsAcross;
                }
            }
            else
            {
                SqCurrentSquare = SqCurrentSquare?.GetPrevSq(IsAcross);
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
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
            if (IsAcross)
            {
                SqCurrentSquare = SqCurrentSquare?.GetNextSq(IsAcross);
            }
            else
            {
                SqCurrentSquare = SqCurrentSquare?.GetNextSq(!IsAcross);
                if (SqCurrentSquare?.ClueAnswerDown is null)
                    IsAcross = !IsAcross;
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
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
            if (!IsAcross)
            {
                SqCurrentSquare = SqCurrentSquare?.GetPrevSq(!IsAcross);
                if (SqCurrentSquare?.ClueAnswerDown is null)
                    IsAcross = !IsAcross;
            }
            else
            {
                SqCurrentSquare = SqCurrentSquare?.GetPrevSq(IsAcross);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
            throw;
        }
        
    }
    #endregion


}