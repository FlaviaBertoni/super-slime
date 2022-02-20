using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Game Over!");
        //Destroy(other.gameObject);
        other.gameObject.transform.position = new Vector2(0,0);
    }
}
