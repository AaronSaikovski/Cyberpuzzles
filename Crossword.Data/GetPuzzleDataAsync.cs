using Crossword.Shared.Constants;
using Crossword.Shared.Logger;
using Crossword.Shared.Config;

namespace Crossword.Data;

/// <summary>
/// Calls the Crossword.API to get the Puzzledata as a string
/// </summary>
public static partial class GetPuzzleDataAsync
{
    private static readonly HttpClient HttpClientInstance = new();

    #region CallDataApiAsync

    /// <summary>
    /// CallDataApiAsync
    /// </summary>
    /// <returns></returns>
    private static async Task<string?> CallDataApiAsync()
    {
        //Init the logger and get the active config
        using var logger = new SerilogLogger(ConfigurationHelper.ActiveConfiguration);

        //Use the HttpClient
        var client = HttpClientInstance;
        try
        {
            logger.LogInformation("Start CallDataApiAsync()");

            //get config values from the appsettings
            var apiUrl = ConfigurationHelper.DataApiUrl;
            var apiKey = ConfigurationHelper.DataApiKey;

            //pass in the API key to the header
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add(ApiConstants.ApiKeyName, apiKey);

            //catch inner HttpRequestException
            try
            {
                var response = await client.GetAsync(apiUrl);

                //check for errors...response codes etc
                if (response.IsSuccessStatusCode)
                {
                    //get the response from the API call result as a string
                    return await response.Content.ReadAsStringAsync();
                }

                throw new Exception($"Failed to call the API. Status code: {response.StatusCode}");

            }
            //catch http request exception
            catch (HttpRequestException httpex)
            {
                logger.LogError(httpex, httpex.Message);
                throw;
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return string.Empty;
        }

    }

    #endregion
}