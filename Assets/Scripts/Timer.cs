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
    [SerializeField]
    private AudioSource halfTimeAudio;
    [SerializeField]
    private AudioSource endTimeAudio;

    private GameController gameController;
    private float timeRemaning;
    private bool end;

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
        else if (!this.end)
        {
            this.EndTimer();
        }

        if (Mathf.FloorToInt(this.timeRemaning) == Mathf.FloorToInt(this.time * 0.1f))
        {
            this.textoTimer.color = Color.yellow;
            if (!this.halfTimeAudio.isPlaying) this.halfTimeAudio.Play();
        }

    }

    public void Restart()
    {
        this.end = false;
        this.timeRemaning = this.time;
        this.textoTimer.color = this.primaryColor;
        if (this.halfTimeAudio.isPlaying) this.halfTimeAudio.Stop();
        if (this.endTimeAudio.isPlaying) this.endTimeAudio.Stop();
    }


    private void EndTimer()
    {
        this.halfTimeAudio.Stop();
        this.endTimeAudio.Play();
        this.timeRemaning = 0;
        this.end = true;

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
