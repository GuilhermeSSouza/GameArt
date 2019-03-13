using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackMelee : MonoBehaviour {

    private bool attacking = false;
    private float attackTimer = 0;
    public float attackCd = 0.3f;


    public Collider2D attackMelee;
    new AudioSource audio;

    private Animator anim;

     void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        audio = gameObject.GetComponent<AudioSource>();
        attackMelee.enabled = false;
        audio.enabled = false;
    }

    void Update()
    {

        anim.SetBool("AttackMelee", attacking);
        if (Input.GetButtonDown("Fire2") && !attacking) {

            audio.enabled = true;
            audio.Play();
            attacking = true;
            attackTimer = attackCd;
            attackMelee.enabled = true;

        }

        if (attacking) {

            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
               
                attacking = false;
                attackMelee.enabled = false;
               
            }
        } 

    }


}
