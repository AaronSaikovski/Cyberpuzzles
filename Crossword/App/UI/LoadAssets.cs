using System;
using System.IO;
using Crossword.Constants;
using FontStashSharp;
using Microsoft.Xna.Framework.Graphics;

namespace Crossword.App;

public sealed partial class CrosswordMain
{
    #region LoadImages
    /// <summary>
    /// Loads the images
    /// </summary>
    private void LoadImages()
    {
        try
        {
            //load squares
            _imgBlackSquare = Content.Load<Texture2D>(UIConstants.BlackSquare);
            _imgHighliteSquare = Content.Load<Texture2D>(UIConstants.HighliteSquare);
            _imgSquareWord = Content.Load<Texture2D>(UIConstants.SquareWord);
            _imgNormalSquare = Content.Load<Texture2D>(UIConstants.NormalSquare);
        
            //load buttons
            _imgHintButton = Content.Load<Texture2D>(UIConstants.HintButtonImage);
            _imgNextPuzzButton = Content.Load<Texture2D>(UIConstants.NextPuzzleButtonImage);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }    

    #endregion

    #region LoadFonts
    /// <summary>
    /// Loads the fonts
    /// </summary>
    private void LoadFonts()
    {
        try
        {
            logger.LogInformation("Start LoadFonts()");
            
            //Read fonts from FS
            var fntHelveticaBold = File.ReadAllBytes(UIConstants.HelveticaBold);
            var fntHelveticaPlain = File.ReadAllBytes(UIConstants.HelveticaPlain);

            //Add the Bold font
            var fntHelveticaBoldSystem = new FontSystem();
            fntHelveticaBoldSystem.AddFont(fntHelveticaBold);

            //Add the Normal font
            var fntHelveticaSystem = new FontSystem();
            fntHelveticaSystem.AddFont(fntHelveticaPlain);

            //Small number font
            _fntnumFont = fntHelveticaBoldSystem.GetFont(UIConstants.FntSml);

            //Char entered by user.    
            _fntFont = fntHelveticaBoldSystem.GetFont(UIConstants.FntLge);

            //CrosswordMain.Application score      
            _fntScore = fntHelveticaBoldSystem.GetFont(UIConstants.FntLge);

            //Across/Down listbox Headers
            _fntListhead = fntHelveticaBoldSystem.GetFont(UIConstants.FntMed);

            //List font
            _fntListFont = fntHelveticaSystem.GetFont(UIConstants.FntMed);
            
            //Credits font
            _fntCredits = fntHelveticaSystem.GetFont(UIConstants.FntCredits);
        
        }
        catch (Exception ex)
        {
            logger.LogError(ex,ex.Message);
            throw;
        }
    }
    #endregion
}