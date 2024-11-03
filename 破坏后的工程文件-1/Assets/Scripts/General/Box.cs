using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Myplayer myplayer;
    private void Awake()
    {
        myplayer = GetComponent<Myplayer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
            myplayer.isMagic = true;

    }

}
