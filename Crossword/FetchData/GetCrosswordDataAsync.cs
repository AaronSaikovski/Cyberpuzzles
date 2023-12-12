using System;
using System.Threading.Tasks;
using Crossword.Constants;
using Crossword.Shared.Logger;

namespace Crossword.FetchData;

public partial class FetchCrosswordData
{
    #region GetCrosswordDataAsync

    /// <summary>
    /// GetCrosswordDataAsync
    /// </summary>
    /// <returns></returns>
    public static async Task<string?> GetCrosswordDataAsync()
    {
        //Init the logger
        var _logger = new SerilogLogger();

        //Call the API to get the puzzledata....otherwise use default values
        try
        {
            _logger.LogInformation("Start GetCrosswordDataAsync()");

            //call the API
            string? apiResponse = await CallDataApiAsync();

            //check what was returned
            if (string.IsNullOrEmpty(apiResponse))
            {
                return GameConstants.DefaultPuzzleData;
            }
            else
            {
                return apiResponse;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }

    #endregion
}