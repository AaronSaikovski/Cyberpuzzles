
using System;
using System.Data;
using System.Threading.Tasks;
using Crossword.Entities;
using Crossword.Parser;

using Crossword.Data;

namespace Crossword.App;

public sealed partial class CrosswordMain
{

    #region GetPuzzleDataASync
    /// <summary>
    /// Gets the CrosswordData from the API ASync
    /// </summary>
    /// <returns></returns>
    private string? GetPuzzleData()
    {
        try
        {
            logger.LogInformation("Start GetPuzzleData()");
            
            // Get the Puzzle Data..ASync and wait
            var task = Task.Run(async () =>
            {
                try
                {
                    // Await the asynchronous method inside Task.Run
                    return await FetchCrosswordData.GetCrosswordDataAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex,ex.Message);
                    return null;
                }
            });
            
            // Wait for the task to complete
            task.Wait();

            //Check for the result
            return task is { IsCompleted: true, IsFaulted: false, IsCanceled: false } ? task.Result : null;
            
           
            
        }
        catch (Exception ex)
        {
            logger.LogError(ex,ex.Message);
            throw;
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
            logger.LogInformation("Start InitPuzzleData()");
            
            //Parser class
            _mrParserData = new CrosswordData();
           
            //////////////////////////////////////////
            // Get the Puzzle Data..ASync and wait
            PuzzleData = GetPuzzleData();

            //check if we have a non null valua
            if (string.IsNullOrEmpty(PuzzleData))
            {
                throw new DataException("Crossword puzzle data error!!.");
            }

            // Parse the Data
            _crosswordParser = new CrosswordParser();
            _mrParserData = _crosswordParser.ParsePuzzleData(PuzzleData);


            //check if the parser object is null
            if (_mrParserData == null)
            {
                throw new ApplicationException("Parser object is null");
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
        catch (Exception ex)
        {
            logger.LogError(ex,ex.Message);
            throw;
        }

    }

    #endregion
}