using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    public float speedMove = 5;
    public float damage;
    public  float velocidadeEnemy;
    public float range =3f;      
    public float distance;
    public float distancePlayer;
    public bool grounded;
    public Transform target;
    public Vector2 direction;
    private Rigidbody2D rg2d;
    private Animator anim;
    private Enemy enemy;
    private int couretHealth;
    public GameObject drop;
    private Vector3 scaleObject;
 


    private void Start()
    {
        rg2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        enemy = gameObject.GetComponentInParent<Enemy>();
        scaleObject = transform.localScale;
    }

    // Update is called once per frame
    void Update() {
        distance = Vector3.Distance(transform.position, target.transform.position);
        anim.SetFloat("Speed", velocidadeEnemy);
        couretHealth = enemy.GetComponent<HealtScript>().hp;

        if (target.transform.position.x - transform.position.x < - 0.5)
        {
            direction = new Vector2(-1, 0);
            transform.localScale = new Vector3(scaleObject.x, scaleObject.y, scaleObject.z);
        }
        else if (target.transform.position.x - transform.position.x > 0.5)
        {
            direction = new Vector2(1, 0);
            transform.localScale = new Vector3((-1)*scaleObject.x, scaleObject.y, scaleObject.z);
        }
        else {
            direction = new Vector2(0, 0);
        }
    
                     
        RangeCheeck();


        if (couretHealth <= 0) {
            
            Destroy(gameObject, 0);
            Drop();

        }
      
    }
    void MoveEnemy() {

        if (grounded)
        {
            rg2d.velocity = direction * speedMove;
        }
        else {

            rg2d.AddForce(Vector2.down*10f);
        }

    }

    void RangeCheeck()
    {
        if ((range <= distance) && distance < distancePlayer  )
        {
            MoveEnemy();
            velocidadeEnemy = Mathf.Abs(rg2d.velocity.x);
        }
        else
        {
            velocidadeEnemy = Mathf.Abs(rg2d.velocity.x);
        }

    }

    /*
     * Random drops. Mais adiante 
     * 
     */

    void Drop() {

        
        Vector3 dropVector = new Vector3(transform.position.x , transform.position.y-0.7f, 1);

        Instantiate(drop, dropVector, transform.rotation);

    }
}
