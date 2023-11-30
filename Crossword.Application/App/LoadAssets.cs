using System.IO;
using Crossword.Shared.Constants;
using FontStashSharp;
using Microsoft.Xna.Framework.Graphics;

namespace CyberPuzzles.Crossword.App;

public sealed partial class CrosswordApp
{
    #region LoadImages
    /// <summary>
    /// Loads the images
    /// </summary>
    private void LoadImages()
    {
        //load images
        _imgBlackSquare = Content.Load<Texture2D>(CWSettings.BlackSquare);
        _imgHighliteSquare = Content.Load<Texture2D>(CWSettings.HighliteSquare);
        _imgSquareWord = Content.Load<Texture2D>(CWSettings.SquareWord);
        _imgNormalSquare = Content.Load<Texture2D>(CWSettings.NormalSquare);
    }

    #endregion

    #region LoadFonts
    private void LoadFonts()
    {
        //Read fonts from FS
        var fntHelveticaBold = File.ReadAllBytes(CWSettings.HelveticaBold);
        var fntHelveticaPlain = File.ReadAllBytes(CWSettings.HelveticaPlain);

        //Add the Bold font
        var fntHelveticaBoldSystem = new FontSystem();
        fntHelveticaBoldSystem.AddFont(fntHelveticaBold);

        //Add the Normal font
        var fntHelveticaSystem = new FontSystem();
        fntHelveticaSystem.AddFont(fntHelveticaPlain);

        //Small number font
        _fntnumFont = fntHelveticaBoldSystem.GetFont(CWSettings.FntSml);

        //Char entered by user.    
        _fntFont = fntHelveticaBoldSystem.GetFont(CWSettings.FntLge);

        //CrosswordApp.Application score      
        _fntScore = fntHelveticaBoldSystem.GetFont(CWSettings.FntLge);

        //Across/Down listbox Headers
        _fntListhead = fntHelveticaBoldSystem.GetFont(CWSettings.FntMed);

        //List font
        _fntListFont = fntHelveticaSystem.GetFont(CWSettings.FntMed);
    }
    #endregion
}