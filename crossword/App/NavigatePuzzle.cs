using System;
using Microsoft.Xna.Framework.Input;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region NavigatePuzzle
    
    private void NavigatePuzzle(Keys keyInFocus)
    {
        try
        {
            //Deselect the listbox based on direction
            if (!bIsAcross)
                LstClueDown.SelectedIndex = null;
            else
                LstClueAcross.SelectedIndex = null;
    
            //Sets the highlighting of the square.
            sqCurrentSquare.getClueAnswerRef(bIsAcross).HighlightSquares(sqCurrentSquare, false);

            //If left arrow key pressed get prev sq
            if (keyInFocus == Keys.Left)
            {
                if (bIsAcross)
                {
                    sqCurrentSquare = sqCurrentSquare.getPrevsq(bIsAcross);
                }
                else
                {
                    sqCurrentSquare = sqCurrentSquare.getPrevsq(!bIsAcross);
                    if (sqCurrentSquare.clDown == null)
                        bIsAcross = !bIsAcross;
                }
            }

            //If right arrow pressed get next sq
            if (keyInFocus == Keys.Right)
            {
                if (bIsAcross)
                {
                    sqCurrentSquare = sqCurrentSquare.getNextsq(bIsAcross);
                }
                else
                {
                    sqCurrentSquare = sqCurrentSquare.getNextsq(!bIsAcross);
                    if (sqCurrentSquare.clDown == null)
                        bIsAcross = !bIsAcross;
                }
                
            }
            
            //If up arrow key pressed
            if (keyInFocus == Keys.Up)
            {
                if (bIsAcross)
                {
                    sqCurrentSquare = sqCurrentSquare.getPrevsq(!bIsAcross);
                    if (sqCurrentSquare.clAcross == null)
                    {
                        bIsAcross = !bIsAcross;
                    }
                }
                else
                {
                    sqCurrentSquare = sqCurrentSquare.getPrevsq(bIsAcross);
                }

            }
            
            //If down arrow pressed get next sq
            if (keyInFocus == Keys.Down)
            {
                if (bIsAcross)
                {
                    sqCurrentSquare = sqCurrentSquare.getNextsq(!bIsAcross);
                    if (sqCurrentSquare.clAcross == null)
                    {
                        bIsAcross = !bIsAcross;
                    }
                }
                else
                {
                    sqCurrentSquare = sqCurrentSquare.getNextsq(bIsAcross);
                }
            }
    
            //Sets the highlighting of the square.
            sqCurrentSquare.getClueAnswerRef(bIsAcross).HighlightSquares(sqCurrentSquare, true);
    
            ///////////////////////////////////////
            //Listbox linkage stuff
            //
            //Find index to Clue Answer for highlighting in List boxes
            var tmp = sqCurrentSquare.getClueAnswerRef(bIsAcross);
            var clueAnswerIdx = 0;
            for (var k = 0; k < nNumQuestions; k++)
            {
                if (tmp == caPuzzleClueAnswers[k])
                {
                    clueAnswerIdx = k;
                    break;
                };
                
            }
    
            //Selects the item in the list box relative to the ClueAnswer
            //and the orientation.
            if (bIsAcross)
                LstClueAcross.SelectedIndex = clueAnswerIdx;
            else
                LstClueDown.SelectedIndex = clueAnswerIdx - LstClueAcross.Items.Count;
            ///////////////////////////////////////
        }
        catch (Exception e)
        {
            //Catch the exception
            Console.WriteLine("Exception " + e + " occurred in method NavigatePuzzle");
        }
    }
    
    #endregion
}