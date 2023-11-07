using CyberPuzzles.Crossword.Parser;
using CyberPuzzles.Crossword.PuzzleData;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region InitPuzzleData

    private void InitPuzzleData()
    {
        //Parser class
        //Parser Implementation
        _mrParser = new CrosswordParser();

        // Get the Puzzle Data
        SzPuzData = CrosswordData.GetCrosswordData(); //FetchPuzzleData();

        // Parse the Data
        while (SzPuzData != null && !_mrParser.ParseData(SzPuzData))
        {
        }

        //PuzzleType
        SzPuzzleType = _mrParser.PuzzleType;

        //Number of Columns
        NNumCols = _mrParser.NumCols;

        //Number of rows
        NNumRows = _mrParser.NumRows;

        //Num Across
        NNumAcross = _mrParser.NumAcross;

        //Num Down
        NNumDown = _mrParser.NumDown;

        //Puzzle ID
        PuzzleId = _mrParser.PuzzleId;

        //Number of questions
        NNumQuestions = _mrParser.NumQuestions;

        //Declare dimensions for arrays of crossword data
        _szClues = new string[NNumQuestions];
        _szAnswers = new string[NNumQuestions];
        _colRef = new int[NNumQuestions];
        _rowRef = new int[NNumQuestions];
        _bDataIsAcross = new bool[NNumQuestions];
        _quesNum = new int[NNumQuestions];
    }

    #endregion
}