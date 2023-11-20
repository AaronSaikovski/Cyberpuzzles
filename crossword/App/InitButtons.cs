using System;
using CyberPuzzles.Crossword.Constants;
using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    
    #region InitHintButton
    
    private void InitHintButton()
    {
        HintButton = new TextButton
        {
            Text = "Get Hint Letters",
            Id = "HintButton",
            TextColor = Color.White,
            OverTextColor = Color.Yellow,
            //HintButton.ApplyWidgetStyle(new LabelStyle(new ButtonStyle(());
            Left = rectCrossWord.Left,
            Top = rectCrossWord.Bottom + CwSettings.ClListSpacer * 2
        };

        HintButton.Click += HintButtonClick;
        _mainPanel.Widgets.Add(HintButton);
    }
    #endregion

    #region InitGetNextPuzzleButton
    private void InitGetNextPuzzleButton()
    {
        GetNextPuzzleButton = new TextButton
        {
            Text = "Get Next Puzzle",
            Id = "NextPuzzleButton",
            TextColor = Color.White,
            OverTextColor = Color.Yellow,
            Left = rectCrossWord.Left,
            Top = rectCrossWord.Bottom + CwSettings.ClListSpacer * 8
        };

        GetNextPuzzleButton.Click += NextPuzzleButtonClick;
        _mainPanel.Widgets.Add(GetNextPuzzleButton);
    }
    
    #endregion
}