using System;
using System.Threading.Tasks;
using Crossword.Shared.Constants;

namespace Crossword.App;


public sealed partial class CrosswordApp
{
    #region InitData
    /// <summary>
    /// Inits the CrosswordApp.Application data
    /// </summary>
    private void InitData()
    {
        try
        {
            _logger.LogInformation("Start InitData()");

            //Initialise arrays of crossword data
            InitDataArrays();

            //Initialise Hint letters
            _szGetLetters = _mrParserData?.GetLetters;
            _szTmpGetLetters = _mrParserData?.GetLetters;

            //Initialise Blurb
            //_szBlurb = _mrParserData?.Blurb;

            //Initialise dimension variables
            _nCrosswordWidth = _NumCols * (UiConstants.SquareWidth + (int)UiConstants.SquareSpacer);
            _nCrosswordHeight = _NumRows * (UiConstants.SquareHeight + (int)UiConstants.SquareSpacer);

            // offsets
            _nCrossOffsetX = UiConstants.MainOffsetX;
            _nCrossOffsetY = UiConstants.MainOffsetY;

            //set squares as dirty
            InitSquares();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
    #endregion

    #region InitDirtySquares
    /// <summary>
    /// Inits the dirty squares
    /// </summary>
    private void InitSquares()
    {
        try
        {
            _logger.LogInformation("Start InitDirtySquares()");

            //set squares as dirty
            if (!_newBackFlush) return;
            {
                if (!_initCrossword) return;

                //Forces dirty squares
                InitDirtySquares();
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
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
            _logger.LogInformation("Start InitDataArrays()");

            // Use regular loop instead of Parallel.For (_numQuestions is typically small)
            for (var i = 0; i < _numQuestions; i++)
            {
                if (_mrParserData?.ColRef is not null) _colRef![i] = _mrParserData.ColRef[i];
                if (_mrParserData?.RowRef is not null) _rowRef![i] = _mrParserData.RowRef[i];
                if (_mrParserData?.IsAcross is not null)
                    _bDataIsAcross![i] = _mrParserData.IsAcross[i] switch
                    {
                        1 => true,
                        2 => false,
                        _ => _bDataIsAcross[i]
                    };
                if (_mrParserData?.QuesNum is not null) _quesNum![i] = _mrParserData.QuesNum[i];
                if (_mrParserData?.Clues is not null) _szClues![i] = _mrParserData.Clues[i];
                if (_mrParserData?.Answers is not null) _szAnswers![i] = _mrParserData.Answers[i];
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
    #endregion
}