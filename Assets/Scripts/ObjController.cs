using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjController : MonoBehaviour, IRayCast
{
    private bool gameOver = false;
    private int lvl = 0;

    private void OnEnable()
    {
        GameManager.OnGameOver += OnGameOver;
        GameManager.OnLvlIncrease += OnLvlIncrease;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= OnGameOver;
        GameManager.OnLvlIncrease -= OnLvlIncrease;
    }

    //Dieksekusi oleh SpawnParent
    //Menspawn & Mengacak posisi
    public void Spawn()
    {
        transform.position = new Vector3(Random.Range(-8f, 8f), 5, transform.position.z);

        gameObject.SetActive(true);

        //Kecepatan Bertambah seiring lvl meningkat
        GetComponent<Rigidbody2D>().velocity = Vector2.down * (4 + (lvl  / 5));
    }

    private void Update()
    {
        if (GetComponent<IMovingToX>() != null) GetComponent<IMovingToX>().MoveObject();

        // Ketika Mencapai EndLine
        if (transform.position.y < -6) FinishToSafeArea();
    }

    private void OnGameOver() => gameOver = true;
    private void OnLvlIncrease(int value) => lvl = value;

    private void FinishToSafeArea()
    {
        if (gameOver) return;

        if (CompareTag("Enemy")) GetComponent<EnemyController>().FinishAndAttack();

        deAktive();
    }

    public void ObjGotClick()
    {
        if (gameOver) return;

        Death();
        deAktive();
    }

    private void deAktive()
    {
        gameObject.SetActive(false);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public abstract void Death();

}
