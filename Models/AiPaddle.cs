using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyFirstGame.Models; 

public class AiPaddle : Paddle {

    public int YDirection { get; private set; } = -1;
    
    public override void Update(IGameState state) {
        var ballPos = state.Ball.Position;
        
        var ballYCenterPoint = ballPos.Y + (ballPos.Height / 2);
        var paddleYCenterPoint = 
        
        var posDifference = Position.Y - ballPos.Y;
        var midYPoint = Globals.Height / 2;
        
        Position = new Rectangle(
            Position.X,
            ballPos.Y,
            Position.Width,
            Position.Height
        );

        // var ds = (int) (Speed * (float) state.GameTime.ElapsedGameTime.TotalSeconds);
        // Position = new Rectangle(
        //     Position.X,
        //     Position.Y + (YDirection * ds),
        //     Position.Width,
        //     Position.Height
        // );
        //
        // // check when we hit the top, change the YDirection to back down
        // if (Position.Y <= 0) {
        //     YDirection = 1;
        // }
        //
        // // check if we have hit the bottom, change the YDirection to come back up!
        // if (Position.Y >= Globals.Height - Position.Height) {
        //     YDirection = -1;
        // }
    }

    public AiPaddle(Texture2D texture, Rectangle position) : base(texture, position) {
        Speed = 250f;
    }
}