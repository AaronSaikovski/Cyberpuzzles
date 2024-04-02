//
//
// using System.Collections.Generic;
// using Crossword.Shared.ParserUtils;
//
// namespace Crossword.Parsers;
//
// public sealed partial class CrosswordParser
// {
//     /// <summary>
//     /// GetGridPositions
//     /// </summary>
//     /// <param name="strData"></param>
//     private void GetGridPositions(IReadOnlyList<string> strData)
//     {
//         var puzzleTempStr = strData[3];
//         if (_crosswordData == null) return;
//         _crosswordData.NumQuestions = ParserHelper.CountOccurrences(puzzleTempStr, '#');
//         _crosswordData.ColRef = new int[_crosswordData.NumQuestions];
//         _crosswordData.RowRef = new int[_crosswordData.NumQuestions];
//         _crosswordData.IsAcross = new int[_crosswordData.NumQuestions];
//         _crosswordData.QuesNum = new int[_crosswordData.NumQuestions];
//
//         //split string 
//         var gridPosTmp = puzzleTempStr.Split('#');
//
//         for (var tokIdx = 0; tokIdx < _crosswordData.NumQuestions; tokIdx++)
//         {
//             var subGridDataTemp = gridPosTmp[tokIdx].Split(" ");
//
//             for (var i = 0; i < 4; i++)
//             {
//                 switch (i)
//                 {
//                     case 0:
//                         _crosswordData.ColRef[tokIdx] = int.Parse(subGridDataTemp[0]);
//                         break;
//
//                     case 1:
//                         _crosswordData.RowRef[tokIdx] = int.Parse(subGridDataTemp[1]);
//                         break;
//                     case 2:
//                         _crosswordData.IsAcross[tokIdx] = int.Parse(subGridDataTemp[2]);
//                         break;
//                     case 3:
//                         _crosswordData.QuesNum[tokIdx] = int.Parse(subGridDataTemp[3]);
//                         break;
//                 }
//             }
//         }
//     }
// }