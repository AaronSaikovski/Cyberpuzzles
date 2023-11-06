using System.Collections.Generic;

namespace CyberPuzzles.Crossword.Parser;

public sealed partial class CrosswordParser
{
    private void GetHintLetters(IReadOnlyList<string> strData)
    {
        SzGetLetters = strData[6];
    }
}