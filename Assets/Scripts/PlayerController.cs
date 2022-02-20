using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;


    public float speed = 10f;
    public Sprite idleSprite;
    public Sprite movingSprite;

    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        transform.position = new Vector3(0.0f, 0.75f, 0.0f);
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        float x = horizontalInput * Time.deltaTime * speed;

        transform.Translate(x, 0, 0);

        sr.flipX = false;
        if (x == 0) { sr.sprite = idleSprite; }
        if (x > 0) { sr.sprite = movingSprite; }
        if (x < 0) {
            sr.sprite = movingSprite;
            sr.flipX = true;
        }



    }
}
