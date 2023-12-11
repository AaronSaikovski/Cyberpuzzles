////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:     GetCrosswordData.cs                                   //
//      Authors:    Aaron Saikovski                                       //
//      Date:       31/10/2023                                            //
//      Purpose:    Gets CrosswordMain.Application puzzle data from an API.               //
//                                                                        //
////////////////////////////////////////////////////////////////////////////

using System;
using System.Threading.Tasks;
using Crossword.Shared.Constants;

namespace Crossword.PuzzleData;

public partial class CrosswordData
{
    #region GetCrosswordData

    /// <summary>
    /// Gets the crossword data from the API
    /// </summary>
    /// <returns></returns>
    // public static string GetCrosswordData()
    // {
    //     //Call the API to get the puzzledata....otherwise use default values
    //     try
    //     {
    //         //call the API
    //         var apiResponse = CallDataApi();
    //
    //         //check what was returned
    //         return apiResponse ?? CWSettings.DefaultPuzzleData;
    //     }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine($"An error occurred: {ex.Message}");
    //         throw;
    //     }
    // }

    #endregion

    #region GetCrosswordDataAsync
    public static async Task<string> GetCrosswordDataAsync()
    {
        //Call the API to get the puzzledata....otherwise use default values
        try
        {
            //call the API
            var apiResponse = await CallDataApiAsync();

            //check what was returned
            return apiResponse ?? CWSettings.DefaultPuzzleData;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }
    #endregion
    
}