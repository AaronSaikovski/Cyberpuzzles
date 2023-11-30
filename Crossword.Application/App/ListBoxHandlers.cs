using System;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region SelChangeListClueAcross

    // Event handler for the Across listbox
    // private void SelChangeListClueAcross(object sender, EventArgs args)
    // {
    //     try
    //     {
    //         SqCurrentSquare.GetClueAnswerRef(IsAcross)?.HighlightSquares(SqCurrentSquare, false);
    //
    //         if (LstClueAcross.SelectedIndex != null)
    //         {
    //             if (!IsAcross)
    //             {
    //                 IsAcross = true;
    //                 LstClueDown.SelectedIndex = -1;
    //             }
    //             SqCurrentSquare = caPuzzleClueAnswers[(int)LstClueAcross.SelectedIndex].GetSquare();
    //             caPuzzleClueAnswers[(int)LstClueAcross.SelectedIndex].HighlightSquares(SqCurrentSquare, true);
    //         }
    //     }
    //     catch (Exception e)
    //     {
    //
    //         //Catch the exception
    //         Console.WriteLine($"Exception {e} occurred in method SelChangeListClueAcross");
    //     }
    //
    // }

    #endregion

    #region SelChangeListClueDown

    //Event handler for the Down listbox
    // private void SelChangeListClueDown(object sender, EventArgs args)
    // {
    //     try
    //     {
    //         //causing an exception
    //         //sqCurrentSquare.getClueAnswerRef(bIsAcross).HighlightSquares(sqCurrentSquare, false);
    //
    //         if (LstClueDown.SelectedIndex != null)
    //         {
    //             SqCurrentSquare.GetClueAnswerRef(IsAcross)?.HighlightSquares(SqCurrentSquare, false);
    //
    //             if (IsAcross)
    //             {
    //                 IsAcross = false;
    //                 LstClueAcross.SelectedIndex = -1;
    //             }
    //
    //             SqCurrentSquare = caPuzzleClueAnswers[LstClueAcross.Items.Count + (int)LstClueDown.SelectedIndex]
    //                 .GetSquare();
    //             caPuzzleClueAnswers[LstClueAcross.Items.Count + (int)LstClueDown.SelectedIndex]
    //                 .HighlightSquares(SqCurrentSquare, true);
    //         }
    //     }
    //     catch (Exception e)
    //     {
    //
    //         //Catch the exception
    //         Console.WriteLine($"Exception {e} occurred in method SelChangeListClueDown");
    //     }
    //
    //
    // }

    #endregion

}