namespace MyFirstGame.Models; 

public interface IBall : IGameObject {
    float BaseSpeed { get; }
    float IncrementSpeed { get; }
    int Right { get; }
    float Speed { get; }
    int Top { get; }
    void Reset();
}