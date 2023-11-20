using System;
using CyberPuzzles.Crossword.Constants;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region Mouse_Handlers
    
    // public bool MouseDown(int x, int y)
    // {
    //     NMouseX = x - nCrossOffsetX;
    //     NMouseY = y - nCrossOffsetY;
    //     return true;
    // }

    /// <summary>
    /// MouseUp Handler
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
     //Mouseup event
    public bool MouseUp(int x, int y)
    {
        bBufferDirty = true;

        //if puzzle is finished...eat the event
        if (!SetFinished) {

            //Check that the mouse event occurred within our specified rectangle
            if(rectCrossWord.Contains(x, y)) {

                //If the individual puzzle has finished...eat the event
                if (!PuzzleFinished) {

                    //Exception handling added as an ArrayIndexOutOfBoundException occurs
                    var sqSelSquare = sqPuzzleSquares[(x - nCrossOffsetX)/CwSettings.nSquareWidth,(y - nCrossOffsetY)/CwSettings.nSquareHeight];
                    try {
                        if (sqSelSquare.IsCharAllowed){

                            //clear current highlights
                            SqCurrentSquare.GetClueAnswerRef(IsAcross)?.HighlightSquares(SqCurrentSquare, false);

                            //Deselect the listbox based on direction
                            if (!IsAcross)
                                LstClueDown.SelectedIndex = 0;
                            else
                                LstClueAcross.SelectedIndex = 0;

                            //test if same sq and flip if possible
                            if (sqSelSquare == SqCurrentSquare){
                                if (sqSelSquare.CanFlipDirection(IsAcross))
                                    IsAcross = !IsAcross;
                            }
                            else
                                if ((IsAcross) && (sqSelSquare.ClueAnswerAcross == null))
                                    IsAcross = !IsAcross;
                                else if ((!IsAcross) && (sqSelSquare.ClueAnswerDown == null))
                                    IsAcross = !IsAcross;

                            //set new current sq & highlight them
                            SqCurrentSquare = sqSelSquare;
                            SqCurrentSquare.GetClueAnswerRef(IsAcross)?.HighlightSquares(SqCurrentSquare, true);

                            //Find index to Clue Answer for highlighting in List boxes
                            var tmpClueAnswer = sqSelSquare.GetClueAnswerRef(IsAcross);
                            var ClueAnswerIdx = 0;
                            for (var k = 0; k < NumQuestions; k++){
                                if (tmpClueAnswer == caPuzzleClueAnswers[k]){
                                    ClueAnswerIdx = k;
                                    break;
                                }
                            }

                            //Selects the item in the list box relative to ClueAnswer and direction
                            if(IsAcross)
                                LstClueAcross.SelectedIndex = ClueAnswerIdx;
                            else
                                LstClueDown.SelectedIndex = (ClueAnswerIdx - LstClueAcross.Items.Count);

                        }
                        return true;
                    }

                    catch (Exception e) {
                        //Catch the exception
                        Console.WriteLine($"Exception {e} occurred in method mouseUp");
                    }
                }

            }
        }

        return true;
    }


    #endregion
}