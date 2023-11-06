using Microsoft.Xna.Framework;

namespace CyberPuzzles.Crossword.Squares;

public partial class Square
{
    #region SetHighlighted

    public void SetHighlighted(int highlightType)
    {
        switch (highlightType)
        {
            case 1: //Current Letter
                if (!clBackColour.Equals(Color.Cyan))
                {
                    clBackColour = Color.Cyan;
                    bIsDirty = true;
                }

                break;
            case 2: //Current Word
                if (!clBackColour.Equals(Color.Yellow))
                {
                    clBackColour = Color.Yellow;
                    bIsDirty = true;
                }

                break;
            case 3: //Current None
                if (!clBackColour.Equals(Color.White))
                {
                    clBackColour = Color.White;
                    bIsDirty = true;
                }

                break;
            default: //Something went wrong....
                if (!clBackColour.Equals(Color.Red))
                {
                    //Console.WriteLine("Bogus color: " + nHighlightType);
                    clBackColour = Color.Red;
                    bIsDirty = true;
                }

                break;
        }
    }

    #endregion
}