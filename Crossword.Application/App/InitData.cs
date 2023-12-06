using System;
using System.Threading.Tasks;
using Crossword.Shared.Constants;

namespace Crossword.App;


public sealed partial class CrosswordMain
{
    #region InitData
    /// <summary>
    /// Inits the CrosswordMain.Application data
    /// </summary>
    private void InitData()
    {
        try
        {
            //Initialise arrays of crossword data
            InitDataArrays();

            // Initialise Cybersilver costs
            InitCosts();

            //Initialise Hint letters
            _szGetLetters = _mrParserData?.GetLetters;
            _szTmpGetLetters = _mrParserData?.GetLetters;

            //Initialise Blurb
            _szBlurb = _mrParserData?.Blurb;

            //Initialise dimension variables
            _nCrosswordWidth = _NumCols * (CWSettings.SquareWidth + (int)CWSettings.SquareSpacer);
            _nCrosswordHeight = _NumRows * (CWSettings.SquareHeight + (int)CWSettings.SquareSpacer);
            
            // offsets
            nCrossOffsetX = CWSettings.MainOffsetX;
            nCrossOffsetY = CWSettings.MainOffsetY;

            //set squares as dirty
            InitDirtySquares();
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    #endregion

    #region InitDirtySquares
    /// <summary>
    /// Inits the dirty squares
    /// </summary>
    private void InitDirtySquares()
    {
        try
        {
            //set squares as dirty
            if (!NewBackFlush) return;
            {
                if (!InitCrossword) return;

                //Forces dirty squares
                ForceDirtySquares();
            }
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    #endregion

    #region InitCosts
    /// <summary>
    /// Inits the costs
    /// </summary>
    private void InitCosts()
    {
        try
        {
            // Initialise Cybersilver costs
            for (var i = 0; i < 6; i++)
            {
                if (_mrParserData?.Costs is not null) _nCosts[i] = _mrParserData.Costs[i];
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
       
    }
    #endregion

    #region InitDataArrays
    /// <summary>
    /// Inits the data arrays
    /// </summary>
    private void InitDataArrays()
    {
        try
        {
            Parallel.For(0, NumQuestions, i =>
            {
                if (_mrParserData?.ColRef is not null) _colRef[i] = _mrParserData.ColRef[i];
                if (_mrParserData?.RowRef is not null) _rowRef[i] = _mrParserData.RowRef[i];
                if (_mrParserData?.IsAcross is not null)
                    _bDataIsAcross[i] = _mrParserData.IsAcross[i] switch
                    {
                        1 => true,
                        2 => false,
                        _ => _bDataIsAcross[i]
                    };
                if (_mrParserData?.QuesNum is not null) _quesNum[i] = _mrParserData.QuesNum[i];
                if (_mrParserData?.Clues is not null) _szClues[i] = _mrParserData.Clues[i];
                if (_mrParserData?.Answers is not null) _szAnswers[i] = _mrParserData.Answers[i];
            });
        
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    #endregion
}