using System;
using Crossword.Constants;
using Microsoft.Xna.Framework;


namespace Crossword.App;

public sealed partial class CrosswordMain
{
    #region DrawGetNextPuzzleButton

    /// <summary>
    /// Draw get next puzzle button
    /// </summary>
    private void DrawGetNextPuzzleButton()
    {
        try
        {
            _logger.LogInformation("Start DrawGetNextPuzzleButton()");
            
            var leftPos = rectCrossWord.Left+ _HintButton.Bounds.Width + UIConstants.ClListSpacer;
            // set the position of the button
            var nextPos =
                new Vector2(leftPos,
                    rectCrossWord.Bottom +
                    UIConstants.ClListSpacer *
                    2); 
            
            //init the PuzzleButton
            _NextPuzzButton = new PuzzleButton(_imgNextPuzzButton, nextPos);
            
            //assign event handler
            _NextPuzzButton.Click += NextPuzzleButton_Click;
        
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
            throw;
        }
    }

    #endregion
}