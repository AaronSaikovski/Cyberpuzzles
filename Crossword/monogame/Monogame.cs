using System;
using Crossword.Shared.Constants;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Myra;
using Myra.Graphics2D.UI;



namespace Crossword.App;

public sealed partial class CrosswordMain
{
    #region Initialize
    /// <summary>
    /// Initialize
    /// </summary>
    protected override void Initialize()
    {
        try
        {
            logger.LogInformation("Start Initialize()");
            
            //Panel for UI
            _mainPanel = new Panel();

            //set the Window title
            Window.Title = GameConstants.GameTitle;

            //Init the puzzle data
            InitPuzzleData();

            base.Initialize();

        }
        catch (Exception ex)
        {
            logger.LogError(ex,ex.Message);
            throw;
        }
        
    }
    #endregion

    #region LoadContent
    /// <summary>
    /// LoadContent
    /// </summary>
    protected override void LoadContent()
    {
        try
        {
            logger.LogInformation("Start LoadContent()");
            
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
        catch (Exception ex)
        {
            logger.LogError(ex,ex.Message);
            throw;
        }
    }
    #endregion

    #region Update
    /// <summary>
    /// Update
    /// </summary>
    /// <param name="gameTime"></param>
    protected override void Update(GameTime gameTime)
    {
        try
        {
            logger.LogInformation("Start Update()");
            
            //get mouse state
            var mouseState = Mouse.GetState();
            
            // Game Logic lives here
            _keyboardInput.Poll(Keyboard.GetState());
            _mouseInput.Poll(Mouse.GetState());

            //update button mouse states
            _HintButton.Update(mouseState);
            _NextPuzzButton.Update(mouseState);
                
            //update game logic
            UpdateCrosswordScore();
            DrawCrosswordScore(_mainPanel, _currentScoreLabel, _maxScoreLabel);

            //draw the credits
            DrawCreditsLabel(_mainPanel, _creditsLabel);
            
            base.Update(gameTime);
        
        }
        catch (Exception ex)
        {
            logger.LogError(ex,ex.Message);
            throw;
        }
    }
    #endregion

    #region Draw
    /// <summary>
    /// Draw
    /// </summary>
    /// <param name="gameTime"></param>
    protected override void Draw(GameTime gameTime)
    {
        try
        {
            logger.LogInformation("Start Draw()");
            
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
        catch (Exception ex)
        {
            logger.LogError(ex,ex.Message);
            throw;
        }
    }

    #endregion
}