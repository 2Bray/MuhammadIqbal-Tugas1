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

    private void Start()
    {
        heart = 3;
        score = 0;
        lvl = 0;

        OnGameStart();
    }

    public void OnWaveOpen()
    {
        lvl++;
        OnLvlIncrease(lvl);
    }

    private void OnEnemyHit() => AddScore();
    public void OnEnemyFinish() => SetHeart(-1);
    public void OnBlueHit() => GameOver();
    public void OnBuffHit() => SetHeart(1);

    //Di eksekusi jika heart bertambah atau berkurang 1
    private void SetHeart(int value)
    {
        heart += value;

        if (heart < 1) GameOver();
        else if (heart > 3) heart = 3;

        OnHeartUpdate(heart);
    }

    public void AddScore()
    {
        score += 10;
        OnScoreUpdate(score);
    }

    public void GameOver()
    {
        OnGameOver();
    }
}