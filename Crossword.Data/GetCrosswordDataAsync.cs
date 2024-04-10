using Crossword.Shared.Config;
using Crossword.Shared.Constants;
using Crossword.Shared.Logger;

namespace Crossword.Data;

public static partial class GetPuzzleDataAsync
{
    #region GetCrosswordDataAsync

    /// <summary>
    /// GetCrosswordDataAsync
    /// </summary>
    /// <returns></returns>
    public static async Task<string?> GetCrosswordDataAsync()
    {
        //Init the logger and get the active config
        using var logger = new SerilogLogger(ConfigurationHelper.ActiveConfiguration);

        //Call the API to get the puzzledata....otherwise use default values
        try
        {
            logger.LogInformation("Start GetCrosswordDataAsync()");

            //call the API
            var apiResponse = await CallDataApiAsync();

            //check what was returned
            return string.IsNullOrEmpty(apiResponse) ? GameConstants.DefaultPuzzleData : apiResponse;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            throw;
        }
    }

    #endregion
}