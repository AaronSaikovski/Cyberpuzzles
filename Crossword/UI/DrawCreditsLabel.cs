// using System;
//
// using Crossword.Shared.Constants;
// using Myra.Graphics2D.UI;
//
// namespace Crossword.App;
//
// public sealed partial class CrosswordMain
// {
// // #region DrawCreditsLabel
// //    /// <summary>
// //    /// Draws a Credits label
// //    /// </summary>
// //     // private void DrawCreditsLabel()
// //     // {
// //     //     try
// //     //     {
// //     //         logger.LogInformation("Start DrawCreditsLabel()");
// //     //
// //     //         //Max score label
// //     //         _mainPanel.Widgets.Remove(_creditsLabel);
// //     //         _creditsLabel.Text = GameConstants.CreditsText;
// //     //         _creditsLabel.TextColor = UIConstants.CreditsColor;
// //     //         _creditsLabel.Left = rectCrossWord.Left;
// //     //         _creditsLabel.Font = _fntCredits;
// //     //         _creditsLabel.Top = rectCrossWord.Bottom + UIConstants.ClListSpacer + UIConstants.SquareHeight + UIConstants.SquareHeight/2;
// //     //         _mainPanel.Widgets.Add(_creditsLabel);
// //     //     
// //     //     }
// //     //     catch (Exception ex)
// //     //     {
// //     //         logger.LogError(ex,ex.Message);
// //     //         throw;
// //     //     }
// //     // }
// //     
//     private void DrawCreditsLabel(Panel mainPanel, Label creditsLabel)
//     {
//         try
//         {
//             logger.LogInformation("Start DrawCreditsLabel()");
//
//             //Max score label
//             mainPanel.Widgets.Remove(creditsLabel);
//             creditsLabel.Text = GameConstants.CreditsText;
//             creditsLabel.TextColor = UIConstants.CreditsColor;
//             creditsLabel.Left = rectCrossWord.Left;
//             creditsLabel.Font = _fntCredits;
//             creditsLabel.Top = rectCrossWord.Bottom + UIConstants.ClListSpacer + UIConstants.SquareHeight + UIConstants.SquareHeight/2;
//             mainPanel.Widgets.Add(creditsLabel);
//         
//         }
//         catch (Exception ex)
//         {
//             logger.LogError(ex,ex.Message);
//             throw;
//         }
//     }
//    // #endregion
// }