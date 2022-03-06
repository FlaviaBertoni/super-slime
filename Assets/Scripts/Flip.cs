using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    [SerializeField]
    private GameObject platform;
    [SerializeField]
    private float toRotationZ;
    [SerializeField]
    private float smooth;

    private Quaternion to;
    private Quaternion from;
    private Player player;
    private bool flipping;
    private float flipTimeCount;


    private void Start()
    {
        this.player = GameObject.FindObjectOfType<Player>();
        this.from = platform.transform.rotation;
        this.to = Quaternion.Euler(from.x, from.y, toRotationZ);
    }

    private void Update()
    {
        if (this.flipping)
        {
            platform.transform.rotation = Quaternion.Slerp(from, to, flipTimeCount);
            this.flipTimeCount = this.flipTimeCount + Time.deltaTime * smooth;
        }


        if (platform.transform.rotation.z == -to.z)
        {
            this.flipping = false;
            this.flipTimeCount = 0;
            platform.transform.rotation = Quaternion.Euler(from.x, from.y, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == this.player.gameObject)
        {
            this.flipping = true;
        }

    }
}
