using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : Enemy
{
    private Myplayer myplayer;
    private void Check()
    {
        if (gameObject.layer == 2)
            myplayer.isMagic = true;

    }
}
