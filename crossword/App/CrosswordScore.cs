using CyberPuzzles.Crossword.Constants;
using Microsoft.Xna.Framework;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region UpdateCrosswordScore

    /// <summary>
    /// Updates the crossword score
    /// </summary>
    private void UpdateCrosswordScore()
    {
        CrosswordScore = 0;
        for (var i = 0; i < NumQuestions; i++)
        {
            if (caPuzzleClueAnswers[i].IsCorrect())
            {
                CrosswordScore++;
            }

            caPuzzleClueAnswers[i].CheckWord();
        }

        if (CrosswordScore == NumQuestions)
        {
            IsFinished = true;
        }
    }

    #endregion
    
    #region DrawCrosswordScore
    /// <summary>
    /// Draws the crossword score and updates the values
    /// </summary>
    private void DrawCrosswordScore()
    {
        if (!IsFinished)
        {
            //Current score label
            _mainPanel.Widgets.Remove(_currentScoreLabel);
            _currentScoreLabel.Text = $"Your Score: {CrosswordScore}";
            _currentScoreLabel.TextColor = Color.Red;
            _currentScoreLabel.Left = CwSettings.ClListSpacer * 40;
            _currentScoreLabel.Font = _fntScore;
            _currentScoreLabel.Top = rectCrossWord.Bottom + CwSettings.ClListSpacer * 2;
            _mainPanel.Widgets.Add(_currentScoreLabel);
        }
        else
        {
            //Current score label
            _mainPanel.Widgets.Remove(_currentScoreLabel);
            _currentScoreLabel.Text = "GAME OVER!";
            _currentScoreLabel.TextColor = Color.Red;
            _currentScoreLabel.Left = CwSettings.ClListSpacer * 40;
            _currentScoreLabel.Font = _fntScore;
            _currentScoreLabel.Top = rectCrossWord.Bottom + CwSettings.ClListSpacer * 2;
            _mainPanel.Widgets.Add(_currentScoreLabel);
        }


        //Max score label
        _mainPanel.Widgets.Remove(_maxScoreLabel);
        _maxScoreLabel.Text = "Max Score: " + NumQuestions;
        _maxScoreLabel.TextColor = Color.Red;
        _maxScoreLabel.Left = CwSettings.ClListSpacer * 40;
        _maxScoreLabel.Font = _fntScore;
        _maxScoreLabel.Top = rectCrossWord.Bottom + CwSettings.ClListSpacer * 6;
        _mainPanel.Widgets.Add(_maxScoreLabel);
    }
    #endregion
}