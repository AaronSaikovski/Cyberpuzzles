using System;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region MainInit
    /// <summary>
    /// MainInit - Main App initializer
    /// </summary>
    private void MainInit()
    {
        try
        {
            _logger.LogInformation("**Start MainInit()**");

            //load fonts
            LoadFonts();

            //Load images
            LoadImages();

            //Init the data
            InitData();

            //Init the controls
            InitControls();

            //init the hint button
            DrawHintButton();

            //init the Get Next Puzzle button
            DrawGetNextPuzzleButton();

            //build the crossword data
            InitialiseCrossword();

            _newBackFlush = true;

            //Show the lists
            if (_lstClueAcross is not null) _lstClueAcross.Visible = true;
            if (_lstClueDown is not null)_lstClueDown.Visible = true;

            //Set the initial active square
            _sqCurrentSquare = _caPuzzleClueAnswers?[0].GetSquare();

            //Return the orientation
            if (_caPuzzleClueAnswers != null)
            {
                _isAcross = _caPuzzleClueAnswers[0].IsAcross;

                //Highlight the default square...if allowed
                _caPuzzleClueAnswers[0].HighlightSquares(_sqCurrentSquare, true);
            }

            //Set the default across list item to be the first item in the list
            if (_lstClueAcross is not null) _lstClueAcross.SelectedIndex = 0;

            //Forces dirty squares
            InitDirtySquares();

            //Set index to bubble out
            _bBufferDirty = true;
            _newBackFlush = true;

            //Get next puzzle ID
            //_bMorePuzzles = true; 

            //Cleanup
            GC.Collect();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }
    #endregion
}