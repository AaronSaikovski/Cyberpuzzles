using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra;
using Myra.Graphics2D.UI;

namespace CyberPuzzles.Crossword.App;

public sealed partial class CrosswordApp
{
    #region Initialize
    protected override void Initialize()
    {
        //Panel for UI
        _mainPanel = new Panel();

        //set the Window title
        Window.Title = "CyberPuzzles CrosswordApp";

        //Init the puzzle data
        InitPuzzleData();

        base.Initialize();
    }
    #endregion

    #region LoadContent
    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        MyraEnvironment.Game = this;

        _blackTexture = new Texture2D(GraphicsDevice, 1, 1);
        _blackTexture.SetData(new[] { Color.Black });

        //Initialise everything
        MainInit();

        // add panel to desktop
        _desktop = new Desktop
        {
            Root = _mainPanel
        };
    }
    #endregion

    #region Update
    protected override void Update(GameTime gameTime)
    {
        // Game Logic lives here
        _keyboardInput.Poll(Microsoft.Xna.Framework.Input.Keyboard.GetState());
        _mouseInput.Poll(Microsoft.Xna.Framework.Input.Mouse.GetState());

        //update game logic
        UpdateCrosswordScore();
        DrawCrosswordScore();

        base.Update(gameTime);
    }
    #endregion

    #region Draw
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);

        //If buffer dirty...draw the crossword
        if (bBufferDirty)
        {
            DrawCrossword();
        }


        // End drawing        
        _desktop.Render();
        base.Draw(gameTime);
    }

    #endregion
}