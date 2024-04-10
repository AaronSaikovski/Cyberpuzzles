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
            _logger.LogInformation("Start NavigateList()");

            switch (bIsAcross)
            {
                case true:
                    switch (keyInFocus)
                    {
                        //If Across then allow operations on the across list
                        case Keys.Up:
                            {
                                if (_lstClueAcross != null && _lstClueAcross.SelectedIndex is not null)
                                {
                                    _lstClueAcross.SelectedIndex--;
                                }

                                break;
                            }
                        case Keys.Down:
                            if (_lstClueAcross != null) _lstClueAcross.SelectedIndex++;
                            break;
                    }

                    break;
                //if Down
                case false when keyInFocus == Keys.Up:
                    {
                        if (_lstClueDown != null && _lstClueDown.SelectedIndex is not null)
                        {
                            _lstClueDown.SelectedIndex--;
                        }

                        break;
                    }
                case false:
                    {
                        if (keyInFocus == Keys.Down)
                        {
                            if (_lstClueDown != null) _lstClueDown.SelectedIndex++;
                        }

                        break;
                    }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
    #endregion
}
