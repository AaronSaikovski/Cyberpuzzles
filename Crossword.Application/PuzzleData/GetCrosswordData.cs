////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:     GetCrosswordData.cs                                   //
//      Authors:    Aaron Saikovski                                       //
//      Date:       31/10/2023                                            //
//      Purpose:    Gets Crossword.Application puzzle data from an API.               //
//                                                                        //
////////////////////////////////////////////////////////////////////////////

using System;
using CyberPuzzles.Shared;

namespace CyberPuzzles.Crossword.App.PuzzleData;

public partial class CrosswordData
{
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
            return apiResponse ?? Constants.DefaultPuzzleData;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }

    #endregion
}