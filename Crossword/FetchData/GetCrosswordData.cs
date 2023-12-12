////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:     GetCrosswordData.cs                                   //
//      Authors:    Aaron Saikovski                                       //
//      Date:       31/10/2023                                            //
//      Purpose:    Gets CrosswordMain.Application puzzle data from an API.               //
//                                                                        //
////////////////////////////////////////////////////////////////////////////

// using System;
// using System.Threading.Tasks;
// using Crossword.Constants;
// using Crossword.Shared.Logger;
//
// namespace Crossword.FetchData;
//
// public partial class CrosswordData
// {
//     #region GetCrosswordData
//
//     /// <summary>
//     /// Gets the crossword data from the API
//     /// </summary>
//     /// <returns></returns>
//     // public static string GetCrosswordData()
//     // {
//     //     //Call the API to get the puzzledata....otherwise use default values
//     //     try
//     //     {
//     //         //call the API
//     //         var apiResponse = CallDataApi();
//     //
//     //         //check what was returned
//     //         return apiResponse ?? CWSettings.DefaultPuzzleData;
//     //     }
//     //     catch (Exception ex)
//     //     {
//     //         Console.WriteLine($"An error occurred: {ex.Message}");
//     //         throw;
//     //     }
//     // }
//
//     #endregion
//
//     #region GetCrosswordDataAsync
//     public static async Task<string> GetCrosswordDataAsync()
//     {
//         //Init the logger
//         var _logger = new SerilogLogger();
//         
//         //Call the API to get the puzzledata....otherwise use default values
//         try
//         {
//             _logger.LogInformation("Start GetCrosswordDataAsync()");
//             
//             //call the API
//             string apiResponse = await CallDataApiAsync();
//             
//             //check what was returned
//             if (string.IsNullOrEmpty(apiResponse))
//             {
//                 return GameConstants.DefaultPuzzleData;
//             }
//             else
//             {
//                 return apiResponse;
//             }
//
//         }
//         catch (Exception ex)
//         {
//             _logger.LogError(ex,ex.Message);
//             throw;
//         }
//     }
//     #endregion
//     
// }