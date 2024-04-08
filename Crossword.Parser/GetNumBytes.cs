

namespace Crossword.Parser;

public sealed partial class CrosswordParser
{
    /// <summary>
    /// GetNumBytes
    /// </summary>
    /// <param name="strData"></param>
    private void GetNumBytes(IReadOnlyList<string> strData)
    {
        if (_crosswordData != null) _crosswordData.NumBytes = int.Parse(strData[0]);
    }
}