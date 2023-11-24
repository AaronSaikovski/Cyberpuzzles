using System.IO;
using CyberPuzzles.Crossword.Constants;
using FontStashSharp;
using Microsoft.Xna.Framework.Graphics;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region LoadImages
    /// <summary>
    /// Loads the images
    /// </summary>
    private void LoadImages()
    {
        _imgHighliteSquare = Content.Load<Texture2D>("images/sqlite");
        _imgSquareWord = Content.Load<Texture2D>("images/wordlite");
        _imgNormalSquare = Content.Load<Texture2D>("images/normsq");
    }

    #endregion

    #region LoadFonts
    private void LoadFonts()
    {
        //Read fonts from FS
        var fntHelveticaBold = File.ReadAllBytes("fonts/Helvetica-Bold.ttf");
        var fntHelveticaPlain = File.ReadAllBytes("fonts/Helvetica.ttf");

        //Add the Bold font
        var fntHelveticaBoldSystem = new FontSystem();
        fntHelveticaBoldSystem.AddFont(fntHelveticaBold);

        //Add the Normal font
        var fntHelveticaSystem = new FontSystem();
        fntHelveticaSystem.AddFont(fntHelveticaPlain);

        //Small number font
        _fntnumFont = fntHelveticaBoldSystem.GetFont(CwSettings.FntSml);

        //Char entered by user.    
        _fntFont = fntHelveticaBoldSystem.GetFont(CwSettings.FntLge);

        //Crossword.Application score      
        _fntScore = fntHelveticaBoldSystem.GetFont(CwSettings.FntLge);

        //Across/Down listbox Headers
        _fntListhead = fntHelveticaBoldSystem.GetFont(CwSettings.FntMed);

        //List font
        _fntListFont = fntHelveticaSystem.GetFont(CwSettings.FntMed);
    }
    #endregion
}