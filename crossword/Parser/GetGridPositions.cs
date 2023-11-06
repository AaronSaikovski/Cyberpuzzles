using System.Collections.Generic;
using CyberPuzzles.Crossword.Parsers;

namespace CyberPuzzles.Crossword.Parser;

public sealed partial class CrosswordParser
{
    private void GetGridPositions(IReadOnlyList<string> strData)
    {
        var PuzzleTempStr = strData[3];
        NumQuestions = Helpers.CountOccurrences(PuzzleTempStr, '#');
        ColRef = new int[NumQuestions];
        RowRef = new int[NumQuestions];
        IsAcross = new int[NumQuestions];
        QuesNum = new int[NumQuestions];
        
        //split string 
        var gridPosTmp = PuzzleTempStr.Split('#');

        for (var tokIdx = 0; tokIdx < NumQuestions; tokIdx++)
        {
            var subGridDataTemp = gridPosTmp[tokIdx].Split(" ");

            for (var i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        ColRef[tokIdx] = int.Parse(subGridDataTemp[0]);
                        break;

                    case 1:
                        RowRef[tokIdx] = int.Parse(subGridDataTemp[1]);
                        break;
                    case 2:
                        IsAcross[tokIdx] = int.Parse(subGridDataTemp[2]);
                        break;
                    case 3:
                        QuesNum[tokIdx] = int.Parse(subGridDataTemp[3]);
                        break;
                }
            }
        }
    }
}