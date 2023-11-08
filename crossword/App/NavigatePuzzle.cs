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
            // if (!IsAcross)
            //     LstClueDown.SelectedIndex = -1;
            // else
            //     LstClueAcross.SelectedIndex = -1;

            //Sets the highlighting of the square.
            SqCurrentSquare.GetClueAnswerRef(IsAcross).HighlightSquares(SqCurrentSquare, false);

            switch (keyInFocus)
            {
                //If left arrow key pressed get prev sq
                case Keys.Left when IsAcross:
                    SqCurrentSquare = SqCurrentSquare.GetPrevSq(IsAcross);
                    break;
                case Keys.Left:
                {
                    SqCurrentSquare = SqCurrentSquare.GetPrevSq(!IsAcross);
                    if (SqCurrentSquare.ClDown == null)
                        IsAcross = !IsAcross;
                    break;
                }
                //If right arrow pressed get next sq
                case Keys.Right when IsAcross:
                    SqCurrentSquare = SqCurrentSquare.GetNextSq(IsAcross);
                    break;
                case Keys.Right:
                {
                    SqCurrentSquare = SqCurrentSquare.GetNextSq(!IsAcross);
                    if (SqCurrentSquare.ClDown == null)
                        IsAcross = !IsAcross;
                    break;
                }
                //If up arrow key pressed
                case Keys.Up when IsAcross:
                {
                    SqCurrentSquare = SqCurrentSquare.GetPrevSq(!IsAcross);
                    if (SqCurrentSquare.ClAcross == null)
                    {
                        IsAcross = !IsAcross;
                    }

                    break;
                }
                case Keys.Up:
                    SqCurrentSquare = SqCurrentSquare.GetPrevSq(IsAcross);
                    break;
                //If down arrow pressed get next sq
                case Keys.Down when IsAcross:
                {
                    SqCurrentSquare = SqCurrentSquare.GetNextSq(!IsAcross);
                    if (SqCurrentSquare.ClAcross == null)
                    {
                        IsAcross = !IsAcross;
                    }

                    break;
                }
                case Keys.Down:
                    SqCurrentSquare = SqCurrentSquare.GetNextSq(IsAcross);
                    break;
            }

            //Sets the highlighting of the square.
            SqCurrentSquare.GetClueAnswerRef(IsAcross).HighlightSquares(SqCurrentSquare, true);

            ///////////////////////////////////////
            //Listbox linkage stuff
            //
            //Find index to Clue Answer for highlighting in List boxes
            var tmp = SqCurrentSquare.GetClueAnswerRef(IsAcross);
            var clueAnswerIdx = 0;
            for (var k = 0; k < NNumQuestions; k++)
            {
                if (tmp != CaPuzzleClueAnswers[k]) continue;
                clueAnswerIdx = k;
                break;
            }

            //Selects the item in the list box relative to the ClueAnswer
            //and the orientation.
            if (IsAcross)
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