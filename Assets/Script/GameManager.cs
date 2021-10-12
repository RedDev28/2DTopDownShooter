using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private Player playerScript;
    private Timer timerScript;
    private ButtonManagerr buttonManager;
    private Data data;

    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.Find("Data Container").GetComponent<Data>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        data.player = GameObject.Find("Player");
        timerScript = GameObject.Find("Timer").GetComponent<Timer>();
        buttonManager = GameObject.Find("Button Manager").GetComponent<ButtonManagerr>();
    }

    // Update is called once per frame
    void Update()
    {
        data.scoreText.text = data.score.ToString();
        data.seconds = Mathf.FloorToInt(data.clearPowerUpTime % 60);
        data.powerUpTimerText.text = data.seconds.ToString();
        if (data.clearPowerUpTime >= 0)
        {
            data.clearPowerUpTime -= Time.deltaTime;
        }

        else
        {
            data.clearPowerUpTime = 20;

            if (playerScript.speed != 5)
            {
                playerScript.speed = 5f;
            }
        }

        if (data.speedPowerUpNum < 1)
        {
            InvokeRepeating("SpawnBattery", data.powerUpSpawnRate, data.powerUpSpawnRate);
            data.speedPowerUpNum++;
        }

        if (data.isDead || data.isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        data.healthText.text = data.health.ToString();

        data.index = Random.Range(0, data.spawnPoints.Length);
        if (data.isPaused == false)
        {
            SpawnEnemy();
        }

        if (data.health == 0)
        {
            buttonManager.GameOver();
        }

        data.PowerUpPos = new Vector2(Random.Range(-7, 7), Random.Range(-4, 4));

        if (data.hasObjective == false)
        {
            SpawnObjectives();
        }
    }

    private void SpawnBattery()
    {
        Instantiate(data.speedPower, data.PowerUpPos, Quaternion.identity);
    }

    private void SpawnObjectives()
    {
        Instantiate(data.objectives, data.PowerUpPos, Quaternion.identity);
        data.hasObjective = true;
    }

    private void SpawnEnemy()
    {
        if (data.timer <= 0)
        {
            Instantiate(data.enemy, data.spawnPoints[data.index].transform.position, Quaternion.identity);
            data.timer = 2f;
        }

        else
        {
            data.timer -= Time.deltaTime;
        }
    }
}
