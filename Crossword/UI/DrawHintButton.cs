using System;
using Crossword.Shared.Constants;
using Microsoft.Xna.Framework;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region DrawHintButton

    /// <summary>
    /// Draw hint button
    /// </summary>
    private void DrawHintButton()
    {
        try
        {
            logger.LogInformation("Start DrawHintButton()");
            
            // set the position of the button
            var hintPos =
                new Vector2(rectCrossWord.Left,
                    rectCrossWord.Bottom +
                    UiConstants.ClListSpacer *
                    2); 

            //init the PuzzleButton
            _HintButton = new PuzzleButton(_imgHintButton, hintPos);
            _HintButton.Click += HintButton_Click;
        
        }
        catch (Exception ex)
        {
            logger.LogError(ex,ex.Message);
            throw;
        }
        
    }

    #endregion
}