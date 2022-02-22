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
    private float moveSpeed;

    private GameController gameController;
    private Rigidbody2D fisics;
    private Vector3 startPosition;
    private bool hasJump;
    private bool hasBufferJump;
    private bool hasForceFall;

    private void Awake()
    {
        this.fisics = this.GetComponent<Rigidbody2D>();
        this.startPosition = this.transform.position;
    }

    private void Start()
    {
        this.gameController = GameObject.FindObjectOfType<GameController>();
    }

    private void Update()
    {
        bool isJumpKeyDown = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        if (isJumpKeyDown) this.hasBufferJump = true;
        if (this.hasBufferJump && this.fisics.velocity.y == 0)
        {
            this.hasJump = true;
            this.hasBufferJump = false;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //this.fisic.simulated = false;
        //Restart game

        
    }

    public void Restart()
    {
        this.transform.position = this.startPosition;
        this.fisics.simulated = true;
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        float x = horizontalInput * Time.deltaTime * moveSpeed;
        transform.Translate(x, 0, 0);
    }

    private void Jump()
    {
        this.hasJump = false;

        this.fisics.velocity = Vector2.zero;
        this.fisics.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Fall()
    {
        this.hasForceFall = false;
        this.fisics.AddForce(Vector2.down * fallForce, ForceMode2D.Impulse);
    }
}


