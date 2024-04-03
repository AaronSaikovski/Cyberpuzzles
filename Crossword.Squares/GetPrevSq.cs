// namespace Crossword.Squares;
//
// public sealed partial class Square
// {
//     #region GetPrevSq
//
//     /// <summary>
//     /// /Gets the previous available square
//     /// </summary>
//     /// <param name="isAcross"></param>
//     /// <returns></returns>
//     public Square? GetPrevSq(bool isAcross)
//     {
//         if (isAcross)
//             return ClueAnswerAcross is not null ? ClueAnswerAcross.GetPrevSq(this) : this;
//         return ClueAnswerDown is not null ? ClueAnswerDown.GetPrevSq(this) : this;
//     }
//
//     #endregion
// }