using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float gameSpeed { get; private set; }
    public float initialGameSpeed = 5f;
    public float gameSoeedIncrease = 0.1f;
    public bool IsGameOver { get; private set; }

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

    private void NewGame()
    {
        IsGameOver = false;
        gameSpeed = initialGameSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
        //Debug.Log($"game speed: {gameSpeed}");
        gameSpeed += gameSoeedIncrease * Time.deltaTime;
    }
}
