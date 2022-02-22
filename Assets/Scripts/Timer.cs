using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float time;
    [SerializeField]
    private Text textoTimer;

    private GameController gameController;
    private float timeRemaning;

    private Color alertColor = new Color32(222, 42, 51, 255);
    private Color primaryColor = new Color32(76, 69, 117, 255);


    private void Start()
    {
        this.gameController = GameObject.FindObjectOfType<GameController>();

        this.timeRemaning = this.time;
    }

    void Update()
    {
        if (this.timeRemaning > 0)
        {
            this.UpdateTimer();
        }
        else
        {
            this.EndTimer();
        }
        
    }

    public void Restart()
    {
        this.timeRemaning = this.time;
        this.textoTimer.color = this.primaryColor;
    }


    private void EndTimer()
    {
        this.timeRemaning = 0;

        this.textoTimer.color = this.alertColor;

        this.gameController.Finish();
    }


    private void UpdateTimer()
    {
        this.timeRemaning -= Time.deltaTime;
        this.DisplayTimer();
    }

    private void DisplayTimer()
    {
        float timeToDisplay = this.timeRemaning + 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        this.textoTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
