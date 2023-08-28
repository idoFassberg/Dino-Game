using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float gameSpeed { get; private set; }
    public float initialGameSpeed = 5f;

    [FormerlySerializedAs("gamePoeedIncrease")]
    public float gameSpeedIncrease = 0.1f;

    public bool IsGameOver { get; private set; }
    public bool IsUserStartPlay { get; set; }

    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button quitButton;

    private int score = 1;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private Player player;
    [SerializeField] private Spawner spawner;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        NewGame();
    }

    public void NewGame()
    {
        IsGameOver = false;
        DestroyObstaclesAndInitValues();
        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }

    private void DestroyObstaclesAndInitValues()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }

        gameSpeed = initialGameSpeed;
        enabled = true;
        score = 1;
    }

    public void StartPlay()
    {
        Debug.Log($"{IsUserStartPlay} && {!IsGameOver}");
        IsGameOver = false;
        IsUserStartPlay = true;
        Debug.Log($"{IsUserStartPlay} && {!IsGameOver}");
    }

    // Update is called once per frame
    private void Update()
    {
        if (!IsGameOver)
        {
            gameSpeed += gameSpeedIncrease * Time.deltaTime;
            score++;
            scoreText.text = (score).ToString();
        }
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void GameOver()
    {
        DestroyObstaclesAndInitValues();
        gameSpeed = 0f;
        enabled = false;
        IsGameOver = true;
        spawner.gameObject.SetActive(false);
        player.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }
}