using System;
using Crossword.Shared.Constants;
using Microsoft.Xna.Framework;

namespace Crossword.App;

public sealed partial class CrosswordMain
{
    #region DrawHintButton

    /// <summary>
    /// Draw hint button
    /// </summary>
    private void DrawHintButton()
    {
        try
        {
            // set the position of the button
            var hintPos =
                new Vector2(rectCrossWord.Left,
                    rectCrossWord.Bottom +
                    CWSettings.ClListSpacer *
                    2); 

            //init the PuzzleButton
            _HintButton = new PuzzleButton(_imgHintButton, hintPos);
            _HintButton.Click += HintButton_Click;
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    #endregion
}