
using System;
using System.Data;
using System.Threading.Tasks;
using Crossword.Entities;
using Crossword.Parsers;

using Crossword.FetchData;

namespace Crossword.App;

public sealed partial class CrosswordMain
{

    #region GetPuzzleDataASync
    /// <summary>
    /// Gets the CrosswordData from the API ASync
    /// </summary>
    /// <returns></returns>
    private string GetPuzzleData()
    {
        try
        {
            _logger.LogInformation("Start GetPuzzleData()");
            
            // Get the Puzzle Data..ASync and wait
            Task<string?> task = Task.Run(async () =>
            {
                try
                {
                    // Await the asynchronous method inside Task.Run
                    return await FetchCrosswordData.GetCrosswordDataAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex,ex.Message);
                    return null;
                }
            });
            
            // Wait for the task to complete
            task.Wait();
            
            //Check for the result
            if (task.IsCompleted && !task.IsFaulted && !task.IsCanceled)
            {
                return task.Result;
            }

            return null;


        }
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
            throw;
        }
       
    }
    #endregion
    
    #region InitPuzzleData

    /// <summary>
    /// Inits the puzzle data
    /// </summary>
    private async void InitPuzzleData()
    {
        try
        {
            _logger.LogInformation("Start InitPuzzleData()");
            
            //Parser class
            //Parser Implementation
            _mrParserData = new CrosswordData();

            // Get the Puzzle Data..old
            //CrosswordData = CrosswordData.GetCrosswordData();
           
            //////////////////////////////////////////
            // Get the Puzzle Data..ASync and wait
            PuzzleData = GetPuzzleData();

            //check if we have a non null valua
            if (string.IsNullOrEmpty(PuzzleData))
            {
                throw new DataException("Crossword puzzle data error!!.");
            }
            else
            {
                // Parse the Data
                _crosswordParser = new CrosswordParser();
                _mrParserData = _crosswordParser.ParsePuzzleData(PuzzleData);
            }
            
            
            
            // while (FetchData is not null && !_mrParserData.ParsePuzzleData(FetchData))
            // {
            // }

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
        catch (Exception ex)
        {
            _logger.LogError(ex,ex.Message);
            throw;
        }

    }

    #endregion
}