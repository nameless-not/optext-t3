using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Myplayer : MonoBehaviour
{
    public Openlab2024Work inputcontrol;
    public Rigidbody2D rb;
    private PhysicsCheck physicsCheck;
    public Vector2 inputDirection;
    public float speed;
    public float jumpForce;
    public float ladderForce;
    public bool isHurt;
    public float hurtForce;
    public bool isDead;
    public bool isAttact;
    public bool isMagic;
    private PlayerAnimation playerAnimation;
    private TiZi tiZi;
    private Box box;
    private Character character;
    public int inMagic = 0;


    Transform stampPoint;

    // Start is called before the first frame update
    private void Awake()
    {   
        rb = GetComponent<Rigidbody2D>();

        physicsCheck = GetComponent<PhysicsCheck>();

        inputcontrol = new Openlab2024Work();

        inputcontrol.Gameplay.Jump.started += Jump;

        inputcontrol.Gameplay.Attact.started += PlayerAttact;

        playerAnimation = GetComponent<PlayerAnimation>(); 

        tiZi = GetComponent<TiZi>();

        character = GetComponent<Character>();

        stampPoint = transform.Find("StampPoint");
    }


    

    private void OnEnable()
    {
        inputcontrol.Enable();
    }

    private void OnDisable()
    {
        inputcontrol.Disable();
    }

    private void Update()
    {
        inputDirection = inputcontrol.Gameplay.Move.ReadValue<Vector2>();

    }

    private void FixedUpdate()
    {

        if(!isHurt)
            Move();

        StampTest();
    }

    public void Move()
    {
        rb.velocity = new Vector2(inputDirection.x * speed * Time.deltaTime,rb.velocity.y);

        int faceDir = (int)transform.localScale.x;
        if (inputDirection.x > 0)
            faceDir = 1;
        if (inputDirection.x < 0)
            faceDir = -1;
        transform.localScale = new Vector3(faceDir,1,1);

            
    }

    private void StampTest()
    {
        Collider2D c = Physics2D.OverlapCircle(stampPoint.position, 0.1f, LayerMask.GetMask("Weakenemy"));
        if (c == null)
            return;
        else
        {
            c.gameObject.layer = 2;
            Destroy(c.gameObject);
            rb.AddForce(new Vector2(0, 5));
        }

    }

    //private void Grav()
    //{

    //}


    //public bool isground;

    int jumpCount = 0;

    private void Jump(InputAction.CallbackContext obj)
    {
        //if (tiZi.isOntizi)
        //    isground = true;
        //else
        //    isground = physicsCheck.isGround;
        if (physicsCheck.isGround)
            jumpCount = 0;
        if (physicsCheck.isGround | jumpCount <= 1)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
        }
        else
        {
            jumpCount = 2;
        }
    }

    private void PlayerAttact(InputAction.CallbackContext obj)
    {
        playerAnimation.PlayerAttact();
        isAttact = true;
        

    }

    public void GetHurt(Transform attacker)
    {
        isHurt = true;
        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2((transform.position.x - attacker.position.x), 0).normalized;
        rb.AddForce (dir*hurtForce, ForceMode2D.Impulse);
    }

    public void PlayerDead()
    {
       
        isDead = true;
        inputcontrol.Gameplay.Disable();
        
               
    }


}
