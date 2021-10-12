using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ButtonManagerr : MonoBehaviour
{
    private Timer timerScript;
    private Data data;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            timerScript = GameObject.Find("Timer").GetComponent<Timer>();
        }

        data = GameObject.Find("Data Container").GetComponent<Data>();
    }

    public void PauseGame()
    {
        data.pausePanel.SetActive(true);
        data.isPaused = true;
    }

    public void ResumeGame()
    {
        data.pausePanel.SetActive(false);
        data.isPaused = false;
    }

    public void StartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void GameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOver()
    {
        data.GameOverMenu.SetActive(true);
        data.isDead = true;
        data.endScore.text = "SCORE:" + data.score.ToString();
        if (timerScript.seconds < 10)
        {
            data.endTime.text = "TIME:" + timerScript.minutes + ":" + "0" + timerScript.seconds;
        }

        else
        {
            data.endTime.text = "TIME:" + timerScript.minutes + ":" + timerScript.seconds;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        data.isDead = false;
    }
}
