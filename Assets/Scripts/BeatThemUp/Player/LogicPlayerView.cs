using UnityEngine;

public class LogicPlayerView
{
    private IPlayerView playerView;
    private float velocitySpeed;
    private bool _isPunching;

    public LogicPlayerView(IPlayerView playerView, float velocitySpeed)
    {
        this.playerView = playerView;
        this.velocitySpeed = velocitySpeed;
        _isPunching = false;
    }

    public void MovePlayer(float x, float y)
    {
        if (_isPunching)
        {
            playerView.Move(0, 0);
            return;
        }
        playerView.AnimationSpeed(x, y);
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

    public void Punching()
    {
        _isPunching = true;
        playerView.PunchingAnimator();
    }

    public void EndPunching()
    {
        _isPunching = false;
    }
}