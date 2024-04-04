using Crossword.API.Data;

namespace Crossword.API.Endpoints;

public static class CrosswordData
{
    #region RegisterCrosswordEndpoints
    
    //Ref: https://blog.treblle.com/how-to-structure-your-minimal-api-in-net/
    
    /// <summary>
    /// RegisterCrosswordDataEndpoint
    /// </summary>
    /// <param name="routes"></param>
    public static void RegisterCrosswordEndpoints(this IEndpointRouteBuilder routes)
    {
        var crosswordData = routes.MapGroup("/api/v1/crosswordpuzzledata");
        
        crosswordData.MapGet("/getcrosswordpuzzledata", (IConfiguration configuration) => PuzzleData.GetCrosswordPuzzleData(configuration["DatafilePath"])).WithName("GetCrosswordPuzzleData");
    }
    #endregion
}