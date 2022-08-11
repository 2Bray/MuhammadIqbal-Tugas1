using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTimer : MonoBehaviour
{
    public delegate void WaveDelegateFloat(float f);
    public static event WaveDelegateFloat OnCountdownWave;

    public delegate void WaveDelegate();
    public static event WaveDelegate OnWaveOpen;
    public static event WaveDelegate OnCountdownEnd;

    [SerializeField] private SpawnParent enemyPrt;
    [SerializeField] private SpawnParent enemyMovingPrt;
    [SerializeField] private SpawnParent bluePrt;
    [SerializeField] private SpawnParent buffPrt;

    [SerializeField] private int baseEnemyCount;

    private float timer;
    private bool openWave;
    private bool gameOver;
    private int lvl;

    private void OnEnable()
    {
        GameManager.OnGameStart += OnGameStart;
        GameManager.OnLvlIncrease += OnLvlChange;
        GameManager.OnGameOver += OnGameOver;
    }

    private void OnDisable()
    {
        GameManager.OnGameStart -= OnGameStart;
        GameManager.OnLvlIncrease -= OnLvlChange;
        GameManager.OnGameOver -= OnGameOver;
    }

    private void OnGameStart()
    {
        timer = 7; //Pada saat start player memiliki 3 detik untuk memulai
        openWave = true;
        gameOver = false;
    }

    private void OnLvlChange(int value) => lvl = value;
    private void OnGameOver() => gameOver = true;

    private void Update()
    {
        if (gameOver) return;

        timer += Time.deltaTime;

        //Membuka Wave
        if (openWave)
        {
            OnCountdownWave(timer);

            if (timer > 10)
            {
                OnCountdownEnd();
                openWave = false;

                OnWaveOpen();
                StartCoroutine(spawnEnemy(0));
            }
        }
    }


    private IEnumerator spawnEnemy(int count)
    {
        yield return new WaitForSeconds(1f);

        //Mengacak object yg di spawn
        int r = Random.Range(0, 100);

        if (r < 5) buffPrt.SpawnChild();
        else if (r < 15) bluePrt.SpawnChild();
        else if (r < 45) enemyMovingPrt.SpawnChild();
        else enemyPrt.SpawnChild();

        //Rekursif
        //Jika count masih dibawah ketentuan. Ulangi pemanggilan
        if (count < lvl + baseEnemyCount) StartCoroutine(spawnEnemy(count += 1));
        else
        {
            //Jika object yang di spawn cukup
            //Buka kembali wave & reset timer
            //Lvl Meningkat
            openWave = true;
            timer = 0;
        }
    }
}
