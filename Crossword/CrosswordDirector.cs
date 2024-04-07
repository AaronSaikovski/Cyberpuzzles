namespace Crossword.App;

public class CrosswordDirector
{
    private ICrosswordBuilder builder;
    
    
    public CrosswordDirector(ICrosswordBuilder builder)
    {
        this.builder = builder;
    }

    public void Construct()
    {
        //builder.BuildPuzzleGrid(5, 5); // For simplicity, let's assume a fixed size puzzle
        //builder.BuildClues();
    }
}