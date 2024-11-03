using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanOpenlab : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            Destroy(this.gameObject);
    }
}