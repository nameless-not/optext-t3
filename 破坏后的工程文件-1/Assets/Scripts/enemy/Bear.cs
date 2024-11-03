using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Enemy
{
    private Character character;
    private void chaseChange()
    {
        if (character.isInvulnerable)
        {
            currentSpeed = chaseSpeed;
            chaseCounter -= Time.deltaTime;

            if (chaseCounter <= 0)
                currentSpeed = normalSpeed;
        }
    }
}
