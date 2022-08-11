using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffController : ObjController
{
    //Child ObjController


    public delegate void BuffDelegate();
    public static event BuffDelegate OnBuffHit;

    //Menambah Jumlah Hati Jika Di Klick
    public override void Death() => OnBuffHit();
}
