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
            logger.LogInformation("Start NavigateList()");

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
                                }

                                break;
                            }
                        case Keys.Down:
                            LstClueAcross.SelectedIndex++;
                            break;
                    }

                    break;
                //if Down
                case false when keyInFocus == Keys.Up:
                    {
                        if (LstClueDown.SelectedIndex is not null)
                        {
                            LstClueDown.SelectedIndex--;
                        }

                        break;
                    }
                case false:
                    {
                        if (keyInFocus == Keys.Down)
                        {
                            LstClueDown.SelectedIndex++;

                        }

                        break;
                    }
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            throw;
        }
    }
    #endregion
}
