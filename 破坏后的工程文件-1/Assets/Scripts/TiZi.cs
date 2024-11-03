using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiZi : MonoBehaviour
{
    public bool isOntizi;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isOntizi = true;

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isOntizi = false;
        }
    }
}
