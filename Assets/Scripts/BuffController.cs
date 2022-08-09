using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffController : ObjController
{
    //Child ObjController

    //Menambah Jumlah Hati Jika Di Klick
    public override void Death()
    {
        if (GameManager.Instance.getGameOver()) return;

        GameManager.Instance.SetHeart(1);

        gameObject.SetActive(false);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public override void Finish()
    {
        gameObject.SetActive(false);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
