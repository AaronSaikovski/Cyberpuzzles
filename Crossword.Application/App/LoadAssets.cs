using System.IO;
using CyberPuzzles.Shared;
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
        // _imgHighliteSquare = Content.Load<Texture2D>("images/sqlite");
        // _imgSquareWord = Content.Load<Texture2D>("images/wordlite");
        // _imgNormalSquare = Content.Load<Texture2D>("images/normsq");
        
        _imgBlackSquare = Content.Load<Texture2D>("images/tile_black");
        _imgHighliteSquare = Content.Load<Texture2D>("images/tile_yellow");
        _imgSquareWord = Content.Load<Texture2D>("images/tile_orange");
        _imgNormalSquare = Content.Load<Texture2D>("images/tile_grey");
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
        _fntnumFont = fntHelveticaBoldSystem.GetFont(Constants.FntSml);

        //Char entered by user.    
        _fntFont = fntHelveticaBoldSystem.GetFont(Constants.FntLge);

        //Crossword.Application score      
        _fntScore = fntHelveticaBoldSystem.GetFont(Constants.FntLge);

        //Across/Down listbox Headers
        _fntListhead = fntHelveticaBoldSystem.GetFont(Constants.FntMed);

        //List font
        _fntListFont = fntHelveticaSystem.GetFont(Constants.FntMed);
    }
    #endregion
}