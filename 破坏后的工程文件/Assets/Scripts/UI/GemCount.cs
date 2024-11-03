using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCount : MonoBehaviour
{
    int gemCount = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Gem"))
        {
            Destroy(collision.gameObject);
            gemCount++;
        }
       
    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = 50;
        GUI.Label(new Rect(20, 20, 500, 500), "\r\n        :" + gemCount);

    }
}
