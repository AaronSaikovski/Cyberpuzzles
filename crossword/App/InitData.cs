using CyberPuzzles.Crossword.Constants;

namespace CyberPuzzles.Crossword.App;


public sealed partial class Crossword
{
    #region InitData
    /// <summary>
    /// Inits the Crossword data
    /// </summary>
    private void InitData()
    {
        //Initialise arrays of crossword data
        InitDataArrays();

        // Initialise Cybersilver costs
        InitCosts();

        //Initialise Hint letters
        _szGetLetters = _mrParser.SzGetLetters;
        _szTmpGetLetters = _mrParser.SzGetLetters;

        //Initialise Blurb
        _szBlurb = _mrParser.SzBlurb;

        //Initialise dimension variables
        _nCrosswordWidth = _NumCols * CwSettings.nSquareWidth;
        _nCrosswordHeight = _NumRows * CwSettings.nSquareHeight;

        // offsets
        nCrossOffsetX = CwSettings.MainOffsetX;
        nCrossOffsetY = CwSettings.MainOffsetY;

        //set squares as dirty
        InitDirtySquares();
    }
    #endregion

    #region InitDirtySquares
    /// <summary>
    /// Inits the dirty squares
    /// </summary>
    private void InitDirtySquares()
    {
        //set squares as dirty
        if (!NewBackFlush) return;
        {
            if (!InitCrossword) return;
            for (var i = 0; i < _NumRows; i++) //down
            for (var j = 0; j < _NumCols; j++) //across
                sqPuzzleSquares[i, j].IsDirty = true;
        }
    }
    #endregion

    #region InitCosts
    /// <summary>
    /// Inits the costs
    /// </summary>
    private void InitCosts()
    {
        // Initialise Cybersilver costs
        for (var i = 0; i < 6; i++)
        {
            _nCosts[i] = _mrParser.Costs[i];
        }
    }
    #endregion

    #region InitDataArrays
    /// <summary>
    /// Inits the data arrays
    /// </summary>
    private void InitDataArrays()
    {
        //Initialise arrays of crossword data
        for (var i = 0; i < NumQuestions; i++)
        {
            _colRef[i] = _mrParser.ColRef[i];
            _rowRef[i] = _mrParser.RowRef[i];
            _bDataIsAcross[i] = _mrParser.IsAcross[i] switch
            {
                1 => true,
                2 => false,
                _ => _bDataIsAcross[i]
            };
            _quesNum[i] = _mrParser.QuesNum[i];
            _szClues[i] = _mrParser.SzClues[i];
            _szAnswers[i] = _mrParser.SzAnswers[i];
        }
    }
    #endregion
}