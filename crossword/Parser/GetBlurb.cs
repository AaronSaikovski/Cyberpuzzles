using System.Collections.Generic;

namespace CyberPuzzles.Crossword.Parser;

public sealed partial class CrosswordParser
{
    private void GetBlurb(IReadOnlyList<string> strData)
    {
        SzBlurb = strData[8];
    }
}