////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:     CallDataApi.cs                                        //
//      Authors:    Aaron Saikovski                                       //
//      Date:       31/10/2023                                            //
//      Purpose:    Gets CrosswordMain.Application puzzle data from an API.               //
//                                                                        //
////////////////////////////////////////////////////////////////////////////

using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Crossword.Shared.Config;
using Crossword.Shared.Constants;

using Crossword.Shared.Logger;

namespace Crossword.PuzzleData;

public partial class CrosswordData
{
    #region CallDataApi

    /// <summary>
    /// Calls the Data Svc API
    /// </summary>
    /// <returns></returns>
    // private static string? CallDataApi()
    // {
    //     //Use the HttpClient
    //     using (var client = new HttpClient())
    //     {
    //         try
    //         {
    //             //get config values from the appsettings
    //             var apiUrl = ConfigurationHelper.DataApiUrl;
    //             var apiKey = ConfigurationHelper.DataApiKey;
    //
    //             //pass in the API key to the header
    //             client.DefaultRequestHeaders.Clear();
    //             client.DefaultRequestHeaders.Add(CWSettings.ApiKeyName, apiKey);
    //             
    //             // Make the GET request to the API endpoint
    //             var response = client.GetAsync(apiUrl).Result;
    //
    //             //check for errors...response codes etc
    //             if (response.IsSuccessStatusCode) 
    //                 return response.Content.ReadAsStringAsync().Result;
    //             Console.WriteLine($"Failed to call the API. Status code: {response.StatusCode}");
    //             return null;
    //         }
    //         catch (Exception ex)
    //         {
    //             Console.WriteLine($"An error occurred: {ex.Message}");
    //             return null;
    //         }
    //     }
    // }
    
    #endregion

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
                client.DefaultRequestHeaders.Add(CWSettings.ApiKeyName, apiKey);

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
    
}