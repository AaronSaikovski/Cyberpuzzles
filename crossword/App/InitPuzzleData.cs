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
        PuzzleData = CrosswordData.GetCrosswordData(); //FetchPuzzleData();

        // Parse the Data
        while (!_mrParser.ParseData(PuzzleData))
        {
        }

        //PuzzleType
        PuzzleType = _mrParser.PuzzleType;

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
        NumQuestions = _mrParser.NumQuestions;

        //Declare dimensions for arrays of crossword data
        _szClues = new string[NumQuestions];
        _szAnswers = new string[NumQuestions];
        _colRef = new int[NumQuestions];
        _rowRef = new int[NumQuestions];
        _bDataIsAcross = new bool[NumQuestions];
        _quesNum = new int[NumQuestions];

    }

    #endregion
}