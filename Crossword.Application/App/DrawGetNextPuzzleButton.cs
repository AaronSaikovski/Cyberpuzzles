using System;
using Crossword.Shared.Constants;
using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;

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
            var leftPos = rectCrossWord.Left+ _HintButton.Bounds.Width + CWSettings.ClListSpacer;
            // set the position of the button
            var nextPos =
                new Vector2(leftPos,
                    rectCrossWord.Bottom +
                    CWSettings.ClListSpacer *
                    2); 
            
            //init the PuzzleButton
            _NextPuzzButton = new PuzzleButton(_imgNextPuzzButton, nextPos);
            
            //assign event handler
            _NextPuzzButton.Click += NextPuzzleButton_Click;
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion
}