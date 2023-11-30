////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:     CallDataApi.cs                                        //
//      Authors:    Aaron Saikovski                                       //
//      Date:       31/10/2023                                            //
//      Purpose:    Gets Crossword.Application puzzle data from an API.               //
//                                                                        //
////////////////////////////////////////////////////////////////////////////

using System;
using System.Net.Http;
using CyberPuzzles.Shared.Config;
using CyberPuzzles.Shared.Constants;

namespace CyberPuzzles.Crossword.App.PuzzleData;

public partial class CrosswordData
{
    #region CallDataApi

    /// <summary>
    /// Calls the Data Svc API
    /// </summary>
    /// <returns></returns>
    private static string? CallDataApi()
    {
        //Use the HttpClient
        using (var client = new HttpClient())
        {
            try
            {
                //get config values from the appsettings
                var apiUrl = ConfigurationHelper.DataApiUrl;
                var apiKey = ConfigurationHelper.DataApiKey;

                //pass in the API key to the header
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(CWSettings.APIKeyName, apiKey);
                
                // Make the GET request to the API endpoint
                var response = client.GetAsync(apiUrl).Result;

                //check for errors...response codes etc
                if (response.IsSuccessStatusCode) 
                    return response.Content.ReadAsStringAsync().Result;
                Console.WriteLine($"Failed to call the API. Status code: {response.StatusCode}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
    }

    #endregion
}