using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjController : MonoBehaviour
{
    //Dieksekusi oleh parent
    //Menspawn & Mengacak posisi x
    public void Spawn()
    {
        transform.position = new Vector3(Random.Range(-8f, 8f), 5, transform.position.z);

        gameObject.SetActive(true);

        //Kecepatan Bertambah seiring lvl meningkat
        GetComponent<Rigidbody2D>().velocity = Vector2.down * (2 + (GameManager.Instance.GetLvl() / 5));
    }

    // Ketika Mencapai EndLine
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndLine")) Finish();
    }

    //Ketika Di Klick Player
    public void Death()
    {
        if (GameManager.Instance.getGameOver()) return;

        if (CompareTag("Enemy"))
        {
            GameManager.Instance.AddScore();
        }
        else if (CompareTag("Blue"))
        {
            GameManager.Instance.GameOver();
        }
        else if (CompareTag("Buff"))
        {
            GameManager.Instance.SetHeart(1);
        }

        gameObject.SetActive(false);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    private void Finish()
    {
        if (CompareTag("Enemy") && !GameManager.Instance.getGameOver()) GameManager.Instance.SetHeart(-1);

        gameObject.SetActive(false);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
