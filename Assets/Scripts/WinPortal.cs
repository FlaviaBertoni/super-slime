using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPortal : MonoBehaviour
{
    private GameController gameController;

    private void Start()
    {
        this.gameController = GameObject.FindObjectOfType<GameController>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.gameController.Win();
    }
}
