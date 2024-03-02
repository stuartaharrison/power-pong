using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyFirstGame.Models; 

public interface IGameObject {
    Rectangle Position { get; }
    Texture2D Texture { get; }
    void Draw();
    void Update(IGameState state);
}