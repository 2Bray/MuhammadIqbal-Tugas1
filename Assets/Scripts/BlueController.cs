using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueController : ObjController
{
    //Child ObjController

    //Game Over Ketika Di Klick
    public override void Death()
    {
        if (GameManager.Instance.getGameOver()) return;

        GameManager.Instance.GameOver();

        gameObject.SetActive(false);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public override void Finish()
    {
        gameObject.SetActive(false);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
