using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }

            return instance;
        }
    }

    public Transform EndLine;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private UImanager uiManager;
    [SerializeField] private SpawnParent enemyPrt;
    [SerializeField] private SpawnParent bluePrt;
    [SerializeField] private SpawnParent buffPrt;
    [SerializeField] private Transform heartUI;
    [SerializeField] private int baseEnemyCount;

    private bool gameOver;
    private int heart;
    private int score;
    private float timer;
    private int lvl;
    private bool openWave;

    private void Start()
    {
        heart = 3;
        score = 0;
        timer = 7; //Pada saat start player memiliki 3 detik untuk memulai
        lvl = 1;
        gameOver = false;
        openWave = true;
    }

    private void Update()
    {
        if (gameOver) return;

        timer += Time.deltaTime;

        //Membuka Wave
        if (openWave)
        {
            uiManager.StartCountDown(timer);

            if (timer > 10)
            {
                openWave = false;
                StartCoroutine(spawnManager(0));

                uiManager.StartCountDown(timer);
            }
        }
        //Raycast untuk mendeteksi input player
        //Input Player Jgn Di Fixed Update Karena Harus Di Eksekusi Sesegera Mungkin
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                ObjController obj = hit.collider.GetComponent<ObjController>();

                if (obj != null)
                {
                    obj.Death();
                }
            }
        }
    }

    //Di eksekusi jika heart bertambah atau berkurang 1
    public void SetHeart(int value)
    {
        heart += value;

        if (heart < 1) GameOver();
        else if (heart > 3) heart = 3;

        for (int i = 0; i < heart; i++)
        {
            heartUI.GetChild(2 - i).gameObject.SetActive(true);
        }

        for (int j = 2; j >= heart; j--)
        {
            heartUI.GetChild(2 - j).gameObject.SetActive(false);
        }
    }

    public int GetHeart() => heart;
    public int GetLvl() => lvl;
    public bool getGameOver() => gameOver;

    public void AddScore()
    {
        score += 10;

        uiManager.UpdateScore(score);
    }

    private IEnumerator spawnManager(int count)
    {
        yield return new WaitForSeconds(1f);

        //Mengacak object yg di spawn
        int r = Random.Range(0, 100);

        if (r < 5) buffPrt.SpawnChild();
        else if (r < 15) bluePrt.SpawnChild();
        else enemyPrt.SpawnChild();

        //Rekursif
        //Jika count masih dibawah ketentuan. Ulangi pemanggilan
        if (count < lvl + baseEnemyCount) StartCoroutine(spawnManager(count += 1));
        else
        {
            //Jika object yang di spawn cukup
            //Buka kembali wave & reset timer
            //Lvl Meningkat
            openWave = true;
            timer = 0;
            lvl++;
        }
    }

    public void GameOver()
    {
        gameOver = true;
        heartUI.gameObject.SetActive(false);
        uiManager.SetGameOverPanel();
    }


}