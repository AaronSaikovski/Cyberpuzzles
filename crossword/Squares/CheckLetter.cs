// using Microsoft.Xna.Framework;
//
// namespace CyberPuzzles.Crossword.Squares;
//
// public partial class Square
// {
//     #region CheckLetter
//
//     public void CheckLetter(char chCorrectLetter)
//     {
//         if (!IsPopulated()) return;
//         ClForeColour = ChLetter == chCorrectLetter ? Color.Green : Color.Red;
//         BIsDirty = true;
//     }
//     
//     #endregion
//
//     #region IsPopulated
//
//     //Returns bool true/false based on square's contents
//     private bool IsPopulated()
//     {
//         return ChLetter != ' ';
//     }
//     #endregion
//
// }