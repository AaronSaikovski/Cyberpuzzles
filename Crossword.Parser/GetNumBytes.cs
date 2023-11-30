namespace CrosswordParser;

public sealed partial class PuzzleData
{
    /// <summary>
    /// GetNumBytes
    /// </summary>
    /// <param name="strData"></param>
    private void GetNumBytes(IReadOnlyList<string> strData)
    {
        NumBytes = int.Parse(strData[0]);
    }
}