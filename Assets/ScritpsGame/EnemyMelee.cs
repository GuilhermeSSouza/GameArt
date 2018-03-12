using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour {

    public bool attacking = true;
    public bool text = true;
    public float attackTimer = 0;
    public float attackCd = 100f;
    private EnemyRed enemy;
    public float Range;


    public Collider2D attackMelee;

    private Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        attackMelee.enabled = false;
        enemy = gameObject.GetComponentInParent<EnemyRed>();
    }



    /*
     * Variavéis disancia para entrar em acão teram q ser passadas  por parametros via console.
     * 
     */
    void Update()
    {

       
        if ((enemy.distance <= enemy.range )&& attacking )
        {

            anim.SetBool("AttackMelee", text);

            attacking = false;
            attackTimer = attackCd;
            attackMelee.enabled = true;

        }

        if (!attacking)
        {

            if (attackTimer > 0)
            {

                anim.SetBool("AttackMelee", text);
                text = false;
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = true;
                text = true;
                attackMelee.enabled = false;


            }
        }

    }

}
