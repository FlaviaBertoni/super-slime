using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Player player;
    private GameController gameController;

    void Start()
    {
        this.gameController = GameObject.FindObjectOfType<GameController>();
        this.player = GameObject.FindObjectOfType<Player>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == this.player.gameObject)
        {
            this.gameController.GameOver();
        }
    }
}
