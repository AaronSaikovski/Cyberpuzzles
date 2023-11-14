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
            SqCurrentSquare.getClueAnswerRef(IsAcross).HighlightSquares(SqCurrentSquare, false);

            //If left arrow key pressed get prev sq
            if (keyInFocus == Keys.Left)
            {
                if (IsAcross)
                {
                    SqCurrentSquare = SqCurrentSquare.getPrevsq(IsAcross);
                }
                else
                {
                    SqCurrentSquare = SqCurrentSquare.getPrevsq(!IsAcross);
                    if (SqCurrentSquare.clDown == null)
                        IsAcross = !IsAcross;
                }
            }

            //If right arrow pressed get next sq
            if (keyInFocus == Keys.Right)
            {
                if (IsAcross)
                {
                    SqCurrentSquare = SqCurrentSquare.getNextsq(IsAcross);
                }
                else
                {
                    SqCurrentSquare = SqCurrentSquare.getNextsq(!IsAcross);
                    if (SqCurrentSquare.clDown == null)
                        IsAcross = !IsAcross;
                }
                
            }
            
            //If up arrow key pressed
            if (keyInFocus == Keys.Up)
            {
                if (IsAcross)
                {
                    SqCurrentSquare = SqCurrentSquare.getPrevsq(!IsAcross);
                    if (SqCurrentSquare.clAcross == null)
                    {
                        IsAcross = !IsAcross;
                    }
                }
                else
                {
                    SqCurrentSquare = SqCurrentSquare.getPrevsq(IsAcross);
                }

            }
            
            //If down arrow pressed get next sq
            if (keyInFocus == Keys.Down)
            {
                if (IsAcross)
                {
                    SqCurrentSquare = SqCurrentSquare.getNextsq(!IsAcross);
                    if (SqCurrentSquare.clAcross == null)
                    {
                        IsAcross = !IsAcross;
                    }
                }
                else
                {
                    SqCurrentSquare = SqCurrentSquare.getNextsq(IsAcross);
                }
            }
    
            //Sets the highlighting of the square.
            SqCurrentSquare.getClueAnswerRef(IsAcross).HighlightSquares(SqCurrentSquare, true);
    
            ///////////////////////////////////////
            //Listbox linkage stuff
            //
            //Find index to Clue Answer for highlighting in List boxes
            var tmp = SqCurrentSquare.getClueAnswerRef(IsAcross);
            var clueAnswerIdx = 0;
            for (var k = 0; k < _NumQuestions; k++)
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