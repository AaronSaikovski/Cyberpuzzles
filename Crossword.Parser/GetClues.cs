namespace CrosswordParser;

public sealed partial class PuzzleData
{
    /// <summary>
    /// GetClues
    /// </summary>
    /// <param name="strData"></param>
    private void GetClues(IReadOnlyList<string> strData)
    {
        string puzzletempstr;
        string[] cluetemp;
        puzzletempstr = strData[4];
        cluetemp = puzzletempstr.Split("#");
        Clues = new string[NumQuestions];
        for (var j = 0; j < NumQuestions; j++)
        {
            Clues[j] = cluetemp[j];
        }
    }
}