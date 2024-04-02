using System;
using System.Net.Http;
using System.Threading.Tasks;
using Crossword.Shared.Config;
using Crossword.Shared.Logger;
using Crossword.Shared.Constants;
<<<<<<< HEAD
=======

>>>>>>> main
namespace Crossword.FetchData;

/// <summary>
/// Fetches data from the Data API
/// </summary>
public partial class FetchCrosswordData
{
    #region CallDataApiAsync

    /// <summary>
    /// CallDataApiAsync
    /// </summary>
    /// <returns></returns>
    private static async Task<string?> CallDataApiAsync()
    {
        //Init the logger and get the active config
        var logger = new SerilogLogger(ConfigurationHelper.ActiveConfiguration);

        //Use the HttpClient
        using var client = new HttpClient();
        try
        {
            logger.LogInformation("Start CallDataApiAsync()");

            //get config values from the appsettings
            var apiUrl = ConfigurationHelper.DataApiUrl;
            var apiKey = ConfigurationHelper.DataApiKey;

            //pass in the API key to the header
            client.DefaultRequestHeaders.Clear();
<<<<<<< HEAD
            client.DefaultRequestHeaders.Add(ApiConstants.ApiKeyName, apiKey);
=======
            client.DefaultRequestHeaders.Add(APIConstants.ApiKeyName, apiKey);
>>>>>>> main

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
<<<<<<< HEAD
                    throw new Exception($"Failed to call the API. Status code: {response.StatusCode}");
=======
                    Console.WriteLine($"Failed to call the API. Status code: {response.StatusCode}");
                    return string.Empty;
>>>>>>> main
                }
                    
            }
            //catch http request exception
            catch (HttpRequestException httpex)
            {
                logger.LogError(httpex, httpex.Message);
                throw;
            }
        }
<<<<<<< HEAD
=======

>>>>>>> main
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return string.Empty;
        }
        finally
        {
            logger.Dispose();
        }
    }

    #endregion
}