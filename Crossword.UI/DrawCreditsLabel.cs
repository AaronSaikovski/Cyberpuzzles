
using Crossword.Shared.Constants;
using FontStashSharp;
using Myra.Graphics2D.UI;

namespace Crossword.UI;

public static partial class CrosswordUi
{
    #region DrawCreditsLabel
    
    /// <summary>
    /// Draws credit label
    /// </summary>
    /// <param name="mainPanel"></param>
    /// <param name="creditsLabel"></param>
    /// <param name="posLeft"></param>
    /// <param name="posBottom"></param>
    /// <param name="labelFont"></param>
    public static void DrawCreditsLabel(Panel mainPanel, Label creditsLabel, int posLeft, int posBottom, DynamicSpriteFont labelFont)
    {
        // try
        // {
        //     //Max score label
        //     mainPanel.Widgets.Remove(creditsLabel);
        //     creditsLabel.Text = GameConstants.CreditsText;
        //     creditsLabel.TextColor = UIConstants.CreditsColor;
        //     creditsLabel.Left = posLeft;
        //     creditsLabel.Font = labelFont;
        //     creditsLabel.Top = posBottom + UIConstants.ClListSpacer + UIConstants.SquareHeight + UIConstants.SquareHeight/2;
        //     mainPanel.Widgets.Add(creditsLabel);
        //
        // }
        // catch (Exception ex)
        // {
        //     throw;
        // }
        //Max score label
        mainPanel.Widgets.Remove(creditsLabel);
        creditsLabel.Text = GameConstants.CreditsText;
        creditsLabel.TextColor = UiConstants.CreditsColor;
        creditsLabel.Left = posLeft;
        creditsLabel.Font = labelFont;
        creditsLabel.Top = posBottom + UiConstants.ClListSpacer + UiConstants.SquareHeight + UiConstants.SquareHeight/2;
        mainPanel.Widgets.Add(creditsLabel);
    }
    
    #endregion
}