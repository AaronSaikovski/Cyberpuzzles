namespace CrosswordParser;

public sealed partial class PuzzleData
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
            if (Costs is not null) Costs[loopIdx] = int.Parse(costTemp[loopIdx]);
        }
    }
}