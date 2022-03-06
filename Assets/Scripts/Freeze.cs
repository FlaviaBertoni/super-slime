using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : MonoBehaviour
{
    [SerializeField]
    public float freezingTime;
    [SerializeField]
    public float freezingSpeed;

    private Player player;
    private bool freezing;
    private float timePassed = 0;


    private void Start()
    {
        this.player = GameObject.FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (this.freezing) this.timePassed += Time.deltaTime;

        if (this.timePassed >= this.freezingTime)
        {
            this.freezing = false;
            this.timePassed = 0;
            this.player.ResetMoveSpeed();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == this.player.gameObject)
        {
            this.freezing = true;
            this.player.ChangeMoveSpeed(this.freezingSpeed);
        }

    }
}
