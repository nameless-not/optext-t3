using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public UnityEvent<Transform> OnTakeDamage;
    public UnityEvent OnMagic;
    public UnityEvent OnDie;
    public bool toHeal;
    private Myplayer myplayer;
    [Header("基本属性")]
    public float maxHealth;
    public float health;
    [Header("受伤无敌")]
    public float invulnerableDuration;
    public float invulnerableCounter;
    public bool isInvulnerable;


    public UnityEvent<Character> OnHealthChange;

    public void Update()
    {
        if (isInvulnerable)
        {
            invulnerableCounter -= Time.deltaTime;
            if (invulnerableCounter <= 0)
                isInvulnerable = false;
        }


    }


    private void Start()
    {
        health = maxHealth;
        OnHealthChange?.Invoke(this);
        myplayer = GetComponent<Myplayer>();
    }

    public void TakeDamage(Attack attacker)
    {
        if (isInvulnerable)
            return;
        if (health - attacker.damage > 0)
        {
            health -= attacker.damage;
            TriggerInvulnerable();
            OnTakeDamage?.Invoke(attacker.transform);
        }
        else
        //{ if(gameObject.tag == "Player" && myplayer.isMagic)
        //    {
        //        if (myplayer.inMagic < 3)
        //        {
        //            TriggerInvulnerable();
        //            myplayer.inMagic++;
        //            health = 1;
        //            OnMagic?.Invoke();
        //        }
        //        else
        //        {
        //            health = 0;
        //            OnDie?.Invoke();
        //        }
        //    }
        ////  else
           {health = 0;
            OnDie?.Invoke();
        }
           //}
           
        
        OnHealthChange?.Invoke(this);
        
    }

    


    public void TriggerInvulnerable()
    {
        if (!isInvulnerable)
        {
            isInvulnerable = true;
            invulnerableCounter = invulnerableDuration;
        }
    }



   
}

  