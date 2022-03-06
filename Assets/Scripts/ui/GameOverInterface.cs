using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverInterface : MonoBehaviour
{
    [SerializeField]
    private GameObject container;

    public void show()
    {
        this.container.SetActive(true);
    }

    public void hide()
    {
        this.container.SetActive(false);
    }
}
