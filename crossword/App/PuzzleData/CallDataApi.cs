////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:     CallDataApi.cs                                        //
//      Authors:    Aaron Saikovski                                       //
//      Date:       31/10/2023                                            //
//      Purpose:    Gets Crossword puzzle data from an API.               //
//                                                                        //
////////////////////////////////////////////////////////////////////////////

using System;
using System.Net.Http;
using CyberPuzzles.Crossword.App.Config;

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
                //API 
                var apiUrl = ConfigurationHelper.DataApiUrl;

                // Make the GET request to the API endpoint
                var response = client.GetAsync(apiUrl).Result;

                //check for errors...response
                if (response.IsSuccessStatusCode) return response.Content.ReadAsStringAsync().Result;
                Console.WriteLine($"Failed to call the API. Status code: {response.StatusCode}");
                return null;

                //return the result
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