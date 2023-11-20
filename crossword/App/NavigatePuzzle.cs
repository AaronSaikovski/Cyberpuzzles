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
                LstClueDown.SelectedIndex = -1;
            else
                LstClueAcross.SelectedIndex = -1;
    
            //Sets the highlighting of the square.
            sqCurrentSquare.GetClueAnswerRef(bIsAcross)?.HighlightSquares(sqCurrentSquare, false);

            //If left arrow key pressed get prev sq
            if (keyInFocus == Keys.Left)
            {
                if (bIsAcross)
                {
                    sqCurrentSquare = sqCurrentSquare.GetPrevSq(bIsAcross);
                }
                else
                {
                    sqCurrentSquare = sqCurrentSquare.GetPrevSq(!bIsAcross);
                    if (sqCurrentSquare.ClueAnswerDown == null)
                        bIsAcross = !bIsAcross;
                }
            }

            //If right arrow pressed get next sq
            if (keyInFocus == Keys.Right)
            {
                if (bIsAcross)
                {
                    sqCurrentSquare = sqCurrentSquare.GetNextSq(bIsAcross);
                }
                else
                {
                    sqCurrentSquare = sqCurrentSquare.GetNextSq(!bIsAcross);
                    if (sqCurrentSquare.ClueAnswerDown == null)
                        bIsAcross = !bIsAcross;
                }
                
            }
            
            //If up arrow key pressed
            if (keyInFocus == Keys.Up)
            {
                if (bIsAcross)
                {
                    sqCurrentSquare = sqCurrentSquare.GetPrevSq(!bIsAcross);
                    if (sqCurrentSquare.ClueAnswerAcross == null)
                    {
                        bIsAcross = !bIsAcross;
                    }
                }
                else
                {
                    sqCurrentSquare = sqCurrentSquare.GetPrevSq(bIsAcross);
                }

            }
            
            //If down arrow pressed get next sq
            if (keyInFocus == Keys.Down)
            {
                if (bIsAcross)
                {
                    sqCurrentSquare = sqCurrentSquare.GetNextSq(!bIsAcross);
                    if (sqCurrentSquare.ClueAnswerAcross == null)
                    {
                        bIsAcross = !bIsAcross;
                    }
                }
                else
                {
                    sqCurrentSquare = sqCurrentSquare.GetNextSq(bIsAcross);
                }
            }
    
            //Sets the highlighting of the square.
            sqCurrentSquare.GetClueAnswerRef(bIsAcross)?.HighlightSquares(sqCurrentSquare, true);
    
            ///////////////////////////////////////
            //Listbox linkage stuff
            //
            //Find index to Clue Answer for highlighting in List boxes
            var tmp = sqCurrentSquare.GetClueAnswerRef(bIsAcross);
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