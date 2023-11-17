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
        if (!bSetFinished) {

            //Check that the mouse event occurred within our specified rectangle
            if(rectCrossWord.Contains(x, y)) {

                //If the individual puzzle has finished...eat the event
                if (!bPuzzleFinished) {

                    //Exception handling added as an ArrayIndexOutOfBoundException occurs
                    var sqSelSquare = sqPuzzleSquares[(x - nCrossOffsetX)/CwSettings.nSquareWidth,(y - nCrossOffsetY)/CwSettings.nSquareHeight];
                    try {
                        if (sqSelSquare.bIsCharAllowed){

                            //clear current highlights
                            sqCurrentSquare.getClueAnswerRef(bIsAcross)?.HighlightSquares(sqCurrentSquare, false);

                            //Deselect the listbox based on direction
                            if (!bIsAcross)
                                LstClueDown.SelectedIndex = 0;
                            else
                                LstClueAcross.SelectedIndex = 0;

                            //test if same sq and flip if possible
                            if (sqSelSquare == sqCurrentSquare){
                                if (sqSelSquare.CanFlipDirection(bIsAcross))
                                    bIsAcross = !bIsAcross;
                            }
                            else
                                if ((bIsAcross) && (sqSelSquare.clAcross == null))
                                    bIsAcross = !bIsAcross;
                                else if ((!bIsAcross) && (sqSelSquare.clDown == null))
                                    bIsAcross = !bIsAcross;

                            //set new current sq & highlight them
                            sqCurrentSquare = sqSelSquare;
                            sqCurrentSquare.getClueAnswerRef(bIsAcross)?.HighlightSquares(sqCurrentSquare, true);

                            //Find index to Clue Answer for highlighting in List boxes
                            var tmpClueAnswer = sqSelSquare.getClueAnswerRef(bIsAcross);
                            var ClueAnswerIdx = 0;
                            for (var k = 0; k < nNumQuestions; k++){
                                if (tmpClueAnswer == caPuzzleClueAnswers[k]){
                                    ClueAnswerIdx = k;
                                    break;
                                }
                            }

                            //Selects the item in the list box relative to ClueAnswer and direction
                            if(bIsAcross)
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