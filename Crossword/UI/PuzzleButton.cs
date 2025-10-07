using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Crossword.App;

/// <summary>
/// Custom image button - thanks ChatGPT :-)
/// </summary>
public class PuzzleButton
{
    #region Fields

    // Event handler for button click
    public event EventHandler? Click;

    //Image for button
    private Texture2D Texture { get; set; }

    // Vector fo x,y coords
    private Vector2 Position { get; set; }

    // Cached bounds rectangle
    private Rectangle _bounds;
    public Rectangle Bounds => _bounds;


    #endregion

    #region Constructor
    /// <summary>
    /// PuzzleButton
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="position"></param>
    public PuzzleButton(Texture2D texture, Vector2 position)
    {
        Texture = texture;
        Position = position;
        UpdateBounds();
    }
    #endregion

    #region Event_Handlers

    /// <summary>
    /// Update bounds when position changes
    /// </summary>
    private void UpdateBounds()
    {
        _bounds = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
    }

    /// <summary>
    /// IsMouseOver - optimized to use point containment instead of Rectangle intersection
    /// </summary>
    /// <param name="mouseState"></param>
    /// <returns></returns>
    private bool IsMouseOver(MouseState mouseState)
    {
        return _bounds.Contains(mouseState.X, mouseState.Y);
    }


    #endregion

    #region Graphics_Handlers
    /// <summary>
    /// Draw - Caller is responsible for SpriteBatch Begin/End to enable batching
    /// </summary>
    /// <param name="spriteBatch"></param>
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, Position, Color.White);
    }

    /// <summary>
    /// Update
    /// </summary>
    /// <param name="mouseState"></param>
    public void Update(MouseState mouseState)
    {
        if (IsMouseOver(mouseState) && mouseState.LeftButton == ButtonState.Pressed)
        {
            // Trigger the click event when the button is clicked
            Click?.Invoke(this, EventArgs.Empty);
        }
    }
    #endregion
}