<div align="center">

# CyberPuzzles - Crossword

A Monogame C# .Net 8.0 port of a Java Applet game I co-wrote back in 1997.

**Full co-authoring credits go to Bryan Richards and Neil Reading (RIP).**

</div>

## Version History:

- 1.0 - Initial release for initial feedback.

### Description

This game leverages the Microsoft .Net 8 core framework with [Monogame](https://monogame.net/index.html) and a .Net Minimal WebAPI for loading the puzzle datasets.
A true to life interactive crossword game that uses the keyboard and mouse for input.
Leverages a minimal API that uses the original data format for crossword data.

![[crossword-screenshot.png]]

### Software Requirements

- [Microsoft .Net 8.0 Core SDK/Runtime Framework](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Visual Studio Code](https://code.visualstudio.com/download)
- [C# DevKit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
- Optional - [JetBrains Rider](https://www.jetbrains.com/rider/)

### Game Local Build

Refer to the Monogame game packing for games [here](https://monogame.net/articles/packaging_games.html)

To build locally for your target platform:

Windows

- dotnet build -r win-x64 -c Release
- dotnet build -r win-arm64 -c Release

Linux

- dotnet build -r linux-x64 -c Release
- dotnet build -r linux-arm64 -c Release

MacOS

- dotnet build -r osx-x64 -c Release
- dotnet build -r osx-arm64 -c Release

To create a publish release locally for your target platform:

Windows

- dotnet publish -r win-x64 -c Release
- dotnet publish -r win-arm64 -c Release

Linux

- dotnet publish -r linux-x64 -c Release
- dotnet publish -r linux-arm64 -c Release

MacOS

- dotnet publish -r osx-x64 -c Release
- dotnet publish -r osx-arm64 -c Release

### Web API

Use your favourite tool to deploy to Azure and ensure that the following settings are configured for the web application:

- WebApp name: crossworddatasvc (Ss the full WebAPI url should be: https://crossworddatasvc.azurewebsites.net/getcrosswordpuzzledata)
- WebApp SKU: F1
- WebApp Framework: .Net 8.0 Core LTS

### Known Bugs

- Font chars not properly centred in squares.
- ListBox Event handlers disabled - known issue
- Next Puzzle sometimes double taps - investigating.

### Items for future releases

- GitHub action for building X-Platform
