using Crossword.Shared.Constants;
using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region InitGetNextPuzzleButton

    /// <summary>
    /// Draw get next puzzle button
    /// </summary>
    private void InitGetNextPuzzleButton()
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
        _NextPuzzButton.Click += NextPuzzleButton_Click;
        
        // GetNextPuzzleButton = new TextButton
        // {
        //     Text = "Get Next Puzzle",
        //     Id = "NextPuzzleButton",
        //     TextColor = CWSettings.ButtonTextColor,
        //     OverTextColor = CWSettings.ButtonHoverTextColor,
        //     Left = rectCrossWord.Left,
        //     Top = rectCrossWord.Bottom + CWSettings.ClListSpacer * 8
        // };
        //
        // GetNextPuzzleButton.Click += NextPuzzleButton_Click;
        // _mainPanel.Widgets.Add(GetNextPuzzleButton);
    }

    #endregion
}