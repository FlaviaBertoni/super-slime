using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float startLimit = -8.75f;
    public float endLimit = 60f;
    private float fixedX;
    private float fixedY;
    private float fixedZ = -10f;


    void Start()
    {
        fixedX = transform.position.x;
        fixedY = transform.position.y;
        fixedZ = transform.position.z;
    }

    void LateUpdate()
    {
        float x = player.transform.position.x + fixedX;
        float y = (player.transform.position.y * 0.2f) + fixedY;

        if (x >= endLimit) x = endLimit;
        if (x < startLimit) x = startLimit;

        transform.position = new Vector3(x, y, fixedZ);
    }
}
