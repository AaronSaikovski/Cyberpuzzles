namespace Crossword.API;

using Crossword.Shared.ParserUtils;
using Crossword.Shared.Logger;

public static class PuzzleData
{
   /// <summary>
   /// Reads a random file from the file system and returns it as a string
   /// </summary>
   /// <param name="puzzleDataFile"></param>
   /// <returns></returns>
   public static string? GetCrosswordPuzzleData(string? puzzleDataFile)
   {
      //Init the logger
      var _logger = new SerilogLogger();
      
      try
      {
         _logger.LogInformation("GetCrosswordPuzzleData() called in API.");
        
          //check for null data file result
         if (puzzleDataFile is null) return null;
        
         //get the data file
         var fileResult = ParserHelper.GetRandomDataFile(puzzleDataFile);
         return fileResult;
      }
      catch (Exception ex)
      {
         _logger.LogError(ex, ex.Message);
         throw;
      }
      
   }
}