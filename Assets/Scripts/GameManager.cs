using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float gameSpeed { get; private set; }
    public float initialGameSpeed = 5f;
    public float gameSoeedIncrease = 0.1f;
    public bool IsGameOver { get; private set; }

    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button retryButton;
    
    private int score = 1;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    [SerializeField] private Player player;
    [SerializeField] private Spawner spawner;

    private void Awake()
    {
        if(Instance == null)
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
        if(Instance == this)
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
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }
        
        gameSpeed = initialGameSpeed;
        enabled = true;
        score = 1;
        
        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        //Debug.Log($"game speed: {gameSpeed}");
        gameSpeed += gameSoeedIncrease * Time.deltaTime;
        
        if(!IsGameOver)
        {
            score++;
        }
        
        scoreText.text = (score).ToString();
    }

    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;

        IsGameOver = true;
        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
    }
}
