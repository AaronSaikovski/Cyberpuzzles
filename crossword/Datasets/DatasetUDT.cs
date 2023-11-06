
////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:     DatasetUDT.cs                                         //
//      Authors:    Aaron Saikovski & Bryan Richards                      //
//      Original:   24/03/97                                              //
//      Purpose:    Crossword dataset to map clues to answers.            //
//                                                                        //
////////////////////////////////////////////////////////////////////////////

namespace CyberPuzzles.Crossword.Datasets
{

    //Build Dataset
    public sealed class DatasetUdt
    {
        #region Getters

        // Getter for the 'nCoordAcross' property
        public int CoordAcross { get; }
        

        // Getter for the 'nCoordAcross' property
        public int CoordDown { get; }

        // Getter for the 'szAnswer' property
        public string Answer { get; }

        // Getter for the 'szClue' property
        public string Clue { get; }


        // Getter for the 'IsAcross' property
        public bool IsAcross { get; }


        // Getter for the 'nQuestionNum' property
        public int QuestionNum { get; }
        
        #endregion

        #region Constructor

        //Dataset Constructor
        public DatasetUdt(int coordAcross, int coordDown, string Answer, string Clue,
                            bool isAcross, int QuestionNum)
        {

            this.CoordAcross = coordAcross;
            this.CoordDown = coordDown;
            this.Answer = Answer;
            this.Clue = Clue;
            this.IsAcross = isAcross;
            this.QuestionNum = QuestionNum;

        }

        #endregion

    }
}