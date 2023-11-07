using System;
using Microsoft.Xna.Framework.Input;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region NavigateList
    
    private void NavigateList(bool bIsAcross, Keys keyInFocus)
    {
        try
        {
            switch (bIsAcross)
            {
                case true:
                    switch (keyInFocus)
                    {
                        //If Across then allow operations on the across list
                        case Keys.Up:
                        {
                            if (LstClueAcross.SelectedIndex != 0)
                            {
                                LstClueAcross.SelectedIndex = LstClueAcross.SelectedIndex - 1;
                            }

                            break;
                        }
                        case Keys.Down:
                            LstClueAcross.SelectedIndex = LstClueAcross.SelectedIndex + 1;
                            break;
                    }
                   
                    break;
                case false:
                    switch (keyInFocus)
                    {
                        //if Down
                        case Keys.Up:
                        {
                            if (LstClueDown.SelectedIndex != 0)
                            {
                                LstClueDown.SelectedIndex = LstClueDown.SelectedIndex - 1;
                            }

                            break;
                        }
                        case Keys.Down:
                            LstClueDown.SelectedIndex = LstClueDown.SelectedIndex + 1;
                            break;
                    }

                    break;
            }
        }
        catch (Exception e)
        {
            //Catch the exception
            Console.WriteLine("Exception " + e + " occurred in method NavigateList");
        }
    }
    
    #endregion
}