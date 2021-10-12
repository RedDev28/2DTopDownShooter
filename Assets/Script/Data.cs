using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Data : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI powerUpTimerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endScore;
    public TextMeshProUGUI endTime;
    public TextMeshProUGUI titleText;
    public Button startButton;

    public GameObject player;
    public GameObject pausePanel;
    public GameObject objectives;
    public GameObject GameOverMenu;
    public GameObject speedPower;
    public GameObject enemy;
    public GameObject[] spawnPoints;


    public Vector2 PowerUpPos;
    public int speedPowerUpLimit = 5;
    public int speedPowerUpNum;
    public int score;
    public int index;
    public float timer = 1000f;
    public float health = 5;
    public float speedLimit = 1f;
    public float powerUpSpawnRate;
    public float PowerUpTime = 5f;
    public float clearPowerUpTime = 20;
    public float seconds;
    public float xBoundary = 7.5f;
    public float yBoundary = 4.6f;
    public bool isPaused = false;
    public bool hasObjective = false;
    public bool isDead = false;
}
