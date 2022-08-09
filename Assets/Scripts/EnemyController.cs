using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : ObjController
{
    //Child ObjController

    //Menambah Skor Saat Di Klick
    public override void Death()
    {
        if (GameManager.Instance.getGameOver()) return;

        GameManager.Instance.AddScore();

        gameObject.SetActive(false);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    //mengurangi Jumlah Hati Ketika Menyentuh Garis Akhir
    public override void Finish()
    {
        if (!GameManager.Instance.getGameOver()) GameManager.Instance.SetHeart(-1);

        gameObject.SetActive(false);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
