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
        public event EventHandler Click; // Event handler for button click

        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        
        //public SpriteBatch spBatch { get; set; }
        public Rectangle Bounds => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

        public PuzzleButton(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }
        
        public bool IsMouseOver(MouseState mouseState)
        {
            Rectangle mouseRectangle = new Rectangle(mouseState.X, mouseState.Y, 1, 1);
            return mouseRectangle.Intersects(Bounds);
        }

        public bool IsClicked(MouseState mouseState)
        {
            Rectangle mouseRectangle = new Rectangle(mouseState.X, mouseState.Y, 1, 1);
            return mouseRectangle.Intersects(Bounds) && mouseState.LeftButton == ButtonState.Pressed;
        }

      
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, Position, Color.White);
            spriteBatch.End();
        }

        
        
        public void Update(MouseState mouseState)
        {
            if (IsMouseOver(mouseState) && mouseState.LeftButton == ButtonState.Pressed)
            {
                // Trigger the click event when the button is clicked
                Click?.Invoke(this, EventArgs.Empty);
            }
        }
    

}