using CyberPuzzles.Crossword.ClueAnswer;
using Microsoft.Xna.Framework;

////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:     Square.java                                           //
//      Authors:    Aaron Saikovski & Bryan Richards                      //
//      Date:       23/01/97                                              //
//      Version:    1.0                                                   //
//      Purpose:    Defines a Square and it's attributes                  //
//                                                                        //
////////////////////////////////////////////////////////////////////////////

namespace CyberPuzzles.Crossword.Squares
{
    // Defines a Square and it's attributes  
    public partial class Square
    {
        //TODO - set these as properties with getters and setters
        #region Fields

        public char ChLetter { get; set; }

        //public char chNumber = ' ';
        public Color ClForeColour = Color.Black;
        public Color ClBackColour = Color.Black;
        public bool BIsDirty = true, BIsCharAllowed;
        public ClueAnswers ClAcross ,ClDown;
        #endregion

        /*---------------------------------------------------------------*/

        #region GettersSetters

        public int XCoord { get; set; }

        public int YCoord { get; set; }

        #endregion
        
        /*---------------------------------------------------------------*/

        #region CreateSquare

        //Allocates graphics memory for blank square
        public void CreateSquare(int xCoord, int yCoord)
        {
            XCoord = xCoord;
            YCoord = yCoord;
        }
        #endregion
    }
}

