using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyFirstGame.Models;

// TODO: add property to paddle object that controls the size? Then we can add power-ups, etc?

public class Paddle : IPaddle {
    
    public Rectangle Position { get; protected set; }

    public float Speed { get; protected set; } = 500f;

    public Texture2D Texture { get; protected set; }
    
    public virtual void Draw() {
        Globals.SpriteBatch.Draw(Texture, Position, Color.White);
    }

    public virtual void Update(IGameState state) {
        var kbs = Keyboard.GetState();
        var y = Position.Y;
        var ds = (int) (Speed * (float) state.GameTime.ElapsedGameTime.TotalSeconds);
        
        if (kbs.IsKeyDown(Keys.Up) && Position.Y > 0) {
            y = Position.Y - ds;
        }

        if (kbs.IsKeyDown(Keys.Down) && Position.Y < Globals.Height - Position.Height) {
            y = Position.Y + ds;
        }
        
        Position = new Rectangle(Position.X, y, Position.Width, Position.Height);
    } 
    
    public Paddle(Texture2D texture, Rectangle position) {
        Texture = texture;
        Texture.SetData<Color>(new Color[] { Color.White });
        Position = position;
    }
}