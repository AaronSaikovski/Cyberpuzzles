using CyberPuzzles.Crossword.ClueAnswer;
using Microsoft.Xna.Framework;

namespace CyberPuzzles.Crossword.Squares;

public partial class Square
{
    #region SetObjectRef

    public void SetObjectRef(bool bIsAcross, ClueAnswers cl)
    {
        if (bIsAcross)
            clAcross = cl;
        else
            clDown = cl;

        bIsCharAllowed = true;
        bIsDirty = true;
        clBackColour = Color.White;
    }

    #endregion
}