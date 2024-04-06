using Crossword.Shared.Constants;
using FontStashSharp;
using Myra.Graphics2D.UI;

namespace Crossword.UI.Label;

public static class CrosswordLabel
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
    public static void DrawCreditsLabel(Panel mainPanel, Myra.Graphics2D.UI.Label creditsLabel, int posLeft, int posBottom, DynamicSpriteFont labelFont)
    {

        //Max score label
        mainPanel.Widgets.Remove(creditsLabel);
        creditsLabel.Text = GameConstants.CreditsText;
        creditsLabel.TextColor = UiConstants.CreditsColor;
        creditsLabel.Left = posLeft;
        creditsLabel.Font = labelFont;
        creditsLabel.Top = posBottom + UiConstants.ClListSpacer + UiConstants.SquareHeight + UiConstants.SquareHeight / 2;
        mainPanel.Widgets.Add(creditsLabel);
    }

    #endregion
}