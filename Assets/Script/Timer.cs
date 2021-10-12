using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float timer;
    public float seconds;
    public float minutes;
    private TextMeshProUGUI timerText;

    private Data data;

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        data = GameObject.Find("Data Container").GetComponent<Data>();
    }

    void Update()
    {
        if (data.isDead == false)
        {
            seconds = Mathf.FloorToInt(timer % 60);
            minutes = Mathf.FloorToInt(timer / 60);
            timer += Time.deltaTime;
        }

        if (seconds < 10)
        {
            timerText.text = minutes.ToString() + ":" + "0" + seconds.ToString();
        }

        else
        {
            timerText.text = minutes.ToString() + ":" + seconds.ToString();
        }
    }
}
