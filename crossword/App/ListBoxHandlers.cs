using System;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region ListBox_EventHandlers

    // Event handler for the Across listbox
    private void SelChangeListClueAcross(object sender, EventArgs args)
    {
        
        if (LstClueAcross.IsKeyboardFocused || LstClueAcross.IsMouseInside)
        {
            if (LstClueAcross.SelectedIndex == null) return;
            SqCurrentSquare.GetClueAnswerRef(IsAcross).HighlightSquares(SqCurrentSquare, false);

            if (IsAcross)
            {
                IsAcross = true;
                LstClueDown.SelectedIndex = -1;
            }

            SqCurrentSquare = CaPuzzleClueAnswers[(int)LstClueAcross.SelectedIndex].GetSquare();
            CaPuzzleClueAnswers[(int)LstClueAcross.SelectedIndex].HighlightSquares(SqCurrentSquare, true);

        }

}

    //Event handler for the Down listbox
    private void SelChangeListClueDown(object sender, EventArgs args)
    {
        
        if (LstClueDown.IsKeyboardFocused || LstClueDown.IsMouseInside)
        {
            if (LstClueDown.SelectedIndex == null) return;
            SqCurrentSquare.GetClueAnswerRef(IsAcross).HighlightSquares(SqCurrentSquare, false);

            if (IsAcross)
            {
                IsAcross = false;
                LstClueAcross.SelectedIndex = -1;
            }

            SqCurrentSquare = CaPuzzleClueAnswers[LstClueAcross.Items.Count + (int)LstClueDown.SelectedIndex]
                .GetSquare();
            CaPuzzleClueAnswers[LstClueAcross.Items.Count + (int)LstClueDown.SelectedIndex]
                .HighlightSquares(SqCurrentSquare, true);
        }
    }

    #endregion

    
}