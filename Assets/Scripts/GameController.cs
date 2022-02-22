using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private Timer timer;
    private Player player;
    private EndInterface endInterface;

    private void Start()
    {
        this.timer = GameObject.FindObjectOfType<Timer>();
        this.player = GameObject.FindObjectOfType<Player>();
        this.endInterface = GameObject.FindObjectOfType<EndInterface>();
    }

    public void Finish()
    {
        Debug.Log("Finish");
        Time.timeScale = 0;
        this.endInterface.show();
    }

    public void Restart()
    {
        this.endInterface.hide();
        Debug.Log("Restart");

        Time.timeScale = 1;

        this.player.Restart();
        this.timer.Restart();
    }
}
