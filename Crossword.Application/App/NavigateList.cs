using System;
using Microsoft.Xna.Framework.Input;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region NavigateList
    /// <summary>
    /// Allows up and down navigation of the listbox contents.
    /// </summary>
    /// <param name="bIsAcross"></param>
    /// <param name="keyInFocus"></param>
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
                            if (LstClueAcross.SelectedIndex != null)
                            {
                                LstClueAcross.SelectedIndex--;
                         
                                //selChangeLstClueAcross(evt);
                                //SelChangeListClueAcross();
                            }

                            break;
                        }
                        case Keys.Down:
                            LstClueAcross.SelectedIndex++;
                        
                            //selChangeLstClueAcross(evt);
                            //SelChangeListClueAcross();
                            break;
                    }

                    break;
                //if Down
                case false when keyInFocus == Keys.Up:
                {
                    if (LstClueDown.SelectedIndex != null)
                    {
                        LstClueDown.SelectedIndex--;
                        //TODO - add handler
                        //selChangeLstClueDown(evt);
                        //SelChangeListClueAcross();
                    }

                    break;
                }
                case false:
                {
                    if (keyInFocus == Keys.Down)
                    {
                        LstClueDown.SelectedIndex++;
                        //TODO - add handler
                        //selChangeLstClueDown(evt);
                        //SelChangeListClueAcross();
                    }

                    break;
                }
            }
        }
        catch (Exception e)
        { //Catch the exception
            Console.WriteLine("Exception " + e + " occurred in method NavigateList");
        }
    }
    #endregion
}
