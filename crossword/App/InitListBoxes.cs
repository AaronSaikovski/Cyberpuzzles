using CyberPuzzles.Crossword.Constants;
using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region InitListBoxes

    private void InitListBoxes()
    {
        //List box elements

        //Across Label
        ClueAcrossLabel = new Label
        {
            Text = "Across",
            Font = fntListhead,
            Left = RectCrossWord.Right + CWSettings.MAIN_OFFSET_X,
            TextColor = Color.Black,
            Height = CWSettings.CL_LABEL_HEIGHT,
            Top = CWSettings.MAIN_OFFSET_Y - (CWSettings.CL_LIST_SPACER * 3)
        };

        //Across ListBox
        lstClueAcross = new ListBox
        {
            Left = RectCrossWord.Right + CWSettings.MAIN_OFFSET_X,
            Top = CWSettings.MAIN_OFFSET_Y,
            AcceptsKeyboardFocus = true,
            SelectionMode = SelectionMode.Single,
            Height = CWSettings.CL_LISTBOX_HEIGHT
        };

        //Down Label
        ClueDownLabel = new Label
        {
            Text = "Down",
            Font = fntListhead,
            Left = RectCrossWord.Right + CWSettings.MAIN_OFFSET_X,
            TextColor = Color.Black,
            Height = CWSettings.CL_LABEL_HEIGHT,
            Top = CWSettings.CL_LISTBOX_HEIGHT + CWSettings.CL_LABEL_HEIGHT + (CWSettings.CL_LIST_SPACER * 3)
        };

        //Down
        lstClueDown = new ListBox
        {
            Left = RectCrossWord.Right + CWSettings.MAIN_OFFSET_Y,
            Top = CWSettings.CL_LISTBOX_HEIGHT + CWSettings.CL_LABEL_HEIGHT + (CWSettings.CL_LIST_SPACER * 2) +
                  CWSettings.CL_LABEL_HEIGHT,
            AcceptsKeyboardFocus = true,
            SelectionMode = SelectionMode.Single,
            Height = CWSettings.CL_LISTBOX_HEIGHT
        };

        ////List box event handlers
        //lstClueDown.SelectedIndexChanged += selChangeLstClueDown;
        //lstClueAcross.SelectedIndexChanged += selChangeLstClueAcross;

        //Set the listbox fonts
        lstClueAcross.ListBoxStyle.ListItemStyle.LabelStyle.Font = fntListFont;
        lstClueDown.ListBoxStyle.ListItemStyle.LabelStyle.Font = fntListFont;

        ////Populate and add lists
        _MainPanel.Widgets.Add(ClueAcrossLabel);
        _MainPanel.Widgets.Add(lstClueAcross);
        _MainPanel.Widgets.Add(ClueDownLabel);
        _MainPanel.Widgets.Add(lstClueDown);
        lstClueAcross.SelectedIndex = 0;
        lstClueDown.SelectedIndex = -1;
        lstClueAcross.Visible = false;
        lstClueDown.Visible = false;
    }

    #endregion
}