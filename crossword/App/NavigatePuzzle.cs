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
            if (!IsAcross)
                LstClueDown.SelectedIndex = null;
            else
                LstClueAcross.SelectedIndex = null;
    
            //Sets the highlighting of the square.
            SqCurrentSquare.GetClueAnswerRef(IsAcross).HighlightSquares(SqCurrentSquare, false);

            //If left arrow key pressed get prev sq
            if (keyInFocus == Keys.Left)
            {
                if (IsAcross)
                {
                    SqCurrentSquare = SqCurrentSquare.GetPrevSq(IsAcross);
                }
                else
                {
                    SqCurrentSquare = SqCurrentSquare.GetPrevSq(!IsAcross);
                    if (SqCurrentSquare.ClDown == null)
                        IsAcross = !IsAcross;
                }
            }

            //If right arrow pressed get next sq
            if (keyInFocus == Keys.Right)
            {
                if (IsAcross)
                {
                    SqCurrentSquare = SqCurrentSquare.GetNextSq(IsAcross);
                }
                else
                {
                    SqCurrentSquare = SqCurrentSquare.GetNextSq(!IsAcross);
                    if (SqCurrentSquare.ClDown == null)
                        IsAcross = !IsAcross;
                }
                
            }
            
            //If up arrow key pressed
            if (keyInFocus == Keys.Up)
            {
                if (IsAcross)
                {
                    SqCurrentSquare = SqCurrentSquare.GetPrevSq(!IsAcross);
                    if (SqCurrentSquare.ClAcross == null)
                    {
                        IsAcross = !IsAcross;
                    }
                }
                else
                {
                    SqCurrentSquare = SqCurrentSquare.GetPrevSq(IsAcross);
                }

            }
            
            //If down arrow pressed get next sq
            if (keyInFocus == Keys.Down)
            {
                if (IsAcross)
                {
                    SqCurrentSquare = SqCurrentSquare.GetNextSq(!IsAcross);
                    if (SqCurrentSquare.ClAcross == null)
                    {
                        IsAcross = !IsAcross;
                    }
                }
                else
                {
                    SqCurrentSquare = SqCurrentSquare.GetNextSq(IsAcross);
                }
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
                if (tmp == CaPuzzleClueAnswers[k])
                {
                    clueAnswerIdx = k;
                    break;
                };
                
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