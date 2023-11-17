using CyberPuzzles.Crossword.Constants;
using Microsoft.Xna.Framework;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region CrosswordScore

    private void UpdateCrosswordScore()
    {
        NCrosswordScore = 0;
        for (var i = 0; i < nNumQuestions; i++)
        {
            if (caPuzzleClueAnswers[i].isCorrect())
            {
                NCrosswordScore++;
            }

            caPuzzleClueAnswers[i].checkWord();
        }

        if (NCrosswordScore == nNumQuestions)
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
            _currentScoreLabel.Text = $"Your Score: {NCrosswordScore}";
            _currentScoreLabel.TextColor = Color.Red;
            _currentScoreLabel.Left = 300 + 250;
            _currentScoreLabel.Font = _fntScore;
            _currentScoreLabel.Top = CwSettings.MainOffsetY;
            _mainPanel.Widgets.Add(_currentScoreLabel);
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
        }


        //Max score label
        _mainPanel.Widgets.Remove(_maxScoreLabel);
        _maxScoreLabel.Text = "Max Score: " + nNumQuestions;
        _maxScoreLabel.TextColor = Color.Red;
        _maxScoreLabel.Left = 300 + 250;
        _maxScoreLabel.Font = _fntScore;
        _maxScoreLabel.Top = CwSettings.MainOffsetY + 20;
        _mainPanel.Widgets.Add(_maxScoreLabel);
    }

    #endregion
}