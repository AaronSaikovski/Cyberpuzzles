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
        _NumQuestions = _mrParser.NumQuestions;

        //Declare dimensions for arrays of crossword data
        _szClues = new string[_NumQuestions];
        _szAnswers = new string[_NumQuestions];
        _colRef = new int[_NumQuestions];
        _rowRef = new int[_NumQuestions];
        _bDataIsAcross = new bool[_NumQuestions];
        _quesNum = new int[_NumQuestions];
    }

    #endregion
}