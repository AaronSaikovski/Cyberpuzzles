using System;
using Crossword.Shared.Constants;
using Myra.Graphics2D.UI;



namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region InitListBoxes
    /// <summary>
    /// Inits Listboxes
    /// </summary>
    private void InitListBoxes()
    {
        try
        {
            _logger.LogInformation("Start InitListBoxes()");

            //List box elements

            //List box across
            InitListBoxAcross();

            //List box down
            InitListBoxDown();

            //Populate and add lists
            _mainPanel.Widgets.Add(_clueAcrossLabel);
            _mainPanel.Widgets.Add(_lstClueAcross);
            _mainPanel.Widgets.Add(_clueDownLabel);
            _mainPanel.Widgets.Add(_lstClueDown);
            _lstClueAcross.SelectedIndex = 0;
            _lstClueDown.SelectedIndex = -1;
            _lstClueAcross.Visible = false;
            _lstClueDown.Visible = false;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }

    #endregion

    #region InitListBoxDown
    /// <summary>
    /// Init listbox - Down 
    /// </summary>
    private void InitListBoxDown()
    {
        try
        {
            _logger.LogInformation("Start InitListBoxDown()");

            //Down Label
            _clueDownLabel = new Label
            {
                Text = "Clues Down",
                Font = _fntListhead,
                Left = rectCrossWord.Right + UiConstants.MainOffsetX,
                TextColor = UiConstants.ListBoxTextColor,
                Height = UiConstants.ClLabelHeight,
                Top = UiConstants.ClListboxHeight + UiConstants.ClLabelHeight + UiConstants.ClListSpacer * 3
            };

            //Down
            _lstClueDown = new ListBox
            {
                Left = rectCrossWord.Right + UiConstants.MainOffsetY,
                Top = UiConstants.ClListboxHeight + UiConstants.ClLabelHeight + UiConstants.ClListSpacer * 2 +
                      UiConstants.ClLabelHeight,
                AcceptsKeyboardFocus = true,
                SelectionMode = SelectionMode.Single,
                Height = UiConstants.ClListboxHeight
            };
            // LstClueDown = new ListView
            // {
            //     Left = rectCrossWord.Right + UIConstants.MainOffsetY,
            //     Top = UIConstants.ClListboxHeight + UIConstants.ClLabelHeight + UIConstants.ClListSpacer * 2 +
            //           UIConstants.ClLabelHeight,
            //     AcceptsKeyboardFocus = true,
            //     SelectionMode = SelectionMode.Single,
            //     Height = UIConstants.ClListboxHeight
            // };

            //set the font
            _lstClueDown.ListBoxStyle.ListItemStyle.LabelStyle.Font = _fntListFont;

            //List box event handlers
            _lstClueDown.SelectedIndexChanged += SelChangeListClueDown;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
    #endregion

    #region InitListBoxAcross
    /// <summary>
    /// Init listbox - Across 
    /// </summary>
    private void InitListBoxAcross()
    {
        try
        {
            _logger.LogInformation("Start InitListBoxAcross()");

            //Across Label
            _clueAcrossLabel = new Label
            {
                Text = "Clues Across",
                Font = _fntListhead,
                Left = rectCrossWord.Right + UiConstants.MainOffsetX,
                TextColor = UiConstants.ListBoxTextColor,
                Height = UiConstants.ClLabelHeight,
                Top = UiConstants.MainOffsetY - UiConstants.ClListSpacer * 3
            };

            //Across ListBox
            _lstClueAcross = new ListBox
            {
                Left = rectCrossWord.Right + UiConstants.MainOffsetX,
                Top = UiConstants.MainOffsetY,
                AcceptsKeyboardFocus = true,
                SelectionMode = SelectionMode.Single,
                Height = UiConstants.ClListboxHeight
            };
            // LstClueAcross = new ListView
            // {
            //     Left = rectCrossWord.Right + UIConstants.MainOffsetX,
            //     Top = UIConstants.MainOffsetY,
            //     AcceptsKeyboardFocus = true,
            //     SelectionMode = SelectionMode.Single,
            //     Height = UIConstants.ClListboxHeight
            // };

            //set the font
            _lstClueAcross.ListBoxStyle.ListItemStyle.LabelStyle.Font = _fntListFont;

            //List box event handlers
            _lstClueAcross.SelectedIndexChanged += SelChangeListClueAcross;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
    #endregion

}