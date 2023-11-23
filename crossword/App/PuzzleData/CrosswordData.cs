
////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:     CrosswordData.cs                                      //
//      Authors:    Aaron Saikovski                                        //
//      Date:       31/10/2023                                            //
//      Purpose:    Gets Crossword puzzle data from a datasource.         //
//                                                                        //
////////////////////////////////////////////////////////////////////////////

using System;
using System.Net.Http;
using CyberPuzzles.Crossword.App.Config;
using CyberPuzzles.Crossword.Constants;

namespace CyberPuzzles.Crossword.App.PuzzleData
{
    public class CrosswordData
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

        #region GetCrosswordData

        /// <summary>
        /// Gets the crossword data from the API
        /// </summary>
        /// <returns></returns>
        public static string GetCrosswordData()
        {
            //Call the API to get the puzzledata....otherwise use default values
            try
            {
                //call the API
                var apiResponse = CallDataApi();

                //check what was returned
                return apiResponse ?? CwSettings.DefaultPuzzleData;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
        #endregion


    }

}