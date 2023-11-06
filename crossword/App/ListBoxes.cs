using System;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region ListBox_EventHandlers

    private void selChangeLstClueAcross(object sender, EventArgs args)
    {
        if (lstClueAcross.SelectedIndex == null) return;
        sqCurrentSquare.GetClueAnswerRef(bIsAcross).HighlightSquares(sqCurrentSquare, false);

        if (!bIsAcross)
        {
            bIsAcross = true;
            lstClueDown.SelectedIndex = -1;
        }

        sqCurrentSquare = caPuzzleClueAnswers[(int)lstClueAcross.SelectedIndex].GetSquare();
        caPuzzleClueAnswers[(int)lstClueAcross.SelectedIndex].HighlightSquares(sqCurrentSquare, true);
    }

    private void selChangeLstClueDown(object sender, EventArgs args)
    {
        if (lstClueDown.SelectedIndex == null) return;
        sqCurrentSquare.GetClueAnswerRef(bIsAcross).HighlightSquares(sqCurrentSquare, false);
        if (bIsAcross)
        {
            bIsAcross = false;
            lstClueAcross.SelectedIndex = -1;
        }

        sqCurrentSquare = caPuzzleClueAnswers[lstClueAcross.Items.Count + (int)lstClueDown.SelectedIndex].GetSquare();
        caPuzzleClueAnswers[lstClueAcross.Items.Count + (int)lstClueDown.SelectedIndex]
            .HighlightSquares(sqCurrentSquare, true);
    }

    #endregion

    
}