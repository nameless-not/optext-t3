using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public Vector3 faceDir;
    public float normalSpeed;
    public float chaseSpeed;
    public float currentSpeed;
    public float chaseCounter;
    public int Size;
    //public int facedire;
    public bool isDead;
    public Vector2 centerOffset;
    public Vector2 checkSize;
    public float checkDistance;
    public LayerMask attactLayer;
    public PhysicsCheck physicsCheck;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
        anim = GetComponent<Animator>();
        currentSpeed = normalSpeed;
    }

    private void Update()
    {

        if(physicsCheck.touchLeftWall)
            transform.localScale = new Vector3(Size, Size, Size);
        else if(physicsCheck.touchRightWall)
        {
            transform.localScale = new Vector3(-Size, Size, Size);
        }

        faceDir = new Vector3(transform.localScale.x, 0, 0);
    }

    public void FixedUpdate()
    {
        Move();

    }
    public void Move()
    {
        if (rb.bodyType == RigidbodyType2D.Dynamic)
            rb.velocity = new Vector2(faceDir.x * normalSpeed * Time.deltaTime, rb.velocity.y);
  
    }

    



    private void OnDie()
    {
        gameObject.layer = 2;
        //isDead = true;
        
    }

    public void Death()
    {
        Destroy(this.gameObject);
    }
}
