using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerView : MonoBehaviour, IPlayerView
{
    private Vector2 input;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private LogicPlayerView logic;
    [SerializeField] private float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        logic = new LogicPlayerView(this, speed);
    }

    private void OnMove(InputValue input)
    {
        this.input = input.Get<Vector2>();
    }

    public float GetDeltaTime()
    {
        return Time.deltaTime;
    }

    public void Move(float x, float y)
    {
        rb.velocity = new Vector2(x, y);
    }

    private void Update()
    {
        if(this.input == Vector2.zero)
        {
            this.input = Vector2.zero;
        }
        logic.MovePlayer(this.input.x, this.input.y);
    }

    public void FlipImage(bool flip)
    {
        Quaternion rotation = transform.rotation;
        if (flip)
        {
            rotation.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            rotation.eulerAngles = Vector3.zero;
        }
        transform.rotation = rotation;
    }
}
