using System.Collections.Generic;

namespace CyberPuzzles.Crossword.Parser;

public sealed partial class CrosswordParser
{
    private void GetAnswers(IReadOnlyList<string> strData)
    {
        string puzzletempstr;
        string[] answertemp;
        puzzletempstr = strData[5];
        answertemp = puzzletempstr.Split("#");
        SzAnswers = new string[NumQuestions];
        for (var k = 0; k < NumQuestions; k++)
        {
            SzAnswers[k] = answertemp[k];
        }
    }
}