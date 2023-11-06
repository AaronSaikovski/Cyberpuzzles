using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra;
using Myra.Graphics2D.UI;

namespace CyberPuzzles.Crossword.App;

public sealed partial class Crossword
{
    #region monogame_methods

    protected override void Initialize()
    {
        //Panel for UI
        _MainPanel = new Panel();

        //set the Window title
        this.Window.Title = "CyberPuzzles Crossword";
        
        //Init the puzzle data
        InitPuzzleData();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        MyraEnvironment.Game = this;

        blackTexture = new Texture2D(GraphicsDevice, 1, 1);
        blackTexture.SetData(new[] { Color.Black });

        //Initialise everything
        MainInit();

        // add panel to desktop
        _desktop = new Desktop();
        _desktop.Root = _MainPanel;
    }

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