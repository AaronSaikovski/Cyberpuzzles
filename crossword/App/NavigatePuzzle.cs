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
                lstClueDown.SelectedIndex = -1;
            else
                lstClueAcross.SelectedIndex = -1;

            //Sets the highlighting of the square.
            sqCurrentSquare.GetClueAnswerRef(bIsAcross).HighlightSquares(sqCurrentSquare, false);

            switch (keyInFocus)
            {
                //If left arrow key pressed get prev sq
                case Keys.Left when bIsAcross:
                    sqCurrentSquare = sqCurrentSquare.GetPrevSq(bIsAcross);
                    break;
                case Keys.Left:
                {
                    sqCurrentSquare = sqCurrentSquare.GetPrevSq(!bIsAcross);
                    if (sqCurrentSquare.clDown == null)
                        bIsAcross = !bIsAcross;
                    break;
                }
                //If right arrow pressed get next sq
                case Keys.Right when bIsAcross:
                    sqCurrentSquare = sqCurrentSquare.GetNextSq(bIsAcross);
                    break;
                case Keys.Right:
                {
                    sqCurrentSquare = sqCurrentSquare.GetNextSq(!bIsAcross);
                    if (sqCurrentSquare.clDown == null)
                        bIsAcross = !bIsAcross;
                    break;
                }
                //If up arrow key pressed
                case Keys.Up when bIsAcross:
                {
                    sqCurrentSquare = sqCurrentSquare.GetPrevSq(!bIsAcross);
                    if (sqCurrentSquare.clAcross == null)
                    {
                        bIsAcross = !bIsAcross;
                    }

                    break;
                }
                case Keys.Up:
                    sqCurrentSquare = sqCurrentSquare.GetPrevSq(bIsAcross);
                    break;
                //If down arrow pressed get next sq
                case Keys.Down when bIsAcross:
                {
                    sqCurrentSquare = sqCurrentSquare.GetNextSq(!bIsAcross);
                    if (sqCurrentSquare.clAcross == null)
                    {
                        bIsAcross = !bIsAcross;
                    }

                    break;
                }
                case Keys.Down:
                    sqCurrentSquare = sqCurrentSquare.GetNextSq(bIsAcross);
                    break;
            }

            //Sets the highlighting of the square.
            sqCurrentSquare.GetClueAnswerRef(bIsAcross).HighlightSquares(sqCurrentSquare, true);

            ///////////////////////////////////////
            //Listbox linkage stuff
            //
            //Find index to Clue Answer for highlighting in List boxes
            var tmp = sqCurrentSquare.GetClueAnswerRef(bIsAcross);
            var clueAnswerIdx = 0;
            for (var k = 0; k < nNumQuestions; k++)
            {
                if (tmp != caPuzzleClueAnswers[k]) continue;
                clueAnswerIdx = k;
                break;
            }

            //Selects the item in the list box relative to the ClueAnswer
            //and the orientation.
            if (bIsAcross)
                lstClueAcross.SelectedIndex = clueAnswerIdx;
            else
                lstClueDown.SelectedIndex = clueAnswerIdx - lstClueAcross.Items.Count;
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