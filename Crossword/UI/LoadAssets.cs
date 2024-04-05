using System;
using System.IO;
using Crossword.Shared.Constants;
using FontStashSharp;
using Microsoft.Xna.Framework.Graphics;

namespace Crossword.App;

public sealed partial class CrosswordApp
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
            _imgBlackSquare = Content.Load<Texture2D>(UiConstants.BlackSquare);
            _imgHighliteSquare = Content.Load<Texture2D>(UiConstants.HighliteSquare);
            _imgSquareWord = Content.Load<Texture2D>(UiConstants.SquareWord);
            _imgNormalSquare = Content.Load<Texture2D>(UiConstants.NormalSquare);

            //load buttons
            _imgHintButton = Content.Load<Texture2D>(UiConstants.HintButtonImage);
            _imgNextPuzzButton = Content.Load<Texture2D>(UiConstants.NextPuzzleButtonImage);
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
            var fntHelveticaBold = File.ReadAllBytes(UiConstants.HelveticaBold);
            var fntHelveticaPlain = File.ReadAllBytes(UiConstants.HelveticaPlain);

            //Add the Bold font
            var fntHelveticaBoldSystem = new FontSystem();
            fntHelveticaBoldSystem.AddFont(fntHelveticaBold);

            //Add the Normal font
            var fntHelveticaSystem = new FontSystem();
            fntHelveticaSystem.AddFont(fntHelveticaPlain);

            //Small number font
            _fntnumFont = fntHelveticaBoldSystem.GetFont(UiConstants.FntSml);

            //Char entered by user.    
            _fntFont = fntHelveticaBoldSystem.GetFont(UiConstants.FntLge);

            //CrosswordApp.Application score      
            _fntScore = fntHelveticaBoldSystem.GetFont(UiConstants.FntLge);

            //Across/Down listbox Headers
            _fntListhead = fntHelveticaBoldSystem.GetFont(UiConstants.FntMed);

            //List font
            _fntListFont = fntHelveticaSystem.GetFont(UiConstants.FntMed);

            //Credits font
            _fntCredits = fntHelveticaSystem.GetFont(UiConstants.FntCredits);

        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            throw;
        }
    }
    #endregion
}