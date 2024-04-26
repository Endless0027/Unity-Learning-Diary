using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private float dirx = 0f;
    private int jumpCount = 0; // 当前连跳次数
    private int maxJumpCount = 2; // 最大连跳次数....有问题..
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;
   

    private enum MovementState { idle,running,jumping,falling}
    [SerializeField] private AudioSource jumpSoundEffect;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll=GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dirx = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirx * moveSpeed, rb.velocity.y); // 设置水平方向速度

    }

    private void Update()
    {
        if (Input.GetKeyDown("w") && (IsGrounded() || jumpCount < maxJumpCount))
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
            if (jumpCount >= maxJumpCount)
            {
                jumpCount = 0; // 重置连跳次数
            }
        }
        UpdateAnimationState();
    }
//开始连接动画咯...
    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirx > 0f)
        {
            state=MovementState.running;
            sprite.flipX = false;
        }
        else if (dirx < 0f)
        {
            state =MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        if(rb.velocity.y>0.01f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y<-0.01f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state",(int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
