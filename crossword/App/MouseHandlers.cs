using System;
using System.Net.Mail;
using CyberPuzzles.Crossword.Constants;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region Mouse_Handlers

    /// <summary>
    /// Mouse down event
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool MouseDown(int x, int y)
    {
        NMouseX = x - _nCrossOffsetX;
        NMouseY = y - _nCrossOffsetY;
        return true;
    }

    /// <summary>
    /// MouseUp Handler
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public bool MouseUp(int x, int y)
    {
        //If the individual puzzle has finished...eat the event
        if (IsPuzzleFinished) return true;
        try
        {
            //Exception handling added as an ArrayIndexOutOfBoundException occurs
            var sqSelSquare = _sqPuzzleSquares[(x - _nCrossOffsetX) / CwSettings.SquareWidth,
                (y - _nCrossOffsetY) / CwSettings.SquareHeight];

            if (!sqSelSquare.BIsCharAllowed) return true;
            //clear current highlights
            SqCurrentSquare.GetClueAnswerRef(IsAcross).HighlightSquares(SqCurrentSquare, false);

            //Deselect the listbox based on direction
            if (!IsAcross)
               LstClueDown.SelectedIndex = -1;
            else 
                LstClueAcross.SelectedIndex = -1;

            //test if same sq and flip if possible
            if (sqSelSquare == SqCurrentSquare)
            {
                if (sqSelSquare.CanFlipDirection(IsAcross))
                    IsAcross = !IsAcross;
            }
            else
                switch (IsAcross)
                {
                    case true when sqSelSquare.ClAcross == null:
                    case false when sqSelSquare.ClDown == null:
                        IsAcross = !IsAcross;
                        break;
                }

            //set new current sq & highlight them
            SqCurrentSquare = sqSelSquare;
            SqCurrentSquare.GetClueAnswerRef(IsAcross).HighlightSquares(SqCurrentSquare, true);

            //Find index to Clue Answer for highlighting in List boxes
            var tmpClueAnswer = sqSelSquare.GetClueAnswerRef(IsAcross);
            var clueAnswerIdx = 0;
            for (var k = 0; k < _NumQuestions; k++)
            {
                if (tmpClueAnswer != CaPuzzleClueAnswers[k]) continue;
                clueAnswerIdx = k;
                break;
            }

            //Selects the item in the list box relative to ClueAnswer and direction
            if (IsAcross)
                LstClueAcross.SelectedIndex = clueAnswerIdx;
            else
                LstClueDown.SelectedIndex = clueAnswerIdx - LstClueAcross.Items.Count;

            return true;
        }
        catch (Exception e)
        {
            //Catch the exception
            Console.WriteLine("Exception " + e + " occurred in method mouseUp");
        }

        return true; //??
    }

    #endregion
}