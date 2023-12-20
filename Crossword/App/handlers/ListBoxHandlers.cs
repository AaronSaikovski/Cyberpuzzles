
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
        if (LstClueAcross.IsMouseInside && LstClueAcross.SelectedIndex is not null)
        {
            SqCurrentSquare.GetClueAnswerRef(IsAcross)?.HighlightSquares(SqCurrentSquare, false);

            if (LstClueAcross.SelectedIndex is not null)
            {
                if (!IsAcross)
                {
                    IsAcross = true;
                    LstClueDown.SelectedIndex = -1;
                }

                SqCurrentSquare = caPuzzleClueAnswers[(int)LstClueAcross.SelectedIndex].GetSquare();
                caPuzzleClueAnswers[(int)LstClueAcross.SelectedIndex].HighlightSquares(SqCurrentSquare, true);
            }
        }
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
        if (LstClueDown.IsMouseInside && LstClueDown.SelectedIndex is not null)
        {
            SqCurrentSquare.GetClueAnswerRef(IsAcross)?.HighlightSquares(SqCurrentSquare, false);
    
            if (IsAcross)
            {
                IsAcross = false;
                LstClueAcross.SelectedIndex = -1;
            }
    
            SqCurrentSquare = caPuzzleClueAnswers[LstClueAcross.Items.Count + (int)LstClueDown.SelectedIndex]
                .GetSquare();
            caPuzzleClueAnswers[LstClueAcross.Items.Count + (int)LstClueDown.SelectedIndex]
                .HighlightSquares(SqCurrentSquare, true);
        }
    }

    #endregion

}