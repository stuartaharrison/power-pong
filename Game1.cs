using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MyFirstGame.Models;

namespace MyFirstGame;

public class Game1 : Game {
    
    private GraphicsDeviceManager _graphics;
    private IBall _ball;
    private IPaddle _player1;
    private IPaddle _computer;
    
    public Game1() {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferWidth = Globals.Width;
        _graphics.PreferredBackBufferHeight = Globals.Height;
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize() {
        Window.Title = "Power Pong";
        base.Initialize();
    }

    protected override void LoadContent() {
        Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);
        
        // configure the player paddle
        _player1 = new Paddle(
            new Texture2D(GraphicsDevice, 1, 1),
            new Rectangle(10, 140, 20, 150)
        );
        
        // configure the paddle for the AI/Computer Player
        _computer = new AiPaddle(
            new Texture2D(GraphicsDevice, 1, 1),
            new Rectangle(Globals.Width - 30, 140, 20, 150)
        );
        
        // setup the ball object
        _ball = new Ball(new Texture2D(GraphicsDevice, 1, 1));
    }

    protected override void Update(GameTime gameTime) {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        var currentGameState = new GameState(gameTime, _ball, _player1, _computer);
        _player1.Update(currentGameState);
        _computer.Update(currentGameState);
        _ball.Update(currentGameState);
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime) {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        Globals.SpriteBatch.Begin();
        
        _player1.Draw();
        _computer.Draw();
        _ball.Draw();
        
        Globals.SpriteBatch.End();
        base.Draw(gameTime);
    }
}
