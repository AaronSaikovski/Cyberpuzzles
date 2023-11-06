using Microsoft.Xna.Framework;

namespace CyberPuzzles.Crossword.Squares;

public partial class Square
{
    #region SetLetter

    public void SetLetter(char ch, bool bIsAcross)
    {
        ChLetter = ch;
        bIsDirty = true;

        if (bIsAcross)
        {
            // set square to green for correct color
            clForeColour = clAcross.GetChar(this).Equals(char.ToUpper(ChLetter))
                ? Color.LightGreen
                : //todo - set as an enum
                //clForeColour = Color.black;
                // set square to red for error
                Color.Red; //todo - set as an enum
            //clForeColour = Color.Black
        }
        else
        {
            // set square to green for correct color
            clForeColour = clDown.GetChar(this).Equals(char.ToUpper(ChLetter))
                ? Color.LightGreen
                : //todo - set as an enum
                //clForeColour = Color.black;
                // set square to red for error
                Color.Red; //todo - set as an enum
            //clForeColour = Color.Black
        }
    }

    #endregion
}