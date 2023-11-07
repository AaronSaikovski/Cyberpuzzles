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
            if (!BIsAcross)
                LstClueDown.SelectedIndex = -1;
            else
                LstClueAcross.SelectedIndex = -1;

            //Sets the highlighting of the square.
            SqCurrentSquare.GetClueAnswerRef(BIsAcross).HighlightSquares(SqCurrentSquare, false);

            switch (keyInFocus)
            {
                //If left arrow key pressed get prev sq
                case Keys.Left when BIsAcross:
                    SqCurrentSquare = SqCurrentSquare.GetPrevSq(BIsAcross);
                    break;
                case Keys.Left:
                {
                    SqCurrentSquare = SqCurrentSquare.GetPrevSq(!BIsAcross);
                    if (SqCurrentSquare.ClDown == null)
                        BIsAcross = !BIsAcross;
                    break;
                }
                //If right arrow pressed get next sq
                case Keys.Right when BIsAcross:
                    SqCurrentSquare = SqCurrentSquare.GetNextSq(BIsAcross);
                    break;
                case Keys.Right:
                {
                    SqCurrentSquare = SqCurrentSquare.GetNextSq(!BIsAcross);
                    if (SqCurrentSquare.ClDown == null)
                        BIsAcross = !BIsAcross;
                    break;
                }
                //If up arrow key pressed
                case Keys.Up when BIsAcross:
                {
                    SqCurrentSquare = SqCurrentSquare.GetPrevSq(!BIsAcross);
                    if (SqCurrentSquare.ClAcross == null)
                    {
                        BIsAcross = !BIsAcross;
                    }

                    break;
                }
                case Keys.Up:
                    SqCurrentSquare = SqCurrentSquare.GetPrevSq(BIsAcross);
                    break;
                //If down arrow pressed get next sq
                case Keys.Down when BIsAcross:
                {
                    SqCurrentSquare = SqCurrentSquare.GetNextSq(!BIsAcross);
                    if (SqCurrentSquare.ClAcross == null)
                    {
                        BIsAcross = !BIsAcross;
                    }

                    break;
                }
                case Keys.Down:
                    SqCurrentSquare = SqCurrentSquare.GetNextSq(BIsAcross);
                    break;
            }

            //Sets the highlighting of the square.
            SqCurrentSquare.GetClueAnswerRef(BIsAcross).HighlightSquares(SqCurrentSquare, true);

            ///////////////////////////////////////
            //Listbox linkage stuff
            //
            //Find index to Clue Answer for highlighting in List boxes
            var tmp = SqCurrentSquare.GetClueAnswerRef(BIsAcross);
            var clueAnswerIdx = 0;
            for (var k = 0; k < NNumQuestions; k++)
            {
                if (tmp != CaPuzzleClueAnswers[k]) continue;
                clueAnswerIdx = k;
                break;
            }

            //Selects the item in the list box relative to the ClueAnswer
            //and the orientation.
            if (BIsAcross)
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