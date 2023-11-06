using System.IO;
using CyberPuzzles.Crossword.Constants;
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
        fntnumFont = fntHelveticaBoldSystem.GetFont(CWSettings.FNT_SML);

        //Char entered by user.    
        fntFont = fntHelveticaBoldSystem.GetFont(CWSettings.FNT_LGE);

        //Crossword score      
        fntScore = fntHelveticaBoldSystem.GetFont(CWSettings.FNT_LGE);

        //Across/Down listbox Headers
        fntListhead = fntHelveticaBoldSystem.GetFont(CWSettings.FNT_MED);

        //List font
        fntListFont = fntHelveticaSystem.GetFont(CWSettings.FNT_MED);
    }
    #endregion
}