using Crossword.Shared.Constants;
using Microsoft.Xna.Framework;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region InitHintButton

    /// <summary>
    /// Draw hint button
    /// </summary>
    private void InitHintButton()
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
        
 
        //Old code - Text button
        //  HintButton = new TextButton
        //  {
        //      Text = "Get Hint Letters",
        //      Id = "HintButton",
        //      TextColor = CWSettings.ButtonTextColor,
        //      OverTextColor = CWSettings.ButtonHoverTextColor, 
        //      Left = rectCrossWord.Left,
        //      Top = rectCrossWord.Bottom + CWSettings.ClListSpacer * 2
        //  };
        //
        //  HintButton.Click += HintButtonClick;
        //_mainPanel.Widgets.Add(HintButton);
    }

    #endregion
}