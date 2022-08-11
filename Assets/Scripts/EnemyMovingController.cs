using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovingController : EnemyController, IMovingToX
{
    //Child EnemyController


    private Rigidbody2D rb;

    public void MoveObject()
    {
        rb = rb == null ? GetComponent<Rigidbody2D>() : rb;

        int dir = 0;

        if (rb.velocity.x == 0) 
            dir = Random.Range(0, 2) == 1 ? -1 : 1;
        else if (transform.position.x > 9) 
            dir = -1;
        else if (transform.position.x < -9) 
            dir = 1;


        if (dir == 0) return;

        rb.velocity = new Vector2(0, rb.velocity.y);
        rb.velocity += 5 * dir * Vector2.right;
    }
}
