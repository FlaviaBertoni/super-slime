using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float fallForce;
    [SerializeField]
    private float moveSpeedDefault;
    [SerializeField]
    private float coyoteTime = 0.2f;
    [SerializeField]
    private float jumpBufferTime = 0.2f;
    [SerializeField]
    private AudioSource jumpAudio;
    [SerializeField]
    private AudioSource deathAudio;
    [SerializeField]
    private AnimationClip deathAnimation;

    private float coyoteTimeCounter;
    private float jumpBufferTimeCounter;
    private Rigidbody2D physic;
    private Vector3 startPosition;
    private bool hasJump;
    private bool hasForceFall;
    private float moveSpeed;
    private Animator animator;
    SpriteRenderer spriteRenderer;
    private bool stop;


    private void Awake()
    {
        this.physic = this.GetComponent<Rigidbody2D>();
        this.startPosition = this.transform.position;
        this.animator = this.GetComponent<Animator>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        this.moveSpeed = this.moveSpeedDefault;
    }

    private void Update()
    {

        if (stop) return;

        bool isJumpKeyDown = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);

        if (isJumpKeyDown)
        {
            this.jumpBufferTimeCounter = this.jumpBufferTime;
        }
        else
        {
            this.jumpBufferTimeCounter -= Time.deltaTime;
        }


        if (this.physic.velocity.y == 0)
        {
            this.coyoteTimeCounter = coyoteTime;


            if (this.hasJump == false && this.animator.GetBool("IsJumping") == true)
            {
                this.animator.SetBool("IsJumping", false);
            }
        }
        else
        {
            this.coyoteTimeCounter -= Time.deltaTime;
        }


        if (this.jumpBufferTimeCounter > 0f && this.coyoteTimeCounter > 0f)
        {
            this.animator.SetBool("IsJumping", true);
            this.hasJump = true;

            this.coyoteTimeCounter = 0f;
            this.jumpBufferTimeCounter = 0f;
        }

        bool isBottomKeyDown = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
        if (isBottomKeyDown)
        {
            this.hasForceFall = true;
        }

        this.Move();

    }

    private void FixedUpdate()
    {
        if (this.hasJump)
        {
            this.Jump();
        }

        if (this.hasForceFall)
        {
            this.Fall();
        }
    }

    public void Restart()
    {
        this.transform.position = this.startPosition;
        this.physic.simulated = true;
        this.stop = false;
        this.animator.SetBool("IsDying", false);
        this.ResetMoveSpeed();
    }

    public void ChangeMoveSpeed(float speed)
    {
        this.moveSpeed = speed;
    }

    public void ResetMoveSpeed()
    {
        this.moveSpeed = this.moveSpeedDefault;
    }

    public float Die()
    {
        this.stop = true;
        this.physic.simulated = false;

        this.animator.SetBool("IsDying", true);
        this.deathAudio.Play();

        return this.deathAnimation.length;
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        float x = horizontalInput * Time.deltaTime * this.moveSpeed;
        transform.Translate(x, 0, 0);

        this.animator.SetFloat("Speed", Mathf.Abs(x));

        this.spriteRenderer.flipX = x < 0;
    }

    private void Jump()
    {
        this.hasJump = false;
        if (!this.jumpAudio.isPlaying) this.jumpAudio.Play();

        this.physic.velocity = Vector2.zero;
        this.physic.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Fall()
    {
        this.hasForceFall = false;
        this.physic.AddForce(Vector2.down * fallForce, ForceMode2D.Impulse);
    }
}


