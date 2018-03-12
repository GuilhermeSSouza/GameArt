using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{


    public float speedMove = 5;
    public float damage;

    public float velocidadeEnemy;

    public Transform target;

    public Vector2 direction;

    public float range = 3f;



    public float distance;

    public float distancePlayer;

    private Rigidbody2D rg2d;

    private Animator anim;

    private EnemyBoss enemyBoss;

    private int couretHealth;

    public GameObject dropKey;

    private BlockDoor door;



    private void Start()
    {
        rg2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        enemyBoss = gameObject.GetComponentInParent<EnemyBoss>();
        door = GameObject.FindGameObjectWithTag("BlockDoor").GetComponent<BlockDoor>();

    }

    // Update is called once per frame
    void Update()
    {
        Distancia();
        anim.SetFloat("Speed", velocidadeEnemy);
        couretHealth = enemyBoss.GetComponent<HealtScript>().hp;


        if (target.transform.position.x - transform.position.x < -0.5)
        {

            direction = new Vector2(-1, 0);
            transform.localScale = new Vector3(-5.0f, 5f, 1.0f);
        }
        else if (target.transform.position.x - transform.position.x > 0.5)
        {
            direction = new Vector2(1, 0);
            transform.localScale = new Vector3(5f, 5f, 1.0f);
        }
        else
        {
            direction = new Vector2(0, 0);

        }


        //distance = Mathf.Abs(target.transform.position.x - transform.position.x);

        RangeCheeck();


        if (couretHealth <= 0)
        {
            door.durabality = -1;
            Destroy(gameObject, 0);


            Drop();

        }
       




    }

    private void Distancia()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);
    }

    void MoveEnemy()
    {
        rg2d.velocity = direction * speedMove;
    }

    void RangeCheeck()
    {

        if ((range <= distance) && distance < distancePlayer)
        {
            MoveEnemy();
            velocidadeEnemy = Mathf.Abs(rg2d.velocity.x);
        }
        else
        {
            velocidadeEnemy = Mathf.Abs(rg2d.velocity.x);

        }

    }




    void Drop() {

        Instantiate(dropKey, transform.position, transform.rotation);
    }

    

}
