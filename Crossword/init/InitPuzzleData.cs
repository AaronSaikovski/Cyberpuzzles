
using System;
using System.Data;
using System.Threading.Tasks;
using Crossword.Entities;
using Crossword.Parser;

using Crossword.Data;

namespace Crossword.App;

public sealed partial class CrosswordApp
{

    #region GetPuzzleDataASync
    /// <summary>
    /// Gets the CrosswordData from the API ASync
    /// </summary>
    /// <returns></returns>
    // private string? GetPuzzleData()
    // {
    //     try
    //     {
    //         _logger.LogInformation("Start GetPuzzleData()");
    //
    //         // Get the Puzzle Data..ASync and wait
    //         var task = Task.Run(async () =>
    //         {
    //             try
    //             {
    //                 // Await the asynchronous method inside Task.Run
    //                 return await GetPuzzleDataAsync.GetCrosswordDataAsync();
    //             }
    //             catch (Exception ex)
    //             {
    //                 _logger.LogError(ex, ex.Message);
    //                 return null;
    //             }
    //         });
    //
    //         // Wait for the task to complete
    //         task.Wait();
    //
    //         //Check for the result
    //         return task is { IsCompleted: true, IsFaulted: false, IsCanceled: false } ? task.Result : null;
    //
    //
    //
    //     }
    //     catch (Exception ex)
    //     {
    //         _logger.LogError(ex, ex.Message);
    //         throw;
    //     }
    //
    // }
    
    private async Task<string> GetPuzzleDataASync()
    {
        try
        {
            _logger.LogInformation("Start GetPuzzleData()");

            // Await the asynchronous method inside Task.Run
            return await GetPuzzleDataAsync.GetCrosswordDataAsync();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }

    }
    #endregion

    #region InitPuzzleData

    /// <summary>
    /// Inits the puzzle data
    /// </summary>
    private async Task InitPuzzleDataAsync()
    {
        try
        {
            _logger.LogInformation("Start InitPuzzleData()");

            //Parser class
            _mrParserData = new CrosswordData();

            //////////////////////////////////////////
            // Get the Puzzle Data..ASync and wait
            _puzzleData = await GetPuzzleDataASync();

            //check if we have a non null valua
            if (string.IsNullOrEmpty(_puzzleData))
            {
                throw new DataException("Crossword puzzle data error!!.");
            }

            // Parse the Data
            _crosswordParser = new CrosswordParser();
            _mrParserData = await _crosswordParser.ParsePuzzleDataASync(_puzzleData);


            //check if the parser object is null
            if (_mrParserData == null)
            {
                throw new ApplicationException("Parser object is null");
            }


            //PuzzleType
            _puzzleType = _mrParserData.PuzzleType;

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
            _numQuestions = _mrParserData.NumQuestions;

            //Declare dimensions for arrays of crossword data
            _szClues = new string[_numQuestions];
            _szAnswers = new string[_numQuestions];
            _colRef = new int[_numQuestions];
            _rowRef = new int[_numQuestions];
            _bDataIsAcross = new bool[_numQuestions];
            _quesNum = new int[_numQuestions];

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }

    }

    #endregion
}