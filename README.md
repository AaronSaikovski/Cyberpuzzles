<div align="center">

# CyberPuzzles - Crossword

A Monogame C# .Net 8.0 Core port of a Java Applet game I co-wrote back in 1997.

**Full co-authoring credits go to Bryan Richards and Neil Reading (RIP) from the OzEmail days (circa 1997)**

</div>

## Version History:

- 1.0 - Initial release for initial feedback. - Please report all bugs [here](https://github.com/AaronSaikovski/CyberPuzzles/issues).

---

### Description:

A true to life interactive crossword game that uses the keyboard and mouse for input.
Leverages a minimal API that uses the original data format for crossword data. If it cannot contact the Data service API, it will use a test data set for validation and testing purposes.

This game was written in C#12 and leverages the Microsoft .Net 8 core framework with [Monogame](https://monogame.net/index.html) and a .Net Minimal WebAPI for loading the puzzle datasets.

This was ported across from a **very** old Java SDK to use .Net 8.0, C# 12 and nullable types but uses many of the older style programming techniques from that time.

To play the game you can use the keyboard - Arrow keys and the mouse to navigate and the spacebar to change the navigation from across to down and vice versa.

Please feel free to share this and make any changes as you see fit.

Screenshot below:

![crossword screenshot.](crossword-screenshot.png)

---

### Software Requirements:

- [Microsoft .Net 8.0 Core SDK/Runtime Framework](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Visual Studio Code](https://code.visualstudio.com/download)
- [C# DevKit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
- Optional - [JetBrains Rider](https://www.jetbrains.com/rider/)

---

### Project Structure:

The Crossword solution is structured as follows:

- Crossword.API.Data - The Data service minimal API with an API key - Parses the local dataset files and randomly returns a string containing the dataset to be parsed by the Crossword.Parser project.
- Crossword.Application - The Main crossword game - All the game and puzzle logic lives here. This will be refactored and cleaned up some more in a future release.
- Crossword.Parser - The main parser that processes the puzzle data set from the API for use by the crossword.
- Crossword.Shared - A shared class library for use in both the main game and API.

---

### Game Local Build Setup:

Refer to the Monogame game packing for games [here](https://monogame.net/articles/packaging_games.html)

In the root folder where the 'CyberPuzzles.sln' file is located, you should run the following to get started:

```bash
dotnet clean

dotnet restore

dotnet build

# if you are brave ;-)
dotnet run ./Crossword.Application
```

This will validate and restore the required Nuget packages and ensure the solution builds.

To build locally for your target native platform:

```bash
## Windows
# x86
dotnet build -r win-x64 -c Release

# ARM
dotnet build -r win-arm64 -c Release

## Linux
# x86
dotnet build -r linux-x64 -c Release

# ARM
dotnet build -r linux-arm64 -c Release

## MacOS
# x86
dotnet build -r osx-x64 -c Release

# ARM
dotnet build -r osx-arm64 -c Release
```

To create a publish release locally for your target platform:

```bash
## Windows
# x86
dotnet publish -r win-x64 -c Release

# ARM
dotnet publish -r win-arm64 -c Release

## Linux
# x86
dotnet publish -r linux-x64 -c Release

# ARM
dotnet publish -r linux-arm64 -c Release

## MacOS
# x86
dotnet publish -r osx-x64 -c Release

# ARM
dotnet publish -r osx-arm64 -c Release
```

**Please note that this game has been tested on MacOS ARM (M1) and Windows x86 only - it hasnt been tested on other platforms due to some limitations with MonoGame.**

---

### Data Service WebAPI:

Use your favourite tool to deploy to Azure and ensure that the following settings are configured for the web application:

- WebApp name: crossworddatasvc (The full WebAPI url should be: https://crossworddatasvc.azurewebsites.net/getcrosswordpuzzledata)
- WebApp SKU: F1
- WebApp Framework: .Net 8.0 Core LTS

The WebAPI also uses an API Key set in the variable 'XApiKey' - This has a default value but can be changed to another value. I will document this more in the future.

This has only been tested on Azure Web Apps and I will containerise this in the future to make this more portable.

---

### Known Bugs/Issues:

Please report all bugs [here](https://github.com/AaronSaikovski/CyberPuzzles/issues).

- Some characters are not properly centred in squares.
- ListBox Event handlers disabled - You cant click on the ListBoxes to change the puzzle navigation - this will be fixed in the future.
- Next Puzzle sometimes double taps and skips loading puzzle data.

---

### Items for future releases:

- GitHub action for building and releasing onto all platforms.
- Reformat puzzle data format to use JSON instead of the custom data file format.
- Create a Docker file to host the Dataservice API.

---
