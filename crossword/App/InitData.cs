using CyberPuzzles.Crossword.Constants;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region InitData

    private void InitData()
    {
        //Initialise arrays of crossword data
        for (var i = 0; i < nNumQuestions; i++)
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

        // Initialise Cybersilver costs
        for (var i = 0; i < 6; i++)
        {
            _nCosts[i] = _mrParser.Costs[i];
        }

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
        //nCrossOffsetX = (int)(nMAX_CROSS_WIDTH/2) - (int)((nCrosswordWidth +(2*nCROSS_BORDER_WIDTH))/2);
        //nCrossOffsetY = (int)(nMAX_CROSS_HEIGHT/2) - (int)((nCrosswordHeight +(2*nCROSS_BORDER_WIDTH))/2);

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
}