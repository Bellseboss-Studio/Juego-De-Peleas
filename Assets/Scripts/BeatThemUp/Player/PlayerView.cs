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
    private Animator _animator;
    private static readonly int Speed = Animator.StringToHash("speed");

    private void Start()
    {
        _animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        logic = new LogicPlayerView(this, speed);
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            logic.Punching();   
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
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
        logic.MovePlayer(input.x, input.y);
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

    public void AnimationSpeed(float x, float y)
    {
        var value = Mathf.Abs(x) + Mathf.Abs(y);
        _animator.SetFloat(Speed, value);
    }

    public void PunchingAnimator()
    {
        _animator.SetTrigger("punch");
    }

    public void EndPunching()
    {
        logic.EndPunching();
    }
}
