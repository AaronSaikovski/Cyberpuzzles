
namespace Crossword.Shared.ParserUtils;

/// <summary>
/// Parser helper class
/// </summary>
public static class ParserHelper
{
    private static readonly Random RandomGenerator = new();

    #region CountOccurrences
    /// <summary>
    /// Counts the occurrences of a char in a word
    /// </summary>
    /// <param name="inputString"></param>
    /// <param name="targetChar"></param>
    /// <returns></returns>
    public static int CountOccurrences(string inputString, char targetChar)
    {
        ArgumentException.ThrowIfNullOrEmpty(inputString);
        ArgumentException.ThrowIfNullOrEmpty(targetChar.ToString());

        return inputString.Count(c => c == targetChar);
    }
    #endregion

    #region GetRandomDataFile
    /// <summary>
    /// Read random data file contents from datafile path
    /// </summary>
    /// <param name="puzzleData"></param>
    /// <returns></returns>
    public static string? GetRandomDataFile(string? puzzleData)
    {
        //ArgumentNullException.ThrowIfNull(puzzleData);
        ArgumentException.ThrowIfNullOrEmpty(puzzleData);

        // Get a list of all files in the folder
        var files = Directory.GetFiles(puzzleData, "*.txt");

        // Check if there are any files in the folder
        if (files.Length <= 0) return null;
        // Generate a random number to select a file
        var randomIndex = RandomGenerator.Next(0, files.Length);

        // Get the randomly selected file path
        var selectedFilePath = files[randomIndex];

        // Read the contents of the selected file
        var fileContents = File.ReadAllText(selectedFilePath);
        return fileContents;

    }
    #endregion

}