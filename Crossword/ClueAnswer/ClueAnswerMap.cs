////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:             ClueAnswerMap.cs                                 //
//      Authors:            Aaron Saikovski & Bryan Richards              //
//      Original Date:      26/02/97                                      //
//      Version:            1.0                                           //
//      Purpose:            Clue + Answer references class                //
//                                                                        //
////////////////////////////////////////////////////////////////////////////

using Crossword.PuzzleSquares;

namespace Crossword.ClueAnswer;

/// <summary>
/// ClueAnswer Class
/// </summary>
public sealed partial class ClueAnswerMap
{
    #region getters_setters
    public string? Answer { get; set; }
    public string? Clue { get; set; }

    public int QuestionNumber { get; set; }

    public bool IsAcross { get; set; } = true;

    public Square?[]? SqAnswerSquares { get; set; }

    #endregion
}