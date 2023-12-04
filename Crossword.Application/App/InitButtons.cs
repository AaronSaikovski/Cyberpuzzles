using Crossword.Shared.Constants;
using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    
    // _imgHintButton = Content.Load<Texture2D>(CWSettings.HintButtonImage);
    // _imgNextButton 
        
        
    #region InitHintButton
    /// <summary>
    /// Init hint button
    /// </summary>
    private void InitHintButton()
    {
        //Rectangle(sqPuzzleSquares[i, j]!.xCoord, sqPuzzleSquares[i, j]!.yCoord,
        // CWSettings.SquareWidth, CWSettings.SquareHeight);

        // // Begin drawing
        // _spriteBatch.Begin();
        // var hintRect = new Rectangle(rectCrossWord.Left, rectCrossWord.Bottom + CWSettings.ClListSpacer * 2, 100, 27);
        // //var HintButton = new LinkButton(this, CWSettings.HintButtonImage, hintRect,0);
        //
        // _spriteBatch.Draw(_imgHintButton, hintRect, _rectangleColor);
        // // Begin drawing
        // _spriteBatch.End();
        
        //HintButton.Draw(;
        
         HintButton = new TextButton
         {
             Text = "Get Hint Letters",
             Id = "HintButton",
             TextColor = CWSettings.ButtonTextColor,
             OverTextColor = CWSettings.ButtonHoverTextColor, 
             Left = rectCrossWord.Left,
             Top = rectCrossWord.Bottom + CWSettings.ClListSpacer * 2
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
            TextColor = CWSettings.ButtonTextColor,
            OverTextColor = CWSettings.ButtonHoverTextColor, 
            Left = rectCrossWord.Left,
            Top = rectCrossWord.Bottom + CWSettings.ClListSpacer * 8
        };

        GetNextPuzzleButton.Click += NextPuzzleButtonClick;
        _mainPanel.Widgets.Add(GetNextPuzzleButton);
    }
    #endregion
}