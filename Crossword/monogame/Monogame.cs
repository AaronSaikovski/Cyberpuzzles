using System;
using Crossword.Shared.Constants;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Myra;
using Myra.Graphics2D.UI;


using Crossword.UI.Label;
using Crossword.UI.Score;

namespace Crossword.App;

public sealed partial class CrosswordApp
{
    #region Initialize
    /// <summary>
    /// Initialize
    /// </summary>
    protected override void Initialize()
    {
        try
        {
            _logger.LogInformation("Start Initialize()");

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
            _logger.LogError(ex, ex.Message);
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
            _logger.LogInformation("Start LoadContent()");

            _spriteBatch = new SpriteBatch(GraphicsDevice);
            MyraEnvironment.Game = this;

            _blackTexture = new Texture2D(GraphicsDevice, 1, 1);
            _blackTexture.SetData([Color.Black]);

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
            _logger.LogError(ex, ex.Message);
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
            // Removed excessive logging in hot path (runs 30-60 times per second)

            //get mouse state
            var mouseState = Mouse.GetState();

            // Game Logic lives here
            _keyboardInput!.Poll(Keyboard.GetState());
            _mouseInput!.Poll(Mouse.GetState());

            //update button mouse states
            _HintButton!.Update(mouseState);
            _NextPuzzButton!.Update(mouseState);

            //update game logic
            UpdateCrosswordScore();
            CrosswordScore.DrawCrosswordScore(_mainPanel!, _currentScoreLabel!, _maxScoreLabel!, IsFinished, _crosswordScore,
                _numQuestions, _fntScore!, rectCrossWord.Bottom);

            //draw the credits
            CrosswordLabel.DrawCreditsLabel(_mainPanel!, _creditsLabel!, rectCrossWord.Left, rectCrossWord.Bottom, _fntCredits!);

            base.Update(gameTime);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
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
            // Removed excessive logging in hot path (runs 30-60 times per second)

            GraphicsDevice.Clear(Color.White);

            //If buffer dirty...draw the crossword
            if (_bBufferDirty)
            {
                DrawCrossword();
            }

            //Draw the buttons
            _HintButton?.Draw(_spriteBatch!);
            _NextPuzzButton?.Draw(_spriteBatch!);



            // End drawing        
            _desktop!.Render();
            base.Draw(gameTime);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            throw;
        }
    }

    #endregion
}