using CyberPuzzles.Crossword.Parser;
using CyberPuzzles.Crossword.PuzzleData;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region Initialisers

    private void InitPuzzleData()
    {
        //Parser class
        //Parser Implementation
        _mrParser = new CrosswordParser();

        // Get the Puzzle Data
        szPuzData = CrosswordData.GetCrosswordData(); //FetchPuzzleData();

        // Parse the Data
        while (szPuzData != null && !_mrParser.ParseData(szPuzData))
        {
        }

        //PuzzleType
        szPuzzleType = _mrParser.PuzzleType;

        //Number of Columns
        nNumCols = _mrParser.NumCols;

        //Number of rows
        nNumRows = _mrParser.NumRows;

        //Num Across
        nNumAcross = _mrParser.NumAcross;

        //Num Down
        nNumDown = _mrParser.NumDown;

        //Puzzle ID
        puzzleId = _mrParser.PuzzleId;

        //Number of questions
        nNumQuestions = _mrParser.NumQuestions;

        //Declare dimensions for arrays of crossword data
        _szClues = new string[nNumQuestions];
        _szAnswers = new string[nNumQuestions];
        _colRef = new int[nNumQuestions];
        _rowRef = new int[nNumQuestions];
        _bDataIsAcross = new bool[nNumQuestions];
        _quesNum = new int[nNumQuestions];
    }

    #endregion
}