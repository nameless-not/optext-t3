using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{
    public bool FoundPlayer()
    {
        return Physics2D.BoxCast(transform.position + (Vector3)centerOffset, checkSize, 0, -transform.up, checkDistance, attactLayer);
    }

    public void Update()

    {
        if (FoundPlayer())
            rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
