namespace CyberPuzzles.Crossword.App;

/*---------------------------------------------------------------*/

//Build Dataset
public class nDatasetUDT {

    public int nCoordAcross = 0;
    public int nCoordDown = 0;

    //Answer
    public string szAnswer = null;

    //Clue
    public string szClue = null;


    //Is Across or down??
    public  bool IsAcross = false;

    //Question number
    public int nQuestionNum = 0;

    //default constructor
    public nDatasetUDT(){
    }

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