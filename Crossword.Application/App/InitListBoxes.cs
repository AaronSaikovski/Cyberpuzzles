using CyberPuzzles.Shared;
using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region InitListBoxes
    /// <summary>
    /// Inits Listboxes
    /// </summary>
    private void InitListBoxes()
    {
        //List box elements

        //List box across
        InitListBoxAcross();

        //List box down
        InitListBoxDown();

        //Populate and add lists
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

    #region InitListBoxDown
    /// <summary>
    /// Init listbox - Down 
    /// </summary>
    private void InitListBoxDown()
    {
        //Down Label
        _clueDownLabel = new Label
        {
            Text = "Down",
            Font = _fntListhead,
            Left = rectCrossWord.Right + Constants.MainOffsetX,
            TextColor = Constants.ListBoxTextColor,
            Height = Constants.ClLabelHeight,
            Top = Constants.ClListboxHeight + Constants.ClLabelHeight + Constants.ClListSpacer * 3
        };

        //Down
        LstClueDown = new ListBox
        {
            Left = rectCrossWord.Right + Constants.MainOffsetY,
            Top = Constants.ClListboxHeight + Constants.ClLabelHeight + Constants.ClListSpacer * 2 +
                  Constants.ClLabelHeight,
            AcceptsKeyboardFocus = true,
            SelectionMode = SelectionMode.Single,
            Height = Constants.ClListboxHeight
        };

        //set the font
        LstClueDown.ListBoxStyle.ListItemStyle.LabelStyle.Font = _fntListFont;

        //List box event handlers
        //LstClueDown.SelectedIndexChanged += SelChangeListClueDown;
    }
    #endregion

    #region InitListBoxAcross
    /// <summary>
    /// Init listbox - Across 
    /// </summary>
    private void InitListBoxAcross()
    {
        //Across Label
        _clueAcrossLabel = new Label
        {
            Text = "Across",
            Font = _fntListhead,
            Left = rectCrossWord.Right + Constants.MainOffsetX,
            TextColor = Constants.ListBoxTextColor,
            Height = Constants.ClLabelHeight,
            Top = Constants.MainOffsetY - Constants.ClListSpacer * 3
        };

        //Across ListBox
        LstClueAcross = new ListBox
        {
            Left = rectCrossWord.Right + Constants.MainOffsetX,
            Top = Constants.MainOffsetY,
            AcceptsKeyboardFocus = true,
            SelectionMode = SelectionMode.Single,
            Height = Constants.ClListboxHeight
        };

        //set the font
        LstClueAcross.ListBoxStyle.ListItemStyle.LabelStyle.Font = _fntListFont;

        //List box event handlers
        //LstClueAcross.SelectedIndexChanged += SelChangeListClueAcross;
    }
    #endregion

}