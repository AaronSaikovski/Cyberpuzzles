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
        HintButton = new TextButton();
        HintButton.Text = "Get Hint Letter";
        HintButton.Id = "HintButton";
        HintButton.TextColor = Color.White;
        HintButton.OverTextColor = Color.Yellow;
        //HintButton.ApplyWidgetStyle(new LabelStyle(new ButtonStyle(());
        HintButton.Left = RectCrossWord.Left;
        HintButton.Top = RectCrossWord.Bottom + CwSettings.ClListSpacer * 2;
        
        HintButton.Click += HintButtonClick;
        _mainPanel.Widgets.Add(HintButton);
    }
    #endregion

    #region InitGetNextPuzzleButton
    private void InitGetNextPuzzleButton()
    {
        GetNextPuzzleButton = new TextButton();
        GetNextPuzzleButton.Text = "Get Next Puzzle";
        GetNextPuzzleButton.Id = "NextPuzzleButton";
        GetNextPuzzleButton.TextColor = Color.White;
        GetNextPuzzleButton.OverTextColor = Color.Yellow;
        //HintButton.ApplyWidgetStyle(new LabelStyle(new ButtonStyle(());
        GetNextPuzzleButton.Left = RectCrossWord.Left;
        GetNextPuzzleButton.Top = RectCrossWord.Bottom + CwSettings.ClListSpacer * 8;
        
        GetNextPuzzleButton.Click += NextPuzzleButtonClick;
        _mainPanel.Widgets.Add(GetNextPuzzleButton);
    }
    
    #endregion
}