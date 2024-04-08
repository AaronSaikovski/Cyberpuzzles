using System;
using System.Threading.Tasks;
using Crossword.Puzzle.Squares;
using Crossword.Shared.Constants;

namespace Crossword.App;

public sealed partial class CrosswordApp
{

    #region MouseUp
    /// <summary>
    /// MouseUp Handler
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool MouseUp(int x, int y)
    {
        _logger.LogInformation("Start MouseUp()");

        _bBufferDirty = true;

        //if puzzle is finished...eat the event
        if (_setFinished) return true;

        //Check that the mouse event occurred within our specified rectangle
        if (!rectCrossWord.Contains(x, y)) return true;

        //If the individual puzzle has finished...eat the event
        if (_puzzleFinished) return true;

        try
        {
            //Exception handling added as an ArrayIndexOutOfBoundException occurs
            var sqSelSquare = _sqPuzzleSquares?[(x - _nCrossOffsetX) / UiConstants.SquareWidth, (y - _nCrossOffsetY) / UiConstants.SquareHeight];

            if (sqSelSquare is { IsCharAllowed: false }) return true;

            //clear current highlights
            _sqCurrentSquare?.GetClueAnswerRef(_isAcross)?.HighlightSquares(_sqCurrentSquare, false);

            //Deselect the listbox based on direction
            DeselectListBoxItem();

            //test if same sq and flip if possible
            if (sqSelSquare is null) return true;
            CheckFlip(sqSelSquare);

            //Set new current sq & highlight 
            SetNewCurrentSquare(sqSelSquare);

            //Find index to Clue Answer for highlighting in List boxes
            var clueAnswerIdx = FindClueAnswerIdx(sqSelSquare);

            //Selects the item in the list box relative to ClueAnswerMap and direction
            SetListBoxClueAnswer(clueAnswerIdx);

            return true;
        }

        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }

    }
    #endregion

    #region DeselectListBoxItem
    /// <summary>
    /// Deselect the listbox based on direction
    /// </summary>
    private void DeselectListBoxItem()
    {
        try
        {
            _logger.LogInformation("Start DeselectListBoxItem()");

            //Deselect the listbox based on direction
            if (!_isAcross)
                _lstClueDown.SelectedIndex = 0;
            else
                _lstClueAcross.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }

    }
    #endregion

    #region SetListBoxClueAnswer
    /// <summary>
    /// Selects the item in the list box relative to ClueAnswerMap and direction
    /// </summary>
    /// <param name="clueAnswerIdx"></param>
    private void SetListBoxClueAnswer(int clueAnswerIdx)
    {
        try
        {
            _logger.LogInformation("Start SetListBoxClueAnswer()");

            //Selects the item in the list box relative to ClueAnswerMap and direction
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

    #region SetNewCurrentSquare
    /// <summary>
    /// set new current sq &amp; highlight
    /// </summary>
    /// <param name="sqSelSquare"></param>
    private void SetNewCurrentSquare(Square? sqSelSquare)
    {
        try
        {
            _logger.LogInformation("Start SetNewCurrentSquare()");

            ArgumentNullException.ThrowIfNull(sqSelSquare);

            //set new current sq & highlight t
            _sqCurrentSquare = sqSelSquare;
            _sqCurrentSquare?.GetClueAnswerRef(_isAcross)?.HighlightSquares(_sqCurrentSquare, true);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }

    }
    #endregion

    #region FindClueAnswerIdx
    /// <summary>
    /// Find index to Clue Answer for highlighting in List boxes
    /// </summary>
    /// <param name="sqSelSquare"></param>
    /// <returns></returns>
    private int FindClueAnswerIdx(Square? sqSelSquare)
    {
        try
        {
            _logger.LogInformation("Start FindClueAnswerIdx()");

            ArgumentNullException.ThrowIfNull(sqSelSquare);

            //Find index to Clue Answer for highlighting in List boxes
            var tmpClueAnswer = sqSelSquare?.GetClueAnswerRef(_isAcross);
            var clueAnswerIdx = 0;

            Parallel.For(0, _numQuestions, (k, loopState) =>
            {
                if (tmpClueAnswer == _caPuzzleClueAnswers[k]) loopState.Stop();
                clueAnswerIdx = k;
                loopState.Stop();
            });

            return clueAnswerIdx;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }

    }
    #endregion

    #region CheckFlip
    /// <summary>
    /// test if same sq and flip if possible
    /// </summary>
    /// <param name="sqSelSquare"></param>
    private void CheckFlip(Square sqSelSquare)
    {

        try
        {
            _logger.LogInformation("Start CheckFlip()");

            ArgumentNullException.ThrowIfNull(sqSelSquare);

            //test if same sq and flip if possible
            if (sqSelSquare != _sqCurrentSquare)
            {
                switch (_isAcross)
                {
                    case true when sqSelSquare.ClueAnswerAcross is null:
                    case false when sqSelSquare.ClueAnswerDown is null:
                        _isAcross = !_isAcross;
                        break;
                }
            }
            else
            {
                if (sqSelSquare.CanFlipDirection(_isAcross))
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

}