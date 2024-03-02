using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyFirstGame.Models;

// TODO: we might want to randomly position the ball

public sealed class Ball : IBall {
    
    public float BaseSpeed { get; set; }
    
    public float IncrementSpeed { get; set; } = 10f;
    
    public Rectangle Position { get; private set; }

    public int Right { get; private set; } = -1;
    
    public float Speed { get; private set; } = 150f;

    public Texture2D Texture { get; private set; }

    public int Top { get; private set; } = 1;
    
    public void Draw() {
        Globals.SpriteBatch.Draw(Texture, Position, Color.White);
    }

    public void Reset() {
        // this will reset the speed to the base (because we increment on each "hit")
        Speed = BaseSpeed;
        
        // randomly change the ball direction
        Right = Globals.Random.Next(0, 2) == 1 ? 1 : -1;
        Top = Globals.Random.Next(0, 2) == 1 ? -1 : 1;
        
        // update the position back to center
        // this might be "tweaked" so we can random the position
        Position = new Rectangle(Globals.Width / 2 - 10, Globals.Height / 2 - 10, 20, 20);
    }
    
    public void Update(IGameState state) {
        var ds = (int)(Speed * (float) state.GameTime.ElapsedGameTime.TotalSeconds);
        var x = Position.X + (Right * ds);
        var y = Position.Y + (Top * ds);

        // check if we need to "bounce' the ball before it goes off screen
        // we also need to "bounce" the ball off the paddles with a bit of collision!
        
        // checks to see if the ball has "HIT" the left side player paddle
        if (state.LeftPaddle.Position.Right > Position.Left 
            && Position.Top > state.LeftPaddle.Position.Top 
            && Position.Bottom < state.LeftPaddle.Position.Bottom
        ) {
            Right = 1;
            Speed += IncrementSpeed;
        }
        
        // checks to see if the ball has "HIT" the right side player paddle
        if (state.RightPaddle.Position.Left < Position.Right 
            && Position.Top > state.RightPaddle.Position.Top 
            && Position.Bottom < state.RightPaddle.Position.Bottom
        ) {
            Right = -1;
            Speed += IncrementSpeed;
        }

        // check if the ball has touched the top of the screen, then change the direction to go "DOWN" the way
        if (Position.Y < 0) {
            Top = 1;
        }

        // check if the ball has touched the bottom, change direction to go "UP" the way
        if (Position.Y > Globals.Height - Position.Height) {
            Top = -1;
        }
        
        // set the balls new position
        Position = new Rectangle(x, y, Position.Width, Position.Height);
        
        // Once we have a new position, we want to check if we are within "scoring" parameters
        // check if the ball has gone past the left paddles boundaries
        if (Position.X < 0 ) {
            Reset();
        }
        
        // check if the ball has gone past the right paddles boundaries
        if (Position.X > Globals.Width - Position.Width) {
            Reset();
        }
    }

    public Ball(Texture2D texture, float baseSpeed = 150f) {
        BaseSpeed = baseSpeed;
        Texture = texture;
        Texture.SetData<Color>(new Color[] { Color.White });
        Reset();
    }
}