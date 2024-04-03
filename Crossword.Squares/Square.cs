
using Microsoft.Xna.Framework;

namespace Crossword.Squares;
//
// //Square class
// public sealed partial class Square
// {
//     #region getters_setters
//
//     public int xCoord { get; set; }
//     public int yCoord { get; set; }
//
//
//     public char Letter { get; set; }
//
//
//     public Color ForeColour { get; set; } = Color.Black;
//     public Color BackColour { get; set; } = Color.Black;
//
//     public bool IsDirty { get; set; } = true;
//
//     public bool IsCharAllowed { get; set; }
//
//     // public ClueAnswer? ClueAnswerAcross { get; set; }
//     // public ClueAnswer? ClueAnswerDown { get; set; }
//
//     #endregion
//
//   
// }

/// <summary>
/// Primary constructor for the Square
/// </summary>
/// <param name="xCoord"></param>
/// <param name="yCoord"></param>
/// <param name="Letter"></param>
/// <param name="ForeColour"></param>
/// <param name="BackColour"></param>
/// <param name="IsDirty"></param>
/// <param name="IsCharAllowed"></param>
// public class Square(int xCoord, int yCoord, char? Letter, Color? ForeColour, Color? BackColour,  bool IsDirty, bool IsCharAllowed)
// {
// //     public Square(int xCoord, int yCoord, char? Letter, Color? ForeColour, Color? BackColour,  bool IsDirty, bool IsCharAllowed)
// //     {
// //         //this.xCoord = xCoord;
// // //         this.yCoord = yCoord;
// //     }
//     
// }

/// <summary>
/// Square class
/// </summary>
public sealed partial class Square
{
    public int xCoord { get; set; }
    public int yCoord { get; set; }


    public char Letter { get; set; }


    public Color ForeColour { get; set; } = Color.Black;
    public Color BackColour { get; set; } = Color.Black;

    public bool IsDirty { get; set; } = true;

    public bool IsCharAllowed { get; set; }
    
    /// <summary>
    /// Class constructor
    /// </summary>
    /// <param name="xCoord"></param>
    /// <param name="yCoord"></param>
    /// <param name="letter"></param>
    /// <param name="isDirty"></param>
    /// <param name="isCharAllowed"></param>
    public Square(int xCoord, int yCoord, char letter, bool isDirty, bool isCharAllowed)
    {
        this.xCoord = xCoord;
        this.yCoord = yCoord;
        this.Letter = letter;
        this.IsDirty = isDirty;
        this.IsCharAllowed = isCharAllowed;
    }

}




