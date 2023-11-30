using System;
using Crossword.PuzzleSquares;
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
        bBufferDirty = true;

        //if puzzle is finished...eat the event
        if (SetFinished) return true;
        //Check that the mouse event occurred within our specified rectangle
        if (!rectCrossWord.Contains(x, y)) return true;
        //If the individual puzzle has finished...eat the event
        if (PuzzleFinished) return true;
        //Exception handling added as an ArrayIndexOutOfBoundException occurs
        var sqSelSquare = sqPuzzleSquares[(x - nCrossOffsetX) / CWSettings.SquareWidth, (y - nCrossOffsetY) / CWSettings.SquareHeight];
        try
        {
            if (sqSelSquare is { IsCharAllowed: false }) return true;
            //clear current highlights
            SqCurrentSquare?.GetClueAnswerRef(IsAcross)?.HighlightSquares(SqCurrentSquare, false);

            //Deselect the listbox based on direction
            DeselectListBoxItem();

            //test if same sq and flip if possible
            if (sqSelSquare == null) return true;
            CheckFlip(sqSelSquare);

            //Set new current sq & highlight 
            SetNewCurrentSquare(sqSelSquare);

            //Find index to Clue Answer for highlighting in List boxes
            var clueAnswerIdx = FindClueAnswerIdx(sqSelSquare);

            //Selects the item in the list box relative to ClueAnswer and direction
            SetListBoxClueAnswer(clueAnswerIdx);

            return true;
        }

        catch (Exception e)
        {
            //Catch the exception
            Console.WriteLine($"Exception {e} occurred in method mouseUp");
        }

        return true;
    }
    #endregion

    #region DeselectListBoxItem
    /// <summary>
    /// Deselect the listbox based on direction
    /// </summary>
    private void DeselectListBoxItem()
    {
        //Deselect the listbox based on direction
        if (!IsAcross)
            LstClueDown.SelectedIndex = 0;
        else
            LstClueAcross.SelectedIndex = 0;
    }
    #endregion

    #region SetListBoxClueAnswer
    /// <summary>
    /// Selects the item in the list box relative to ClueAnswer and direction
    /// </summary>
    /// <param name="clueAnswerIdx"></param>
    private void SetListBoxClueAnswer(int clueAnswerIdx)
    {
        //Selects the item in the list box relative to ClueAnswer and direction
        if (IsAcross)
            LstClueAcross.SelectedIndex = clueAnswerIdx;
        else
            LstClueDown.SelectedIndex = clueAnswerIdx - LstClueAcross.Items.Count;
    }
    #endregion

    #region SetNewCurrentSquare
    /// <summary>
    /// set new current sq &amp; highlight
    /// </summary>
    /// <param name="sqSelSquare"></param>
    private void SetNewCurrentSquare(Square? sqSelSquare)
    {
        //set new current sq & highlight t
        SqCurrentSquare = sqSelSquare;
        SqCurrentSquare?.GetClueAnswerRef(IsAcross)?.HighlightSquares(SqCurrentSquare, true);
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
        //Find index to Clue Answer for highlighting in List boxes
        var tmpClueAnswer = sqSelSquare?.GetClueAnswerRef(IsAcross);
        var clueAnswerIdx = 0;
        for (var k = 0; k < NumQuestions; k++)
        {
            if (tmpClueAnswer != caPuzzleClueAnswers[k]) continue;
            clueAnswerIdx = k;
            break;
        }

        return clueAnswerIdx;
    }
    #endregion

    #region CheckFlip
    /// <summary>
    /// test if same sq and flip if possible
    /// </summary>
    /// <param name="sqSelSquare"></param>
    private void CheckFlip(Square sqSelSquare)
    {
        ArgumentNullException.ThrowIfNull(sqSelSquare);
        //test if same sq and flip if possible
        if (sqSelSquare != SqCurrentSquare)
        {
            switch (IsAcross)
            {
                case true when sqSelSquare.ClueAnswerAcross == null:
                case false when sqSelSquare.ClueAnswerDown == null:
                    IsAcross = !IsAcross;
                    break;
            }
        }
        else
        {
            if (sqSelSquare.CanFlipDirection(IsAcross))
                IsAcross = !IsAcross;
        }
    }
    #endregion

}