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
            logger.LogInformation("**Start MainInit()**");
            
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

            NewBackFlush = true;

            //Show the lists
            LstClueAcross.Visible = true;
            LstClueDown.Visible = true;

            //Set the initial active square
            _sqCurrentSquare = _caPuzzleClueAnswers[0].GetSquare();

            //Return the orientation
            _isAcross = _caPuzzleClueAnswers[0].IsAcross;

            //Highlight the default square...if allowed
            _caPuzzleClueAnswers[0].HighlightSquares(_sqCurrentSquare, true);

            //Set the default across list item to be the first item in the list
            LstClueAcross.SelectedIndex = 0;

            //Forces dirty squares
            InitDirtySquares();

            //Set index to bubble out
            bBufferDirty = true;
            NewBackFlush = true;

            //Get next puzzle ID
            //_bMorePuzzles = true; 
            
            //Cleanup
            GC.Collect();
            
        }
        catch (Exception ex)
        {
            logger.LogError(ex,ex.Message);
            throw;
        }
    }
    #endregion
}