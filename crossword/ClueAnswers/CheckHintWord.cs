// namespace CyberPuzzles.Crossword.ClueAnswer;
//
// public sealed partial class ClueAnswers
// {
//     #region CheckHint
//
//     public bool CheckHint(char chHintLetter)
//     {
//         var bResult = false;
//         for (var i = 0; i < SzAnswer.Length; i++)
//             if (SzAnswer[i] == chHintLetter && SqAnswerSquares[i].ChLetter != chHintLetter)
//             {
//                 SqAnswerSquares[i].SetLetter(chHintLetter, BIsAcross);
//                 bResult = true;
//             }
//     
//         return bResult;
//     }
//
//     #endregion
//
//     #region CheckWord
//
//     public void CheckWord()
//     {
//         for (var i = 0; i < SzAnswer.Length; i++)
//             SqAnswerSquares[i].CheckLetter(SzAnswer[i]);
//     }
//
//     #endregion
// }