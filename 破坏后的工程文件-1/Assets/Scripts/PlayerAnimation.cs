using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private PhysicsCheck physicsCheck;
    private Myplayer myplayer;
    private Character character;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
        myplayer = GetComponent<Myplayer>();
        character = GetComponent<Character>();
    }
    private void Update()
    {
        SetAnimation();
    }

    public void SetAnimation()
    {
        anim.SetFloat("velocityX", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("velocityY",rb.velocity.y);
        anim.SetBool("isGround", physicsCheck.isGround);
        anim.SetBool("isDead",myplayer.isDead);
        anim.SetBool("isAttact", myplayer.isAttact);
        anim.SetInteger("inMagic",myplayer.inMagic);
    }
    public void PlayHurt()
    {
        anim.SetTrigger("hurt");
    }

    public void PlayerAttact()
    {
        anim.SetTrigger("attact");
    }

    public void PlayerMagic()
    {
        anim.SetTrigger("magic");
    }
}
