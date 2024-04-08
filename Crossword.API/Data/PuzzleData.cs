using Crossword.Shared.ParserUtils;

namespace Crossword.API.Data;

public static class PuzzleData
{
    /// <summary>
    /// Reads a random file from the file system and returns it as a string
    /// </summary>
    /// <param name="puzzleDataFile"></param>
    /// <returns></returns>
    public static string? GetCrosswordPuzzleData(string? puzzleDataFile)
    {
        
        ArgumentException.ThrowIfNullOrEmpty(puzzleDataFile);

        //get the data file
        var fileResult = ParserHelper.GetRandomDataFile(puzzleDataFile);
        return fileResult;
    }
}