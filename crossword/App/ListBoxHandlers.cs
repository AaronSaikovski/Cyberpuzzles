using System;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region ListBox_EventHandlers

    private void SelChangeLstClueAcross(object sender, EventArgs args)
    {
        if (LstClueAcross.SelectedIndex == null) return;
        SqCurrentSquare.GetClueAnswerRef(BIsAcross).HighlightSquares(SqCurrentSquare, false);

        if (!BIsAcross)
        {
            BIsAcross = true;
            LstClueDown.SelectedIndex = -1;
        }

        SqCurrentSquare = CaPuzzleClueAnswers[(int)LstClueAcross.SelectedIndex].GetSquare();
        CaPuzzleClueAnswers[(int)LstClueAcross.SelectedIndex].HighlightSquares(SqCurrentSquare, true);
    }

    private void SelChangeLstClueDown(object sender, EventArgs args)
    {
        if (LstClueDown.SelectedIndex == null) return;
        SqCurrentSquare.GetClueAnswerRef(BIsAcross).HighlightSquares(SqCurrentSquare, false);
        if (BIsAcross)
        {
            BIsAcross = false;
            LstClueAcross.SelectedIndex = -1;
        }

        SqCurrentSquare = CaPuzzleClueAnswers[LstClueAcross.Items.Count + (int)LstClueDown.SelectedIndex].GetSquare();
        CaPuzzleClueAnswers[LstClueAcross.Items.Count + (int)LstClueDown.SelectedIndex]
            .HighlightSquares(SqCurrentSquare, true);
    }

    #endregion

    
}