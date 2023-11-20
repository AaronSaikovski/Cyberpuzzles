using System.Collections.Generic;

namespace CyberPuzzles.Crossword.Parser;

public sealed partial class CrosswordParser
{
    private void GetNumBytes(IReadOnlyList<string> strData)
    {
        NumBytes = int.Parse(strData[0]);
    }
}