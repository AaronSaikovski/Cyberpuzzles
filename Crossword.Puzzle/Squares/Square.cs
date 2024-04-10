
using Microsoft.Xna.Framework;

using Crossword.Shared.enums;
using Crossword.Puzzle.ClueAnswerMap;


namespace Crossword.Puzzle.Squares;

//Square class
public sealed partial class Square
{
    #region getters_setters

    public int XCoord { get; set; }
    public int YCoord { get; set; }


    public char Letter { get; set; }


    public Color ForeColour { get; set; } = Color.Black;
    public Color BackColour { get; set; } = Color.Black;

    public bool IsDirty { get; set; } = true;

    public bool IsCharAllowed { get; set; }

    public ClueAnswer? ClueAnswerAcross { get; set; }
    public ClueAnswer? ClueAnswerDown { get; set; }

    public HighlightSquare HighlightSquareSelColour { get; set; }

    #endregion

}