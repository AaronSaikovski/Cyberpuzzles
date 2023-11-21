using System;
using System.IO;

namespace CyberPuzzles.Crossword.PuzzleData;

public partial class CrosswordData
{

    #region ReadRandomFile

    private static string ReadRandomFile(string folderPath)
    {
        // Get a list of all files in the folder
        var files = Directory.GetFiles(folderPath);

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

            // Display the contents of the selected file
            //Console.WriteLine("Randomly selected file: " + selectedFilePath);
            //Console.WriteLine("File contents:\n" + fileContents);
        }

        Console.WriteLine("The folder is empty.");
        return null;
    }

    #endregion
}