using UnityEngine;

public class LogicPlayerView
{
    private IPlayerView playerView;
    private float velocitySpeed;

    public LogicPlayerView(IPlayerView playerView, float velocitySpeed)
    {
        this.playerView = playerView;
        this.velocitySpeed = velocitySpeed;
    }

    public void MovePlayer(float x, float y)
    {
        x *= velocitySpeed * playerView.GetDeltaTime();
        y *= velocitySpeed * playerView.GetDeltaTime();
        if (x != 0)
        {
            if (x < 0)
            {
                playerView.FlipImage(true);
            }
            else
            {
                playerView.FlipImage(false);
            }
        }
        playerView.Move(x, y);
    }
}