using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float startLimitX;
    public float endLimitX;
    public float topLimitY;
    public float bottomLimiY;

    private float fixedZ;


    void Start()
    {
        fixedZ = transform.position.z;
    }

    void LateUpdate()
    {
        float x = player.transform.position.x;
        float y = player.transform.position.y;

        if (x >= endLimitX) x = endLimitX;
        if (x < startLimitX) x = startLimitX;

        if (y >= topLimitY) y = topLimitY;
        if (y < bottomLimiY) y = bottomLimiY;

        transform.position = new Vector3(x, y, fixedZ);
    }
}
