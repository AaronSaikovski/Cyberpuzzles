
using System;
using System.Threading.Tasks;
using Crossword.PuzzleData;

namespace Crossword.App;

public sealed partial class CrosswordMain
{
    #region InitPuzzleData

    /// <summary>
    /// Inits the puzzle data
    /// </summary>
    private async void InitPuzzleData()
    {
        try
        {
            //Parser class
            //Parser Implementation
            _mrParserData = new CrosswordParser.PuzzleData();

            // Get the Puzzle Data..old
            //PuzzleData = CrosswordData.GetCrosswordData();
           
            //////////////////////////////////////////
            // Get the Puzzle Data..ASync and wait
            Task<string> task = Task.Run(async () => await CrosswordData.GetCrosswordDataAsync());

            // Wait for the task to complete
            task.Wait();

            // Get the result 
            PuzzleData = task.Result;
            //////////////////////////////////////////
            
            // Parse the Data
            while (PuzzleData is not null && !_mrParserData.ParsePuzzleData(PuzzleData))
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
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }

    #endregion
}