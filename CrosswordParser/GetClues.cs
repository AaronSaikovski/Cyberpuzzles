using System.Collections.Generic;

namespace CyberPuzzles.Crossword.Parser;

public sealed partial class CrosswordParser
{
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