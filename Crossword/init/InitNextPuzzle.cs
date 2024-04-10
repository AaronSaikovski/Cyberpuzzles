using System;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region InitNextPuzzle
    /// <summary>
    ///  //Get the next puzzle. loads the dataset
    /// </summary>
    private void InitNextPuzzle()
    {
        try
        {
            //Reset everything and reinitialise
            _logger.LogInformation("Start GetNextPuzzle()");

            //Repaint variables
            _bBufferDirty = true;
            _initCrossword = true;
            IsFinished = true;
            _newBackFlush = true;
            _puzzleFinished = false;
            _setFinished = false;

            //get the new data set
            _mrParserData = null;
            InitPuzzleData();


            //list boxes
            _lstClueAcross!.Items.Clear();
            _lstClueDown!.Items.Clear();

            //Init the data
            InitData();

            //remove all widgets from the main panel
            _mainPanel!.Widgets.Clear();

            //Init the controls
            InitControls();

            //build the crossword data
            InitialiseCrossword();

            _newBackFlush = true;

            //Show the lists
            _lstClueAcross.Visible = true;
            _lstClueDown.Visible = true;

            //Set the initial active square
            _sqCurrentSquare = _caPuzzleClueAnswers![0].GetSquare();

            //Return the orientation
            _isAcross = _caPuzzleClueAnswers[0].IsAcross;

            //Highlight the default square...if allowed
            _caPuzzleClueAnswers[0].HighlightSquares(_sqCurrentSquare, true);

            //Set the default across list item to be the first item in the list
            _lstClueAcross.SelectedIndex = 0;

            //Forces dirty squares
            InitDirtySquares();

            //Set index to bubble out
            _bBufferDirty = true;
            _newBackFlush = true;

            IsFinished = false;

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