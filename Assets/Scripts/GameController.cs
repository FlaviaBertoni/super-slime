using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private Timer timer;
    private Player player;
    private EndInterface endInterface;
    private GameOverInterface gameOverInterface;
    private WinInterface winInterface;

    private void Start()
    {
        this.timer = GameObject.FindObjectOfType<Timer>();
        this.player = GameObject.FindObjectOfType<Player>();
        this.endInterface = GameObject.FindObjectOfType<EndInterface>();
        this.gameOverInterface = GameObject.FindObjectOfType<GameOverInterface>();
        this.winInterface = GameObject.FindObjectOfType<WinInterface>();
    }

    public void Finish()
    {
        Time.timeScale = 0;
        this.endInterface.show();
    }

    public void GameOver()
    {
        StartCoroutine(GameOverCoroutine());
    }

    public void Restart()
    {
        this.endInterface.hide();
        this.gameOverInterface.hide();
        this.winInterface.hide();

        Time.timeScale = 1;

        this.player.Restart();
        this.timer.Restart();
    }

    public void Win()
    {
        Time.timeScale = 0;
        this.winInterface.show();
    }

    IEnumerator GameOverCoroutine()
    {
       float length = player.Die();

        yield return new WaitForSeconds(length);

        this.gameOverInterface.show();
        Time.timeScale = 0;
    }
}
