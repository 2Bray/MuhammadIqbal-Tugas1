using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        if (GameManager.Instance.GetGameOver) return;

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
                    obj.ObjGotClick();
                }
            }
        }
    }
}
