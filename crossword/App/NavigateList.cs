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
                            if (lstClueAcross.SelectedIndex != 0)
                            {
                                lstClueAcross.SelectedIndex = lstClueAcross.SelectedIndex - 1;
                            }

                            break;
                        }
                        case Keys.Down:
                            lstClueAcross.SelectedIndex = lstClueAcross.SelectedIndex + 1;
                            break;
                    }
                   
                    break;
                case false:
                    switch (keyInFocus)
                    {
                        //if Down
                        case Keys.Up:
                        {
                            if (lstClueDown.SelectedIndex != 0)
                            {
                                lstClueDown.SelectedIndex = lstClueDown.SelectedIndex - 1;
                            }

                            break;
                        }
                        case Keys.Down:
                            lstClueDown.SelectedIndex = lstClueDown.SelectedIndex + 1;
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