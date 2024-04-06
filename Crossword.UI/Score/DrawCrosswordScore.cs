using Crossword.Shared.Constants;
using FontStashSharp;
using Myra.Graphics2D.UI;

namespace Crossword.UI.Score;

public static class CrosswordScore
{
    #region DrawCrosswordScore

    /// Draws the crossword score and updates the values
    public static void DrawCrosswordScore(Panel mainPanel, Myra.Graphics2D.UI.Label currentScoreLabel, Myra.Graphics2D.UI.Label maxScoreLabel, bool isFinished, int crosswordScore, int numQuestions, DynamicSpriteFont labelFont, int posBottom)
    {
        if (!isFinished)
        {
            //Current score label
            mainPanel.Widgets.Remove(currentScoreLabel);
            currentScoreLabel.Text = $"Your Score: {crosswordScore.ToString()}";
            currentScoreLabel.TextColor = UiConstants.ScoreColor;
            currentScoreLabel.Left = UiConstants.ClListSpacer * 40;
            currentScoreLabel.Font = labelFont;
            currentScoreLabel.Top = posBottom + UiConstants.ClListSpacer * 2;
            mainPanel.Widgets.Add(currentScoreLabel);
        }
        else
        {
            //Game over label
            mainPanel.Widgets.Remove(currentScoreLabel);
            currentScoreLabel.Text = "GAME OVER!";
            currentScoreLabel.TextColor = UiConstants.ScoreColor;
            currentScoreLabel.Left = UiConstants.ClListSpacer * 40;
            currentScoreLabel.Font = labelFont;
            currentScoreLabel.Top = posBottom + UiConstants.ClListSpacer * 2;
            mainPanel.Widgets.Add(currentScoreLabel);
        }

        //Max score label
        mainPanel.Widgets.Remove(maxScoreLabel);
        maxScoreLabel.Text = $"Max Score: {numQuestions.ToString()}";
        maxScoreLabel.TextColor = UiConstants.ScoreColor;
        maxScoreLabel.Left = UiConstants.ClListSpacer * 40;
        maxScoreLabel.Font = labelFont;
        maxScoreLabel.Top = posBottom + UiConstants.ClListSpacer * 6;
        mainPanel.Widgets.Add(maxScoreLabel);
    }
    #endregion
}