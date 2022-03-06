using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private Player player;
    private GameController gameController;

    void Start()
    {
        this.player = GameObject.FindObjectOfType<Player>();
        this.gameController = GameObject.FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject == this.player.gameObject)
        {
            this.gameController.GameOver();
        } else
        {
            Destroy(collision.gameObject);
        }

    }
}
