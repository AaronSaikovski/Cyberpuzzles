using System;
using Microsoft.Xna.Framework.Input;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{

    /// <summary>
    /// Allows up and down navigation of the listbox contents.
    /// </summary>
    /// <param name="bIsAcross"></param>
    /// <param name="keyInFocus"></param>
    private void NavigateList(bool bIsAcross, Keys keyInFocus)
    {

        try 
        {
            if (bIsAcross) { //If Across then allow operations on the across list
                if (keyInFocus == Keys.Up)
                {
                    if (LstClueAcross.SelectedIndex != null){
                        LstClueAcross.SelectedIndex = LstClueAcross.SelectedIndex - 1;
                        //TODO - add handler
                        //selChangeLstClueAcross(evt);
                        //SelChangeListClueAcross();
                    }
                }
                else if (keyInFocus == Keys.Down){
                    LstClueAcross.SelectedIndex = LstClueAcross.SelectedIndex + 1;
                    //TODO - add handler
                    //selChangeLstClueAcross(evt);
                    //SelChangeListClueAcross();
                }

            }
            else if (!bIsAcross) { //if Down
                if (keyInFocus == Keys.Up) 
                {
                    if (LstClueDown.SelectedIndex != null){
                        LstClueDown.SelectedIndex = LstClueDown.SelectedIndex - 1;
                        //TODO - add handler
                        //selChangeLstClueDown(evt);
                        //SelChangeListClueAcross();
                    }
                }
                else if (keyInFocus == Keys.Down){
                    LstClueDown.SelectedIndex = LstClueDown.SelectedIndex + 1;
                    //TODO - add handler
                    //selChangeLstClueDown(evt);
                    //SelChangeListClueAcross();
                }
            }
        }
        catch (Exception e) { //Catch the exception
            Console.WriteLine("Exception " + e + " occurred in method NavigateList");
        }
    }
}
