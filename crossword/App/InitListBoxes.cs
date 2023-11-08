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
        _clueAcrossLabel = new Label
        {
            Text = "Across",
            Font = _fntListhead,
            Left = RectCrossWord.Right + CwSettings.MainOffsetX,
            TextColor = Color.Black,
            Height = CwSettings.ClLabelHeight,
            Top = CwSettings.MainOffsetY - CwSettings.ClListSpacer * 3
        };

        //Across ListBox
        LstClueAcross = new ListBox
        {
            Left = RectCrossWord.Right + CwSettings.MainOffsetX,
            Top = CwSettings.MainOffsetY,
            AcceptsKeyboardFocus = true,
            SelectionMode = SelectionMode.Single,
            Height = CwSettings.ClListboxHeight
        };

        //Down Label
        _clueDownLabel = new Label
        {
            Text = "Down",
            Font = _fntListhead,
            Left = RectCrossWord.Right + CwSettings.MainOffsetX,
            TextColor = Color.Black,
            Height = CwSettings.ClLabelHeight,
            Top = CwSettings.ClListboxHeight + CwSettings.ClLabelHeight + CwSettings.ClListSpacer * 3
        };

        //Down
        LstClueDown = new ListBox
        {
            Left = RectCrossWord.Right + CwSettings.MainOffsetY,
            Top = CwSettings.ClListboxHeight + CwSettings.ClLabelHeight + CwSettings.ClListSpacer * 2 +
                  CwSettings.ClLabelHeight,
            AcceptsKeyboardFocus = true,
            SelectionMode = SelectionMode.Single,
            Height = CwSettings.ClListboxHeight
        };

        //List box event handlers
        //LstClueDown.SelectedIndexChanged += SelChangeListClueDown;
        //LstClueAcross.SelectedIndexChanged += SelChangeListClueAcross;

        //Set the listbox fonts
        LstClueAcross.ListBoxStyle.ListItemStyle.LabelStyle.Font = _fntListFont;
        LstClueDown.ListBoxStyle.ListItemStyle.LabelStyle.Font = _fntListFont;

        ////Populate and add lists
        _mainPanel.Widgets.Add(_clueAcrossLabel);
        _mainPanel.Widgets.Add(LstClueAcross);
        _mainPanel.Widgets.Add(_clueDownLabel);
        _mainPanel.Widgets.Add(LstClueDown);
        LstClueAcross.SelectedIndex = 0;
        LstClueDown.SelectedIndex = -1;
        LstClueAcross.Visible = false;
        LstClueDown.Visible = false;
    }

    #endregion
}