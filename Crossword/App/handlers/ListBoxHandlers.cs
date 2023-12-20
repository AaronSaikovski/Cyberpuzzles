
using System;

namespace Crossword.App;

public sealed partial class CrosswordMain
{

    #region SelChangeListClueAcross

    /// <summary>
    /// SelChangeListClueAcross
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void SelChangeListClueAcross(object sender, EventArgs args)
    {
        // if (LstClueAcross is not { IsMouseInside: true, SelectedIndex: not null }) return;
        // logger.LogInformation("Start SelChangeListClueAcross()");
        //
        // if (SqCurrentSquare != null)
        // {
        //     SqCurrentSquare?.GetClueAnswerRef(IsAcross)?.HighlightSquares(SqCurrentSquare, false);
        //
        //     if (LstClueAcross.SelectedIndex is null) return;
        //     if (!IsAcross)
        //     {
        //         IsAcross = true;
        //         LstClueDown.SelectedIndex = -1;
        //     }
        // }
        //
        // SqCurrentSquare = caPuzzleClueAnswers[(int)LstClueAcross.SelectedIndex].GetSquare();
        // caPuzzleClueAnswers[(int)LstClueAcross.SelectedIndex].HighlightSquares(SqCurrentSquare, true);
    }

    #endregion

    #region SelChangeListClueDown

    /// <summary>
    /// SelChangeListClueDown
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void SelChangeListClueDown(object sender, EventArgs args)
    {
        // if (!LstClueDown.IsMouseInside || LstClueDown.SelectedIndex is null) return;
        // logger.LogInformation("Start SelChangeListClueDown()");
        //
        // if (SqCurrentSquare == null) return;
        // SqCurrentSquare?.GetClueAnswerRef(IsAcross)?.HighlightSquares(SqCurrentSquare, false);
        //
        // if (IsAcross)
        // {
        //     IsAcross = false;
        //     LstClueAcross.SelectedIndex = -1;
        // }
        // SqCurrentSquare = caPuzzleClueAnswers[LstClueAcross.Items.Count + (int)LstClueDown.SelectedIndex]
        //     .GetSquare();
        // caPuzzleClueAnswers[LstClueAcross.Items.Count + (int)LstClueDown.SelectedIndex]
        //     .HighlightSquares(SqCurrentSquare, true);


    }

    #endregion

}