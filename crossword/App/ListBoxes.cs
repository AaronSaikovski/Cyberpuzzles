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

    private void DrawListHeaders()
    {
        //Quick
        //if (szPuzzleType.equals("QX"))
        //{
        //    g.setFont(fntListhead);
        //    g.setColor(Color.black);
        //    g.drawString("Clues Across", ptTopAcross.x, ptTopAcross.y);
        //    g.drawString("Clues Down", ptTopDown.x, ptTopDown.y);
        //}

        ////TV
        //else if (szPuzzleType.equals("TX"))
        //{ //TV
        //    g.setFont(fntListhead);
        //    g.setColor(Color.white);
        //    g.drawString("Clues Across", ptTopAcross.x, ptTopAcross.y);
        //    g.drawString("Clues Down", ptTopDown.x, ptTopDown.y);
        //}

        ////Junior
        //else if (szPuzzleType.equals("JX"))
        //{
        //    g.setFont(fntListhead);
        //    g.setColor(Color.black);
        //    g.drawString("Clues Across", ptTopAcross.x, ptTopAcross.y);
        //    g.drawString("Clues Down", ptTopDown.x, ptTopDown.y);
        //}
    }
}