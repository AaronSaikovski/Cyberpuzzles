using System;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region ListBox_EventHandlers

    // Event handler for the Across listbox
    private void SelChangeListClueAcross(object sender, EventArgs args)
    {
        try
        {
            sqCurrentSquare.getClueAnswerRef(bIsAcross).HighlightSquares(sqCurrentSquare, false);

            if (LstClueAcross.SelectedIndex != null)
            {
                if (!bIsAcross){
                    bIsAcross=true;
                    LstClueDown.SelectedIndex = -1;
                }
                sqCurrentSquare = caPuzzleClueAnswers[(int)LstClueAcross.SelectedIndex].getSquare();
                caPuzzleClueAnswers[(int)LstClueAcross.SelectedIndex].HighlightSquares(sqCurrentSquare, true);
            }
        }
        catch (Exception e) {

            //Catch the exception
            Console.WriteLine("Exception " + e + " occurred in method SelChangeListClueAcross");
        }

    }

    //Event handler for the Down listbox
    private void SelChangeListClueDown(object sender, EventArgs args)
    {
        try
        {
            //causing an exception
            //sqCurrentSquare.getClueAnswerRef(bIsAcross).HighlightSquares(sqCurrentSquare, false);

            if (LstClueDown.SelectedIndex != null)
            {
                sqCurrentSquare.getClueAnswerRef(bIsAcross).HighlightSquares(sqCurrentSquare, false);
                
                if (bIsAcross)
                {
                    bIsAcross = false;
                    LstClueAcross.SelectedIndex = -1;
                }

                sqCurrentSquare = caPuzzleClueAnswers[LstClueAcross.Items.Count + (int)LstClueDown.SelectedIndex]
                    .getSquare();
                caPuzzleClueAnswers[LstClueAcross.Items.Count + (int)LstClueDown.SelectedIndex]
                    .HighlightSquares(sqCurrentSquare, true);
            }
        }
        catch (Exception e) {

            //Catch the exception
            Console.WriteLine("Exception " + e + " occurred in method SelChangeListClueDown");
        }
        

    }

    #endregion
    
}