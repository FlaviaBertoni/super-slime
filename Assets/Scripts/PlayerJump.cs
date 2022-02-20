using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public Rigidbody2D rb;
    public int jumpsLimit = 1;

    bool jumpCancelled = false;
    int jumpCounter = 0;


    void Update()
    {
        bool isJumpKeyDown = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        bool isBottomKeyDown = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);

        if (isBottomKeyDown) { this.fall(1000f); }

        if (isJumpKeyDown && jumpCounter > jumpsLimit) { jumpCancelled = true; }

        if (jumpCancelled && rb.velocity.y == 0)
        {
            jumpCounter = 0;
            jumpCancelled = false;
        }

        if (isJumpKeyDown && jumpCounter <= jumpsLimit)
        {
            rb.AddForce(transform.up * 20f, ForceMode2D.Impulse);
            jumpCounter++;
        }
    }

    private void FixedUpdate()
    {
        if (jumpCancelled && rb.velocity.y > 0)
        {
            fall(100f);
        }
    }

    void fall(float force)
    {
        rb.AddForce(Vector2.down * force);
    }
}
