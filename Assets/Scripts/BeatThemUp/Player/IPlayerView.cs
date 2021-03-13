public interface IPlayerView
{
    float GetDeltaTime();
    void Move(float x, float y);
    void FlipImage(bool flip);
}