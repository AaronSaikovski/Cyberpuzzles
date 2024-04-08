using System;

namespace Crossword.App;

public sealed partial class CrosswordApp
{

    #region Button_Handlers
    /// <summary>
    /// Handle Hintbutton click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void HintButton_Click(object sender, EventArgs args)
    {
        GetHintLetters(0);
    }

    /// <summary>
    /// Handle Next Button Click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void NextPuzzleButton_Click(object sender, EventArgs args)
    {
        InitNextPuzzle();
    }
    #endregion

}