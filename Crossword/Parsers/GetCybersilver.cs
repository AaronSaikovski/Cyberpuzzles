using System.Collections.Generic;

namespace Crossword.Parsers;

public sealed partial class CrosswordParser
{
    /// <summary>
    /// GetCybersilver
    /// </summary>
    /// <param name="strData"></param>
    private void GetCybersilver(IReadOnlyList<string> strData)
    {
        var puzzletempstr = strData[7];
        var costTemp = puzzletempstr.Split(" ");

        for (var loopIdx = 0; loopIdx < 6; loopIdx++)
        {
            if (_crosswordData.Costs is not null) _crosswordData.Costs[loopIdx] = int.Parse(costTemp[loopIdx]);
        }
    }
}