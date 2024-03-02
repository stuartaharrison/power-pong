using Microsoft.Xna.Framework;

namespace MyFirstGame.Models; 

public sealed class GameState : IGameState {
    
    public GameTime GameTime { get; init; }
    
    public IBall Ball { get; init; }
    
    public IPaddle LeftPaddle { get; init; }
    
    public IPaddle RightPaddle { get; init; }

    public GameState(GameTime gt, IBall ball, IPaddle left, IPaddle right) {
        GameTime = gt;
        Ball = ball;
        LeftPaddle = left;
        RightPaddle = right;
    }
}