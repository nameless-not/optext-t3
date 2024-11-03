using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Creature : MonoBehaviour
{
    private Character character;
    //private float Counter=5;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            character.toHeal = true;
        
    }


}
