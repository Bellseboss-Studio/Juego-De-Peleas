public interface IPlayerView
{
    float GetDeltaTime();
    void Move(float x, float y);
    void FlipImage(bool flip);
    void AnimationSpeed(float x, float y);
    void PunchingAnimator();
}