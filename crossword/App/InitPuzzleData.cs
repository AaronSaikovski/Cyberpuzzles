
using CyberPuzzles.Crossword.App.PuzzleData;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region InitPuzzleData

    /// <summary>
    /// Inits the puzzle data
    /// </summary>
    private void InitPuzzleData()
    {
        //Parser class
        //Parser Implementation
        _mrParserData = new Parser.PuzzleData();

        // Get the Puzzle Data
        PuzzleData = CrosswordData.GetCrosswordData(); 

        // Parse the Data
        while (!_mrParserData.ParsePuzzleData(PuzzleData))
        {
        }

        //PuzzleType
        PuzzleType = _mrParserData.PuzzleType;

        //Number of Columns
        _NumCols = _mrParserData.NumCols;

        //Number of rows
        _NumRows = _mrParserData.NumRows;

        //Num Across
        _NumAcross = _mrParserData.NumAcross;

        //Num Down
        _NumDown = _mrParserData.NumDown;

        //Puzzle ID
        _PuzzleId = _mrParserData.PuzzleId;

        //Number of questions
        NumQuestions = _mrParserData.NumQuestions;

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