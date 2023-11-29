using CyberPuzzles.Shared;

namespace CyberPuzzles.Crossword.App;


public sealed partial class Crossword
{
    #region InitData
    /// <summary>
    /// Inits the Crossword.Application data
    /// </summary>
    private void InitData()
    {
        //Initialise arrays of crossword data
        InitDataArrays();

        // Initialise Cybersilver costs
        InitCosts();

        //Initialise Hint letters
        _szGetLetters = _mrParserData.GetLetters;
        _szTmpGetLetters = _mrParserData.GetLetters;

        //Initialise Blurb
        _szBlurb = _mrParserData.Blurb;

        //Initialise dimension variables
        _nCrosswordWidth = _NumCols * Constants.nSquareWidth;
        _nCrosswordHeight = _NumRows * Constants.nSquareHeight;

        // offsets
        nCrossOffsetX = Constants.MainOffsetX;
        nCrossOffsetY = Constants.MainOffsetY;

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

            //Forces dirty squares
            ForceDirtySquares();
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
            if (_mrParserData.Costs != null) _nCosts[i] = _mrParserData.Costs[i];
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
            if (_mrParserData.ColRef != null) _colRef[i] = _mrParserData.ColRef[i];
            if (_mrParserData.RowRef != null) _rowRef[i] = _mrParserData.RowRef[i];
            if (_mrParserData.IsAcross != null)
                _bDataIsAcross[i] = _mrParserData.IsAcross[i] switch
                {
                    1 => true,
                    2 => false,
                    _ => _bDataIsAcross[i]
                };
            _quesNum[i] = _mrParserData.QuesNum[i];
            _szClues[i] = _mrParserData.Clues[i];
            _szAnswers[i] = _mrParserData.Answers[i];
        }
    }
    #endregion
}