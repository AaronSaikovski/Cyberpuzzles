using System;
using Crossword.Puzzle.ClueAnswerMap;
using Crossword.Shared.Constants;

namespace Crossword.Puzzle.Squares;

public sealed partial class Square
{
    #region SetObjectRef

    /// <summary>
    /// Set the object reference to clueanswer object
    /// </summary>
    /// <param name="isAcross"></param>
    /// <param name="clueAnswer"></param>
    public void SetObjectRef(bool isAcross, ClueAnswer clueAnswer)
    {
        ArgumentNullException.ThrowIfNull(clueAnswer);
        
        if (isAcross)
            ClueAnswerAcross = clueAnswer;
        else
            ClueAnswerDown = clueAnswer;

        IsCharAllowed = true;
        IsDirty = true;
        BackColour = UIConstants.SquareHighlightNone;
    }

    #endregion
}