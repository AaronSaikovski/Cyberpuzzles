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
    public event EventHandler Click; 

    //Image for button
    public Texture2D Texture { get; set; }
        
    // Vector fo x,y coords
    public Vector2 Position { get; set; }
        
    // Rect bounds
    public Rectangle Bounds => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
    
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
    }
    #endregion

    #region Event_Handlers
    /// <summary>
    /// IsMouseOver
    /// </summary>
    /// <param name="mouseState"></param>
    /// <returns></returns>
    public bool IsMouseOver(MouseState mouseState)
    {
        Rectangle mouseRectangle = new Rectangle(mouseState.X, mouseState.Y, 1, 1);
        return mouseRectangle.Intersects(Bounds);
    }

    /// <summary>
    /// IsClicked
    /// </summary>
    /// <param name="mouseState"></param>
    /// <returns></returns>
    public bool IsClicked(MouseState mouseState)
    {
        Rectangle mouseRectangle = new Rectangle(mouseState.X, mouseState.Y, 1, 1);
        return mouseRectangle.Intersects(Bounds) && mouseState.LeftButton == ButtonState.Pressed;
    }
    #endregion

    #region Graphics_Handlers
    /// <summary>
    /// Draw
    /// </summary>
    /// <param name="spriteBatch"></param>
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(Texture, Position, Color.White);
        spriteBatch.End();
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