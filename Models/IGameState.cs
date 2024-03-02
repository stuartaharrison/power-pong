using Microsoft.Xna.Framework;

namespace MyFirstGame.Models; 

public interface IGameState {
    GameTime GameTime { get; }
    IBall Ball { get; }
    IPaddle LeftPaddle { get; }
    IPaddle RightPaddle { get; }
}