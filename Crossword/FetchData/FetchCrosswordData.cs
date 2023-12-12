using System;
using System.Net.Http;
using System.Threading.Tasks;
using Crossword.Shared.Config;
using Crossword.Constants;
using Crossword.Shared.Logger;


namespace Crossword.FetchData;

public class FetchCrosswordData
{
    #region CallDataApiAsync
    /// <summary>
    /// Calls the Data service API Async version
    /// </summary>
    /// <returns></returns>
    private static async Task<string> CallDataApiAsync()
    {
        //Init the logger
        var _logger = new SerilogLogger();
        
        //Use the HttpClient
        using (var client = new HttpClient())
        {
            try
            {
                _logger.LogInformation("Start CallDataApiAsync()");

                //get config values from the appsettings
                var apiUrl = ConfigurationHelper.DataApiUrl;
                var apiKey = ConfigurationHelper.DataApiKey;

                //pass in the API key to the header
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(GameConstants.ApiKeyName, apiKey);

                //catch inner HttpRequestException
                try
                {
                    var response = await client.GetAsync(apiUrl);
                    
                    //check for errors...response codes etc
                    if (response.IsSuccessStatusCode)
                    {
                        //get the response from the API call result as a string
                        return response.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        Console.WriteLine($"Failed to call the API. Status code: {response.StatusCode}");
                        return string.Empty;
                    }
                }
                //catch http request exception
                catch (System.Net.Http.HttpRequestException http_exp)
                {
                    _logger.LogError(http_exp,http_exp.Message);
                    throw;
                }
               
            }
            
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                return string.Empty;
            }
        }
    }

    #endregion
    
    #region GetCrosswordDataAsync
    public static async Task<string> GetCrosswordDataAsync()
    {
        //Init the logger
        var _logger = new SerilogLogger();
        
        //Call the API to get the puzzledata....otherwise use default values
        try
        {
            _logger.LogInformation("Start GetCrosswordDataAsync()");
            
            //call the API
            string apiResponse = await CallDataApiAsync();
            
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
            _logger.LogError(ex,ex.Message);
            throw;
        }
    }
    #endregion
}