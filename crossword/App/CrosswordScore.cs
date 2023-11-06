using CyberPuzzles.Crossword.Constants;
using Microsoft.Xna.Framework;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region CrosswordScore

    public void UpdateCrosswordScore()
    {
        nCrosswordScore = 0;
        for (var i = 0; i < nNumQuestions; i++)
        {
            if (caPuzzleClueAnswers[i].IsCorrect())
            {
                nCrosswordScore++;
            }

            caPuzzleClueAnswers[i].CheckWord();
        }

        if (nCrosswordScore == nNumQuestions)
        {
            bIsFinished = true;
        }
    }

    private void DrawCrosswordScore()
    {
        if (!bIsFinished)
        {
            //Current score label
            _MainPanel.Widgets.Remove(CurrentScoreLabel);
            CurrentScoreLabel.Text = "Your Score: " + nCrosswordScore;
            CurrentScoreLabel.TextColor = Color.Red;
            CurrentScoreLabel.Left = 300 + 250;
            CurrentScoreLabel.Font = fntScore;
            CurrentScoreLabel.Top = CWSettings.MAIN_OFFSET_Y;
            _MainPanel.Widgets.Add(CurrentScoreLabel);


            //Max score label
            //panel.Widgets.Remove(MaxScoreLabel);
            //MaxScoreLabel.Text = "Max Score: " + nNumQuestions.ToString();
            //MaxScoreLabel.TextColor = Color.Red;
            //MaxScoreLabel.Left = 300 + 250;
            //MaxScoreLabel.Font = fntScore;
            //MaxScoreLabel.Top = Constants.MAIN_OFFSET_Y + 20;
            //panel.Widgets.Add(MaxScoreLabel);
        }
        else
        {
            //Current score label
            _MainPanel.Widgets.Remove(CurrentScoreLabel);
            CurrentScoreLabel.Text = "GAME OVER!";
            CurrentScoreLabel.TextColor = Color.Red;
            CurrentScoreLabel.Left = 300 + 250;
            CurrentScoreLabel.Font = fntScore;
            CurrentScoreLabel.Top = CWSettings.MAIN_OFFSET_Y;
            _MainPanel.Widgets.Add(CurrentScoreLabel);

            //Max score label - remove             
            //panel.Widgets.Remove(MaxScoreLabel);
        }


        //Max score label
        _MainPanel.Widgets.Remove(MaxScoreLabel);
        MaxScoreLabel.Text = "Max Score: " + nNumQuestions;
        MaxScoreLabel.TextColor = Color.Red;
        MaxScoreLabel.Left = 300 + 250;
        MaxScoreLabel.Font = fntScore;
        MaxScoreLabel.Top = CWSettings.MAIN_OFFSET_Y + 20;
        _MainPanel.Widgets.Add(MaxScoreLabel);
    }

    #endregion
}