using System;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region ListBox_EventHandlers

    // Event handler for the Across listbox
    private void SelChangeListClueAcross(object sender, EventArgs args)
    {
        if (LstClueAcross.SelectedIndex == null) return;

        //set focus state
        nFocusState = 1;

        if (LstClueAcross.IsKeyboardFocused || LstClueAcross.IsMouseInside)
        {
            //if (LstClueAcross.SelectedIndex == null) return;
            sqCurrentSquare.getClueAnswerRef(bIsAcross).HighlightSquares(sqCurrentSquare, false);
        
            if (bIsAcross)
            {
                bIsAcross = true;
                LstClueDown.SelectedIndex = null;
            }
        
            sqCurrentSquare = caPuzzleClueAnswers[(int)LstClueAcross.SelectedIndex].getSquare();
            caPuzzleClueAnswers[(int)LstClueAcross.SelectedIndex].HighlightSquares(sqCurrentSquare, true);
        
        }

    }

    //Event handler for the Down listbox
    private void SelChangeListClueDown(object sender, EventArgs args)
    {
     
        if (LstClueDown.SelectedIndex == null) return;
        
        //set focus state
        nFocusState = 1;
        
        //LstClueAcross.SelectedIndex = -1;
        if (LstClueDown.IsKeyboardFocused || LstClueDown.IsMouseInside)
        {
            //if (LstClueDown.SelectedIndex == null) return;
            sqCurrentSquare.getClueAnswerRef(bIsAcross).HighlightSquares(sqCurrentSquare, false);
        
            if (bIsAcross)
            {
                bIsAcross = false;
                LstClueAcross.SelectedIndex = null;
            }
        
            sqCurrentSquare = caPuzzleClueAnswers[LstClueAcross.Items.Count + (int)LstClueDown.SelectedIndex]
                .getSquare();
            caPuzzleClueAnswers[LstClueAcross.Items.Count + (int)LstClueDown.SelectedIndex]
                 .HighlightSquares(sqCurrentSquare, true);
            
        
        
        }
    }

    #endregion

    
}