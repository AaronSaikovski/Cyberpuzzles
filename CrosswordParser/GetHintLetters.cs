using System.Collections.Generic;

namespace CyberPuzzles.Crossword.Parser;

public sealed partial class CrosswordParser
{
    private void GetHintLetters(IReadOnlyList<string> strData)
    {
        GetLetters = strData[6];
    }
}