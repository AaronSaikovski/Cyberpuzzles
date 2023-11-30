////////////////////////////////////////////////////////////////////////////
//                                                                        //
//      Module:     GetCrosswordData.cs                                   //
//      Authors:    Aaron Saikovski                                       //
//      Date:       31/10/2023                                            //
//      Purpose:    Gets CrosswordApp.Application puzzle data from an API.               //
//                                                                        //
////////////////////////////////////////////////////////////////////////////

using System;
using Crossword.Shared.Constants;

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