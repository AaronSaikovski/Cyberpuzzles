
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
    /// Gets the CrosswordData from the API Synchronously (blocks until complete)
    /// Note: Uses GetAwaiter().GetResult() which is more efficient than Task.Wait() + .Result
    /// </summary>
    /// <returns></returns>
    private string? GetPuzzleData()
    {
        try
        {
            _logger.LogInformation("Start GetPuzzleData()");

            // Use GetAwaiter().GetResult() instead of Task.Wait() + .Result
            // This is more efficient and doesn't wrap exceptions in AggregateException
            return GetPuzzleDataAsync.GetCrosswordDataAsync().GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return null;
        }
    }
    #endregion

    #region InitPuzzleData

    /// <summary>
    /// Inits the puzzle data
    /// </summary>
    private void InitPuzzleData()
    {
        try
        {
            _logger.LogInformation("Start InitPuzzleData()");

            //Parser class
            _mrParserData = new CrosswordData();

            //////////////////////////////////////////
            // Get the Puzzle Data..ASync and wait
            _puzzleData = GetPuzzleData();

            //check if we have a non null valua
            if (string.IsNullOrEmpty(_puzzleData))
            {
                throw new DataException("Crossword puzzle data error!!.");
            }

            // Parse the Data
            _crosswordParser = new CrosswordParser();
            _mrParserData = _crosswordParser.ParsePuzzleData(_puzzleData);


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