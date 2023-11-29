
using CyberPuzzles.Shared;
using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region InitHintButton
    /// <summary>
    /// Init hint button
    /// </summary>
    private void InitHintButton()
    {
        HintButton = new TextButton
        {
            Text = "Get Hint Letters",
            Id = "HintButton",
            TextColor = Constants.ButtonTextColor,
            OverTextColor = Constants.ButtonHoverTextColor, 
            Left = rectCrossWord.Left,
            Top = rectCrossWord.Bottom + Constants.ClListSpacer * 2
        };

        HintButton.Click += HintButtonClick;
        _mainPanel.Widgets.Add(HintButton);
    }
    #endregion

    #region InitGetNextPuzzleButton
    /// <summary>
    /// Init get next puzzle button
    /// </summary>
    private void InitGetNextPuzzleButton()
    {
        GetNextPuzzleButton = new TextButton
        {
            Text = "Get Next Puzzle",
            Id = "NextPuzzleButton",
            TextColor = Constants.ButtonTextColor,
            OverTextColor = Constants.ButtonHoverTextColor, 
            Left = rectCrossWord.Left,
            Top = rectCrossWord.Bottom + Constants.ClListSpacer * 8
        };

        GetNextPuzzleButton.Click += NextPuzzleButtonClick;
        _mainPanel.Widgets.Add(GetNextPuzzleButton);
    }
    #endregion
}