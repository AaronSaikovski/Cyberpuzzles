// using System;
//
// using Crossword.Shared.Constants;
// using Myra.Graphics2D.UI;
//
// namespace Crossword.App;
//
// public sealed partial class CrosswordApp
// {
//     #region DrawCrosswordScore
//     /// <summary>
//     /// Draws the crossword score and updates the values
//     /// </summary>
//     // private void DrawCrosswordScore()
//     // {
//     //     try
//     //     {
//     //         logger.LogInformation("Start DrawCrosswordScore()");
//     //         
//     //         if (!IsFinished)
//     //         {
//     //             //Current score label
//     //             _mainPanel.Widgets.Remove(_currentScoreLabel);
//     //             _currentScoreLabel.Text = $"Your Score: {CrosswordScore.ToString()}";
//     //             _currentScoreLabel.TextColor = UIConstants.ScoreColor;
//     //             _currentScoreLabel.Left = UIConstants.ClListSpacer * 40;
//     //             _currentScoreLabel.Font = _fntScore;
//     //             _currentScoreLabel.Top = rectCrossWord.Bottom + UIConstants.ClListSpacer * 2;
//     //             _mainPanel.Widgets.Add(_currentScoreLabel);
//     //         }
//     //         else
//     //         {
//     //             //Game over label
//     //             _mainPanel.Widgets.Remove(_currentScoreLabel);
//     //             _currentScoreLabel.Text = "GAME OVER!";
//     //             _currentScoreLabel.TextColor = UIConstants.ScoreColor;
//     //             _currentScoreLabel.Left = UIConstants.ClListSpacer * 40;
//     //             _currentScoreLabel.Font = _fntScore;
//     //             _currentScoreLabel.Top = rectCrossWord.Bottom + UIConstants.ClListSpacer * 2;
//     //             _mainPanel.Widgets.Add(_currentScoreLabel);
//     //         }
//     //
//     //         //Max score label
//     //         _mainPanel.Widgets.Remove(_maxScoreLabel);
//     //         _maxScoreLabel.Text = $"Max Score: {NumQuestions.ToString()}";
//     //         _maxScoreLabel.TextColor = UIConstants.ScoreColor;
//     //         _maxScoreLabel.Left = UIConstants.ClListSpacer * 40;
//     //         _maxScoreLabel.Font = _fntScore;
//     //         _maxScoreLabel.Top = rectCrossWord.Bottom + UIConstants.ClListSpacer * 6;
//     //         _mainPanel.Widgets.Add(_maxScoreLabel);
//     //     
//     //     }
//     //     catch (Exception ex)
//     //     {
//     //         logger.LogError(ex,ex.Message);
//     //         throw;
//     //     }
//     // }
//     
//     private void DrawCrosswordScore(Panel mainPanel, Label currentScoreLabel, Label maxScoreLabel)
//     {
//         try
//         {
//             logger.LogInformation("Start DrawCrosswordScore()");
//             
//             if (!IsFinished)
//             {
//                 //Current score label
//                 mainPanel.Widgets.Remove(currentScoreLabel);
//                 currentScoreLabel.Text = $"Your Score: {CrosswordScore.ToString()}";
//                 currentScoreLabel.TextColor = UIConstants.ScoreColor;
//                 currentScoreLabel.Left = UIConstants.ClListSpacer * 40;
//                 currentScoreLabel.Font = _fntScore;
//                 currentScoreLabel.Top = rectCrossWord.Bottom + UIConstants.ClListSpacer * 2;
//                 mainPanel.Widgets.Add(currentScoreLabel);
//             }
//             else
//             {
//                 //Game over label
//                 mainPanel.Widgets.Remove(currentScoreLabel);
//                 currentScoreLabel.Text = "GAME OVER!";
//                 currentScoreLabel.TextColor = UIConstants.ScoreColor;
//                 currentScoreLabel.Left = UIConstants.ClListSpacer * 40;
//                 currentScoreLabel.Font = _fntScore;
//                 currentScoreLabel.Top = rectCrossWord.Bottom + UIConstants.ClListSpacer * 2;
//                 mainPanel.Widgets.Add(currentScoreLabel);
//             }
//
//             //Max score label
//             mainPanel.Widgets.Remove(maxScoreLabel);
//             maxScoreLabel.Text = $"Max Score: {NumQuestions.ToString()}";
//             maxScoreLabel.TextColor = UIConstants.ScoreColor;
//             maxScoreLabel.Left = UIConstants.ClListSpacer * 40;
//             maxScoreLabel.Font = _fntScore;
//             maxScoreLabel.Top = rectCrossWord.Bottom + UIConstants.ClListSpacer * 6;
//             mainPanel.Widgets.Add(maxScoreLabel);
//         
//         }
//         catch (Exception ex)
//         {
//             logger.LogError(ex,ex.Message);
//             throw;
//         }
//     }
//     #endregion
// }