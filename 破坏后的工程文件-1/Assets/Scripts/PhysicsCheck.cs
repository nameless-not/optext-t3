using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCheck : MonoBehaviour
{
    public float checkRaduis;
    public LayerMask groundLayer;
    public bool isGround;
    public Vector2 bottomOffset;
    public bool touchLeftWall;
    public bool touchRightWall;
    public Vector2 leftOffset;
    public Vector2 rightOffset;
    private void Update()
    {
        Check();
    }
    public void Check()
    {
        isGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, checkRaduis, groundLayer);

        touchLeftWall = Physics2D.OverlapCircle((Vector2)transform.position+leftOffset, checkRaduis, groundLayer);

        touchRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, checkRaduis, groundLayer);

    }
    private void OnDrawGizmosSlected()
    {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, checkRaduis);

        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, checkRaduis);

        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, checkRaduis);
    }



}
