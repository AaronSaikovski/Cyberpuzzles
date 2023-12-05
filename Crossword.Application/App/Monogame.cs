using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Myra;
using Myra.Graphics2D.UI;

namespace Crossword.App;

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
        //get mouse state
        MouseState mouseState = Mouse.GetState();
        
        // Game Logic lives here
        _keyboardInput.Poll(Microsoft.Xna.Framework.Input.Keyboard.GetState());
        _mouseInput.Poll(Microsoft.Xna.Framework.Input.Mouse.GetState());

        //update button mouse states
        _HintButton.Update(mouseState);
        _NextPuzzButton.Update(mouseState);
            
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

        //Draw the buttons
        _HintButton.Draw(_spriteBatch);
        _NextPuzzButton.Draw(_spriteBatch);

        // End drawing        
        _desktop.Render();
        base.Draw(gameTime);
    }

    #endregion
}