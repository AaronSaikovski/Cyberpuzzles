using System;

namespace Crossword.App;

public sealed partial class CrosswordApp
{

    private void HintButton_Click(object sender, EventArgs args)
    {
        GetHintLetters(0);
    }

    private void NextPuzzleButton_Click(object sender, EventArgs args)
    {
        GetNextPuzzle();
    }

}