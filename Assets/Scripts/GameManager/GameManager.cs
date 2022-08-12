using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void GameDelegateInt(int i);
    public static event GameDelegateInt OnLvlIncrease;
    public static event GameDelegateInt OnHeartUpdate;
    public static event GameDelegateInt OnScoreUpdate;

    public delegate void GameDelegate();
    public static event GameDelegate OnGameStart;
    public static event GameDelegate OnGameOver;

    public static GameManager Instance;

    private bool gameOver;
    public bool GetGameOver { get { return gameOver; } }
    private int heart;
    private int score;
    private int lvl;

    private void OnEnable()
    {
        BlueController.OnBlueHit += OnBlueHit;
        BuffController.OnBuffHit += OnBuffHit;
        EnemyController.OnEnemyHit += OnEnemyHit;
        EnemyController.OnEnemyFinish += OnEnemyFinish;
        WaveTimer.OnWaveOpen += OnWaveOpen;
    }

    private void OnDisable()
    {
        BlueController.OnBlueHit -= OnBlueHit;
        BuffController.OnBuffHit -= OnBuffHit;
        EnemyController.OnEnemyHit -= OnEnemyHit;
        EnemyController.OnEnemyFinish -= OnEnemyFinish;
        WaveTimer.OnWaveOpen -= OnWaveOpen;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        heart = 3;
        score = 0;
        lvl = 0;
        gameOver = false;

        OnGameStart();
    }

    private void OnWaveOpen()
    {
        lvl++;
        OnLvlIncrease(lvl);
    }

    private void OnEnemyHit() => AddScore();
    private void OnEnemyFinish() => SetHeart(-1);
    private void OnBlueHit() => GameOver();
    private void OnBuffHit() => SetHeart(1);

    //Di eksekusi jika heart bertambah atau berkurang 1
    private void SetHeart(int value)
    {
        heart += value;

        if (heart < 1) GameOver();
        else if (heart > 3) heart = 3;

        OnHeartUpdate(heart);
    }

    private void AddScore()
    {
        score += 10;
        OnScoreUpdate(score);
    }

    private void GameOver()
    {
        gameOver = true;
        OnGameOver();
    }
}