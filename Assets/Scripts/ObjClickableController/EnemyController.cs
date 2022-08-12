using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : ObjController, IDamageAfterFinish
{
    //Child ObjController


    public delegate void EnemyDelegate();
    public static event EnemyDelegate OnEnemyHit;
    public static event EnemyDelegate OnEnemyFinish;

    //Menambah Skor Saat Di Klick
    public override void Death() => OnEnemyHit();

    public void FinishAndAttack() => OnEnemyFinish();
}
