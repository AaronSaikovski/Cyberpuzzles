// using Microsoft.Xna.Framework;
//
// namespace CyberPuzzles.Crossword.Squares;
//
// public partial class Square
// {
//     #region SetHighlighted
//
//     public void SetHighlighted(int highlightType)
//     {
//         switch (highlightType)
//         {
//             case 1: //Current Letter
//                 if (!ClBackColour.Equals(Color.Cyan))
//                 {
//                     ClBackColour = Color.Cyan;
//                     BIsDirty = true;
//                 }
//
//                 break;
//             case 2: //Current Word
//                 if (!ClBackColour.Equals(Color.Yellow))
//                 {
//                     ClBackColour = Color.Yellow;
//                     BIsDirty = true;
//                 }
//
//                 break;
//             case 3: //Current None
//                 if (!ClBackColour.Equals(Color.White))
//                 {
//                     ClBackColour = Color.White;
//                     BIsDirty = true;
//                 }
//
//                 break;
//             default: //Something went wrong....
//                 if (!ClBackColour.Equals(Color.Red))
//                 {
//                     //Console.WriteLine("Bogus color: " + nHighlightType);
//                     ClBackColour = Color.Red;
//                     BIsDirty = true;
//                 }
//
//                 break;
//         }
//     }
//
//     #endregion
// }