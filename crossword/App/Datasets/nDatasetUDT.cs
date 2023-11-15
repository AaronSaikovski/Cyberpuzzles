////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:     DatasetUDT.cs                                         //
//      Authors:    Aaron Saikovski & Bryan Richards                      //
//      Original:   24/03/97                                              //
//      Purpose:    Crossword dataset to map clues to answers.            //
//                                                                        //
////////////////////////////////////////////////////////////////////////////

namespace CyberPuzzles.Crossword.App.Datasets;

/*---------------------------------------------------------------*/

//Build Dataset
public sealed class nDatasetUDT {

    private int _nCoordAcross;
    private int _nCoordDown;

    //Answer
    private string _szAnswer;

    //Clue
    private string _szClue;

    //Is Across or down??
    private bool _IsAcross;

    //Question number
    private int _nQuestionNum;

    
 
    public int nCoordAcross
    {
        get { return _nCoordAcross; }
        set { _nCoordAcross = value; }
    }
    
    public int nCoordDown
    {
        get { return _nCoordDown; }
        set { _nCoordDown = value; }
    }
    
    public string szAnswer
    {
        get { return _szAnswer; }
        set { _szAnswer = value; }
    }
    
    public string szClue
    {
        get { return _szClue; }
        set { _szClue = value; }
    }
    
    public bool IsAcross
    {
        get { return _IsAcross; }
        set { _IsAcross = value; }
    }
    
    
    public int nQuestionNum
    {
        get { return _nQuestionNum; }
        set { _nQuestionNum = value; }
    }
    
    //default constructor
    // public nDatasetUDT(){
    // }

    //Dataset Constructor
    public nDatasetUDT(int nCoordAcross,int nCoordDown,string szAnswer,string szClue,
        bool IsAcross,int nQuestionNum){

        this.nCoordAcross = nCoordAcross;
        this.nCoordDown = nCoordDown;
        this.szAnswer = szAnswer;
        this.szClue = szClue;
        this.IsAcross = IsAcross;
        this.nQuestionNum = nQuestionNum;

    }

}