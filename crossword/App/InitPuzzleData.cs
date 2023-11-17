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
        while (!_mrParser.ParseData(SzPuzData))
        {
        }

        //PuzzleType
        SzPuzzleType = _mrParser.PuzzleType;

        //Number of Columns
        _NumCols = _mrParser.NumCols;

        //Number of rows
        _NumRows = _mrParser.NumRows;

        //Num Across
        _NumAcross = _mrParser.NumAcross;

        //Num Down
        _NumDown = _mrParser.NumDown;

        //Puzzle ID
        _PuzzleId = _mrParser.PuzzleId;

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