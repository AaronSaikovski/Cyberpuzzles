using CyberPuzzles.Crossword.Constants;
using Microsoft.Xna.Framework;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region CrosswordScore

    public void UpdateCrosswordScore()
    {
        NCrosswordScore = 0;
        for (var i = 0; i < NNumQuestions; i++)
        {
            if (CaPuzzleClueAnswers[i].IsCorrect())
            {
                NCrosswordScore++;
            }

            CaPuzzleClueAnswers[i].CheckWord();
        }

        if (NCrosswordScore == NNumQuestions)
        {
            BIsFinished = true;
        }
    }

    private void DrawCrosswordScore()
    {
        if (!BIsFinished)
        {
            //Current score label
            _mainPanel.Widgets.Remove(_currentScoreLabel);
            _currentScoreLabel.Text = "Your Score: " + NCrosswordScore;
            _currentScoreLabel.TextColor = Color.Red;
            _currentScoreLabel.Left = 300 + 250;
            _currentScoreLabel.Font = _fntScore;
            _currentScoreLabel.Top = CwSettings.MainOffsetY;
            _mainPanel.Widgets.Add(_currentScoreLabel);


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
            _mainPanel.Widgets.Remove(_currentScoreLabel);
            _currentScoreLabel.Text = "GAME OVER!";
            _currentScoreLabel.TextColor = Color.Red;
            _currentScoreLabel.Left = 300 + 250;
            _currentScoreLabel.Font = _fntScore;
            _currentScoreLabel.Top = CwSettings.MainOffsetY;
            _mainPanel.Widgets.Add(_currentScoreLabel);

            //Max score label - remove             
            //panel.Widgets.Remove(MaxScoreLabel);
        }


        //Max score label
        _mainPanel.Widgets.Remove(_maxScoreLabel);
        _maxScoreLabel.Text = "Max Score: " + NNumQuestions;
        _maxScoreLabel.TextColor = Color.Red;
        _maxScoreLabel.Left = 300 + 250;
        _maxScoreLabel.Font = _fntScore;
        _maxScoreLabel.Top = CwSettings.MainOffsetY + 20;
        _mainPanel.Widgets.Add(_maxScoreLabel);
    }

    #endregion
}