namespace CyberPuzzles.Crossword.Squares;

public partial class Square
{
    #region GetNextPrevSq

    public Square GetNextSq(bool bIsAcross)
    {
        return !bIsAcross ? clDown != null ? clDown.GetNextSq(this) : this :
            clAcross != null ? clAcross.GetNextSq(this) : this;
    }

    public Square GetPrevSq(bool bIsAcross)
    {
        if (bIsAcross)
            return clAcross != null ? clAcross.GetPrevSq(this) : this;
        return clDown != null ? clDown.GetPrevSq(this) : this;
    }

    #endregion
}