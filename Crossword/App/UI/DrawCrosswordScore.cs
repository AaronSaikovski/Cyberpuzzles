using System;

using Crossword.Constants;

namespace Crossword.App;

public sealed partial class CrosswordMain
{
    #region DrawCrosswordScore
    /// <summary>
    /// Draws the crossword score and updates the values
    /// </summary>
    private void DrawCrosswordScore()
    {
        try
        {
            _logger.LogInformation("Start DrawCrosswordScore()");
            
            if (!IsFinished)
            {
                //Current score label
                _mainPanel.Widgets.Remove(_currentScoreLabel);
                _currentScoreLabel.Text = string.Format("Your Score: {0}", CrosswordScore.ToString());
                _currentScoreLabel.TextColor = UIConstants.ScoreColor;
                _currentScoreLabel.Left = UIConstants.ClListSpacer * 40;
                _currentScoreLabel.Font = _fntScore;
                _currentScoreLabel.Top = rectCrossWord.Bottom + UIConstants.ClListSpacer * 2;
                _mainPanel.Widgets.Add(_currentScoreLabel);
            }
            else
            {
                //Game over label
                _mainPanel.Widgets.Remove(_currentScoreLabel);
                _currentScoreLabel.Text = "GAME OVER!";
                _currentScoreLabel.TextColor = UIConstants.ScoreColor;
                _currentScoreLabel.Left = UIConstants.ClListSpacer * 40;
                _currentScoreLabel.Font = _fntScore;
                _currentScoreLabel.Top = rectCrossWord.Bottom + UIConstants.ClListSpacer * 2;
                _mainPanel.Widgets.Add(_currentScoreLabel);
            }

            //Max score label
            _mainPanel.Widgets.Remove(_maxScoreLabel);
            _maxScoreLabel.Text = string.Format("Max Score: {0}", NumQuestions.ToString());
            _maxScoreLabel.TextColor = UIConstants.ScoreColor;
            _maxScoreLabel.Left = UIConstants.ClListSpacer * 40;
            _maxScoreLabel.Font = _fntScore;
            _maxScoreLabel.Top = rectCrossWord.Bottom + UIConstants.ClListSpacer * 6;
            _mainPanel.Widgets.Add(_maxScoreLabel);
        
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
            throw;
        }
    }
    #endregion
}