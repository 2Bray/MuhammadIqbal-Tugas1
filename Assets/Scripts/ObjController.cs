using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjController : MonoBehaviour
{
    //Dieksekusi oleh parent
    //Menspawn & Mengacak posisi x
    public void Spawn()
    {
        transform.position = new Vector3(Random.Range(-8f, 8f), 5, transform.position.z);

        gameObject.SetActive(true);

        //Kecepatan Bertambah seiring lvl meningkat
        GetComponent<Rigidbody2D>().velocity = Vector2.down * (4 + (GameManager.Instance.GetLvl() / 5));
    }

    // Ketika Mencapai EndLine
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EndLine")) Finish();
    }

    //Ketika Di Klick Player
    public abstract void Death();

    //Ketika Mencapai Garis Akhir
    public abstract void Finish();
}
