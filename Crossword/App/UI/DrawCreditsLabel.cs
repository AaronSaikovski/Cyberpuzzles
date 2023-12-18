using System;

using Crossword.Constants;
namespace Crossword.App;

public sealed partial class CrosswordMain
{
#region DrawCreditsLabel
   /// <summary>
   /// Draws a Credits label
   /// </summary>
    private void DrawCreditsLabel()
    {
        try
        {
            _logger.LogInformation("Start DrawCreditsLabel()");

            //Max score label
            _mainPanel.Widgets.Remove(_creditsLabel);
            _creditsLabel.Text = GameConstants.CreditsText;
            _creditsLabel.TextColor = UIConstants.CreditsColor;
            _creditsLabel.Left = rectCrossWord.Left;
            _creditsLabel.Font = _fntCredits;
            _creditsLabel.Top = rectCrossWord.Bottom + UIConstants.ClListSpacer + UIConstants.SquareHeight + UIConstants.SquareHeight/2;
            _mainPanel.Widgets.Add(_creditsLabel);
        
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
            throw;
        }
    }
    #endregion
}