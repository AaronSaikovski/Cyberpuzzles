
namespace CyberPuzzles.Crossword.Parser;

public static class ParserHelper
{
    #region CountOccurrences
    /// <summary>
    /// Counts the occurrences of a char in a word
    /// </summary>
    /// <param name="inputString"></param>
    /// <param name="targetChar"></param>
    /// <returns></returns>
    public static int CountOccurrences(string inputString, char targetChar)
    {
        if (inputString.Length <= 0) throw new ArgumentOutOfRangeException(nameof(inputString));
        if (targetChar <= 0) throw new ArgumentOutOfRangeException(nameof(targetChar));
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
        if (puzzleData is { Length: <= 0 }) throw new ArgumentOutOfRangeException(nameof(puzzleData));
            
        // Get a list of all files in the folder
        var files = Directory.GetFiles(puzzleData);

        // Check if there are any files in the folder
        if (files.Length > 0)
        {
            // Generate a random number to select a file
            var random = new Random();
            var randomIndex = random.Next(0, files.Length);

            // Get the randomly selected file path
            var selectedFilePath = files[randomIndex];

            // Read the contents of the selected file
            var fileContents = File.ReadAllText(selectedFilePath);
            return fileContents;
        }
            
           

        return null;
    }
    #endregion

}