
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

namespace CyberPuzzles.Crossword.App.PuzzleData
{
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
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    //API 
                    string apiUrl = ConfigurationHelper.DataApiUrl;
                    
                    // Make the GET request to the API endpoint
                    var response = client.GetAsync(apiUrl).Result;
                    
                    //check for errors...response
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Failed to call the API. Status code: {response.StatusCode}");
                        return null;
                    }
                    else
                    {
                        //return the result
                        return response.Content.ReadAsStringAsync().Result;
                    }
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
        public static string? GetCrosswordData()
        {
            //default if the API fails
            var defaultPuzzleData = "761*QX000001*0909*0 0 1 1#4 1 1 6#0 2 1 7#2 3 1 9#0 5 1 11#4 6 1 16#0 7 1 17#4 8 1 18#0 0 2 1#2 0 2 2#4 0 2 3#6 0 2 4#8 0 2 5#3 2 2 8#5 3 2 10#0 5 2 11#2 5 2 12#4 5 2 13#6 5 2 14#8 5 2 15*Forward#Strictly accurate#Australian marsupial#Moving to avoid#Not accepted conduct#Astonish greatly#Provide meals#Occurrence#Pretend#Public way#Beer froth#Full-length dress#Adult male deer#Crazy#Metric unit of mass#Skin irritation#Friend#Uncommon#Inland body of water#Bench*FORTH#EXACT#KOALA#DODGING#IMMORAL#AMAZE#CATER#EVENT#FAKE#ROAD#HEAD#MAXI#STAG#LOCO#GRAM#ITCH#MATE#RARE#LAKE#SEAT*ZCDEFGHIKLMNORSTVXA*30 1 1 0 1 5*Use the clues to solve this crossword and earn CyberSilver. If you have not played our crosswords before and want help, then click the HELP button. Have fun!";
            
            //Call the API to get the puzzledata....otherwise use default values
            try
            {
                //call the API
                var apiResponse = CallDataApi();

                //check what was returned
                return apiResponse ?? defaultPuzzleData;
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