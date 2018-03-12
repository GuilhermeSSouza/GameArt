using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour {


    public GameObject shooting;
    public Transform shootRigth;
    public Transform shootLeft;

    private bool attacking = false;
    private bool vision = false;
    public float shootintRate = 1.3f;
    public float rangeShoot;
    private float shootCooldown;
    public float speedShoot;
    public Vector2 DirectionShoot;
    

   

    private Enemy enemy;
    private Animator anim;

    void Start()
    {
        shootCooldown = 0;
        enemy = gameObject.GetComponentInParent <Enemy> ();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {

        anim.SetBool("Attacking", attacking);

        if (shootCooldown > 0) {
            attacking = false;
            shootCooldown -= Time.deltaTime;
        }


        if (enemy.transform.localScale.x > 0) {

            DirectionShoot = new Vector2( -1, 0);
        }


        if (enemy.transform.localScale.x < 0)
        {

            DirectionShoot = new Vector2(1, 0);
        }

        if (Mathf.Abs( enemy.distance ) < rangeShoot) {
            AttackShoot();
        }

        if (enemy.distance <= enemy.distancePlayer)
        {
            vision = true;
        }
        else {
            vision = false;
        }

    }


    void AttackShoot() {

        if (shootCooldown <= 0 && (enemy.transform.localScale.x <0) && vision) {
            attacking = true;
            shootCooldown = shootintRate;
            GameObject shoot;
            shoot = Instantiate(shooting, shootRigth.transform.position, shootRigth.transform.rotation) as GameObject;
            shoot.transform.localScale = new Vector3(0.45f, 0.45f, 1f);
            shoot.GetComponent<Rigidbody2D>().velocity = DirectionShoot * speedShoot;
        }

        if (shootCooldown <= 0 && (enemy.transform.localScale.x >0) && vision)
        {

            attacking = true;
            shootCooldown = shootintRate;
            GameObject shoot;
            shoot = Instantiate(shooting, shootRigth.transform.position, shootRigth.transform.rotation) as GameObject;
            shoot.transform.localScale = new Vector3(-0.45f, 0.45f, 1f);
            shoot.GetComponent<Rigidbody2D>().velocity = DirectionShoot * speedShoot;
        }
    }
}
