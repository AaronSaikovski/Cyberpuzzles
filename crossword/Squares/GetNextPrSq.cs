namespace CyberPuzzles.Crossword.Squares;

public partial class Square
{
    #region GetNextPrevSq

    public Square GetNextSq(bool bIsAcross)
    {
        return !bIsAcross ? ClDown != null ? ClDown.GetNextSq(this) : this :
            ClAcross != null ? ClAcross.GetNextSq(this) : this;
    }

    public Square GetPrevSq(bool bIsAcross)
    {
        if (bIsAcross)
            return ClAcross != null ? ClAcross.GetPrevSq(this) : this;
        return ClDown != null ? ClDown.GetPrevSq(this) : this;
    }

    #endregion
}