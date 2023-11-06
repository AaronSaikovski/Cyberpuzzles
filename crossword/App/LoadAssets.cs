using System.IO;
using FontStashSharp;
using Microsoft.Xna.Framework.Graphics;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region Load_Assets

    private void LoadImages()
    {
        imgHighliteSquare = Content.Load<Texture2D>("images/sqlite");
        imgSquareWord = Content.Load<Texture2D>("images/wordlite");
        imgNormalSquare = Content.Load<Texture2D>("images/normsq");
    }

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
        fntnumFont = fntHelveticaBoldSystem.GetFont(8);

        //Char entered by user.    
        fntFont = fntHelveticaBoldSystem.GetFont(16);

        //Crossword score      
        fntScore = fntHelveticaBoldSystem.GetFont(16);

        //Across/Down listbox Headers
        fntListhead = fntHelveticaBoldSystem.GetFont(14);

        //List font
        fntListFont = fntHelveticaSystem.GetFont(16);
    }
    #endregion
}