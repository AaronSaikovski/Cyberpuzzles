using Crossword.App;

//Main program entry point
using var game = new CrosswordApp();
game.Run();

//Implements the builder pattern
// ICrosswordBuilder builder = new CrosswordBuilder();
// CrosswordDirector director = new CrosswordDirector(builder);
// director.Construct();
// CrosswordPuzzle puzzle = builder.GetResult();
// puzzle.PrintPuzzle();