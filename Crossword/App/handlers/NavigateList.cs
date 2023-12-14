using System;
using Microsoft.Xna.Framework.Input;

namespace Crossword.App;

public sealed partial class CrosswordMain
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
            _logger.LogInformation("Start NavigateList()");
            
            switch (bIsAcross)
            {
                case true:
                    switch (keyInFocus)
                    {
                        //If Across then allow operations on the across list
                        case Keys.Up:
                        {
                            if (LstClueAcross.SelectedIndex is not null)
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
                    if (LstClueDown.SelectedIndex is not null)
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
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
            throw;
        }
    }
    #endregion
}
