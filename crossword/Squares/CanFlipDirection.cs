namespace CyberPuzzles.Crossword.Squares;

public partial class Square
{
    #region CanFlipDirection

    public bool CanFlipDirection(bool bIsAcross)
    {
        return (bIsAcross && clDown != null) || (!bIsAcross && clAcross != null);
    }

    #endregion
}