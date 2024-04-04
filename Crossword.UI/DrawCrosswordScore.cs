

using Crossword.Shared.Constants;
using FontStashSharp;
using Myra.Graphics2D.UI;

namespace Crossword.UI;

public static partial class CrosswordUI
{
    #region DrawCrosswordScore
    
    /// Draws the crossword score and updates the values
    public static void DrawCrosswordScore(Panel mainPanel, Label currentScoreLabel, Label maxScoreLabel, bool isFinished, int crosswordScore, int numQuestions, DynamicSpriteFont labelFont, int posBottom)
    {
        // try
        // {
        //     if (!isFinished)
        //     {
        //         //Current score label
        //         mainPanel.Widgets.Remove(currentScoreLabel);
        //         currentScoreLabel.Text = $"Your Score: {crosswordScore.ToString()}";
        //         currentScoreLabel.TextColor = UIConstants.ScoreColor;
        //         currentScoreLabel.Left = UIConstants.ClListSpacer * 40;
        //         currentScoreLabel.Font = labelFont;
        //         currentScoreLabel.Top = posBottom + UIConstants.ClListSpacer * 2;
        //         mainPanel.Widgets.Add(currentScoreLabel);
        //     }
        //     else
        //     {
        //         //Game over label
        //         mainPanel.Widgets.Remove(currentScoreLabel);
        //         currentScoreLabel.Text = "GAME OVER!";
        //         currentScoreLabel.TextColor = UIConstants.ScoreColor;
        //         currentScoreLabel.Left = UIConstants.ClListSpacer * 40;
        //         currentScoreLabel.Font = labelFont;
        //         currentScoreLabel.Top = posBottom + UIConstants.ClListSpacer * 2;
        //         mainPanel.Widgets.Add(currentScoreLabel);
        //     }
        //
        //     //Max score label
        //     mainPanel.Widgets.Remove(maxScoreLabel);
        //     maxScoreLabel.Text = $"Max Score: {numQuestions.ToString()}";
        //     maxScoreLabel.TextColor = UIConstants.ScoreColor;
        //     maxScoreLabel.Left = UIConstants.ClListSpacer * 40;
        //     maxScoreLabel.Font = labelFont;
        //     maxScoreLabel.Top = posBottom + UIConstants.ClListSpacer * 6;
        //     mainPanel.Widgets.Add(maxScoreLabel);
        //
        // }
        // catch (Exception ex)
        // {
        //     throw;
        // }
        
        if (!isFinished)
        {
            //Current score label
            mainPanel.Widgets.Remove(currentScoreLabel);
            currentScoreLabel.Text = $"Your Score: {crosswordScore.ToString()}";
            currentScoreLabel.TextColor = UIConstants.ScoreColor;
            currentScoreLabel.Left = UIConstants.ClListSpacer * 40;
            currentScoreLabel.Font = labelFont;
            currentScoreLabel.Top = posBottom + UIConstants.ClListSpacer * 2;
            mainPanel.Widgets.Add(currentScoreLabel);
        }
        else
        {
            //Game over label
            mainPanel.Widgets.Remove(currentScoreLabel);
            currentScoreLabel.Text = "GAME OVER!";
            currentScoreLabel.TextColor = UIConstants.ScoreColor;
            currentScoreLabel.Left = UIConstants.ClListSpacer * 40;
            currentScoreLabel.Font = labelFont;
            currentScoreLabel.Top = posBottom + UIConstants.ClListSpacer * 2;
            mainPanel.Widgets.Add(currentScoreLabel);
        }

        //Max score label
        mainPanel.Widgets.Remove(maxScoreLabel);
        maxScoreLabel.Text = $"Max Score: {numQuestions.ToString()}";
        maxScoreLabel.TextColor = UIConstants.ScoreColor;
        maxScoreLabel.Left = UIConstants.ClListSpacer * 40;
        maxScoreLabel.Font = labelFont;
        maxScoreLabel.Top = posBottom + UIConstants.ClListSpacer * 6;
        mainPanel.Widgets.Add(maxScoreLabel);
    }
    #endregion
}