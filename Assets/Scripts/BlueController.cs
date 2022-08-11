using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueController : ObjController
{
    //Child ObjController


    public delegate void BlueDelegate();
    public static event BlueDelegate OnBlueHit;

    //Game Over Ketika Di Klick
    public override void Death() => OnBlueHit();
}
