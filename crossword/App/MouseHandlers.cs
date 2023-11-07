using System;
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
        if (BPuzzleFinished) return true;
        try
        {
            //Exception handling added as an ArrayIndexOutOfBoundException occurs
            var sqSelSquare = _sqPuzzleSquares[(x - _nCrossOffsetX) / CwSettings.SquareWidth,
                (y - _nCrossOffsetY) / CwSettings.SquareHeight];

            if (!sqSelSquare.BIsCharAllowed) return true;
            //clear current highlights
            SqCurrentSquare.GetClueAnswerRef(BIsAcross).HighlightSquares(SqCurrentSquare, false);

            //Deselect the listbox based on direction
            if (!BIsAcross)
                LstClueDown.SelectedIndex = -1;
            else
                LstClueAcross.SelectedIndex = -1;

            //test if same sq and flip if possible
            if (sqSelSquare == SqCurrentSquare)
            {
                if (sqSelSquare.CanFlipDirection(BIsAcross))
                    BIsAcross = !BIsAcross;
            }
            else
                switch (BIsAcross)
                {
                    case true when sqSelSquare.ClAcross == null:
                    case false when sqSelSquare.ClDown == null:
                        BIsAcross = !BIsAcross;
                        break;
                }

            //set new current sq & highlight them
            SqCurrentSquare = sqSelSquare;
            SqCurrentSquare.GetClueAnswerRef(BIsAcross).HighlightSquares(SqCurrentSquare, true);

            //Find index to Clue Answer for highlighting in List boxes
            var tmpClueAnswer = sqSelSquare.GetClueAnswerRef(BIsAcross);
            var clueAnswerIdx = 0;
            for (var k = 0; k < NNumQuestions; k++)
            {
                if (tmpClueAnswer != CaPuzzleClueAnswers[k]) continue;
                clueAnswerIdx = k;
                break;
            }

            //Selects the item in the list box relative to ClueAnswer and direction
            if (BIsAcross)
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