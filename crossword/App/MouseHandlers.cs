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
        nMouseX = x - nCrossOffsetX;
        nMouseY = y - nCrossOffsetY;
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
        if (bPuzzleFinished) return true;
        try
        {
            //Exception handling added as an ArrayIndexOutOfBoundException occurs
            var sqSelSquare = _sqPuzzleSquares[(x - nCrossOffsetX) / CWSettings.SquareWidth,
                (y - nCrossOffsetY) / CWSettings.SquareHeight];

            if (!sqSelSquare.bIsCharAllowed) return true;
            //clear current highlights
            sqCurrentSquare.GetClueAnswerRef(bIsAcross).HighlightSquares(sqCurrentSquare, false);

            //Deselect the listbox based on direction
            if (!bIsAcross)
                lstClueDown.SelectedIndex = -1;
            else
                lstClueAcross.SelectedIndex = -1;

            //test if same sq and flip if possible
            if (sqSelSquare == sqCurrentSquare)
            {
                if (sqSelSquare.CanFlipDirection(bIsAcross))
                    bIsAcross = !bIsAcross;
            }
            else
                switch (bIsAcross)
                {
                    case true when sqSelSquare.clAcross == null:
                    case false when sqSelSquare.clDown == null:
                        bIsAcross = !bIsAcross;
                        break;
                }

            //set new current sq & highlight them
            sqCurrentSquare = sqSelSquare;
            sqCurrentSquare.GetClueAnswerRef(bIsAcross).HighlightSquares(sqCurrentSquare, true);

            //Find index to Clue Answer for highlighting in List boxes
            var tmpClueAnswer = sqSelSquare.GetClueAnswerRef(bIsAcross);
            var clueAnswerIdx = 0;
            for (var k = 0; k < nNumQuestions; k++)
            {
                if (tmpClueAnswer != caPuzzleClueAnswers[k]) continue;
                clueAnswerIdx = k;
                break;
            }

            //Selects the item in the list box relative to ClueAnswer and direction
            if (bIsAcross)
                lstClueAcross.SelectedIndex = clueAnswerIdx;
            else
                lstClueDown.SelectedIndex = clueAnswerIdx - lstClueAcross.Items.Count;

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