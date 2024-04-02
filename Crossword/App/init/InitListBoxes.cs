using System;
using Crossword.Constants;
using Myra.Graphics2D.UI;



namespace Crossword.App;

public sealed partial class CrosswordMain
{
    #region InitListBoxes
    /// <summary>
    /// Inits Listboxes
    /// </summary>
    private void InitListBoxes()
    {
        try
        {
            logger.LogInformation("Start InitListBoxes()");
            
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
        catch (Exception ex)
        {
            logger.LogError(ex,ex.Message);
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
            logger.LogInformation("Start InitListBoxDown()");
            
            //Down Label
            _clueDownLabel = new Label
            {
                Text = "Clues Down",
                Font = _fntListhead,
                Left = rectCrossWord.Right + UIConstants.MainOffsetX,
                TextColor = UIConstants.ListBoxTextColor,
                Height = UIConstants.ClLabelHeight,
                Top = UIConstants.ClListboxHeight + UIConstants.ClLabelHeight + UIConstants.ClListSpacer * 3
            };

            //Down
            LstClueDown = new ListBox
            {
                Left = rectCrossWord.Right + UIConstants.MainOffsetY,
                Top = UIConstants.ClListboxHeight + UIConstants.ClLabelHeight + UIConstants.ClListSpacer * 2 +
                      UIConstants.ClLabelHeight,
                AcceptsKeyboardFocus = true,
                SelectionMode = SelectionMode.Single,
                Height = UIConstants.ClListboxHeight
            };

            //set the font
            LstClueDown.ListBoxStyle.ListItemStyle.LabelStyle.Font = _fntListFont;

            //List box event handlers
            LstClueDown.SelectedIndexChanged += SelChangeListClueDown;
        
        }
        catch (Exception ex)
        {
            logger.LogError(ex,ex.Message);
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
            logger.LogInformation("Start InitListBoxAcross()");
            
            //Across Label
            _clueAcrossLabel = new Label
            {
                Text = "Clues Across",
                Font = _fntListhead,
                Left = rectCrossWord.Right + UIConstants.MainOffsetX,
                TextColor = UIConstants.ListBoxTextColor,
                Height = UIConstants.ClLabelHeight,
                Top = UIConstants.MainOffsetY - UIConstants.ClListSpacer * 3
            };

            //Across ListBox
            LstClueAcross = new ListBox
            {
                Left = rectCrossWord.Right + UIConstants.MainOffsetX,
                Top = UIConstants.MainOffsetY,
                AcceptsKeyboardFocus = true,
                SelectionMode = SelectionMode.Single,
                Height = UIConstants.ClListboxHeight
            };

            //set the font
            LstClueAcross.ListBoxStyle.ListItemStyle.LabelStyle.Font = _fntListFont;

            //List box event handlers
            LstClueAcross.SelectedIndexChanged += SelChangeListClueAcross;
        
        }
        catch (Exception ex)
        {
            logger.LogError(ex,ex.Message);
            throw;
        }
    }
    #endregion

}