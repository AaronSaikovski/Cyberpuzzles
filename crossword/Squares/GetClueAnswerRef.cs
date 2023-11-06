using CyberPuzzles.Crossword.ClueAnswer;

namespace CyberPuzzles.Crossword.Squares;

public partial class Square
{
    #region GetClueAnswerRef

    public ClueAnswers GetClueAnswerRef(bool bIsAcross)
    {
        return bIsAcross ? clAcross : clDown;
    }

    #endregion
}