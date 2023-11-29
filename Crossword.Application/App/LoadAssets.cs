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
        //load images
        _imgBlackSquare = Content.Load<Texture2D>(Constants.BlackSquare);
        _imgHighliteSquare = Content.Load<Texture2D>(Constants.HighliteSquare);
        _imgSquareWord = Content.Load<Texture2D>(Constants.SquareWord);
        _imgNormalSquare = Content.Load<Texture2D>(Constants.NormalSquare);
    }

    #endregion

    #region LoadFonts
    private void LoadFonts()
    {
        //Read fonts from FS
        var fntHelveticaBold = File.ReadAllBytes(Constants.HelveticaBold);
        var fntHelveticaPlain = File.ReadAllBytes(Constants.HelveticaPlain);

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