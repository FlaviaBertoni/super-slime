using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : MonoBehaviour
{
    [SerializeField]
    public float timeToBurn;


    private Player player;
    private bool burning;
    private float timePassed = 0;


    private void Start()
    {
        this.player = GameObject.FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (this.burning) this.timePassed += Time.deltaTime;

        if (this.timePassed >= this.timeToBurn)
        {
            this.burning = false;
            this.timePassed = 0;
            this.player.Restart();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == this.player.gameObject)
        {
            this.burning = true;
        }
        
    }
}
