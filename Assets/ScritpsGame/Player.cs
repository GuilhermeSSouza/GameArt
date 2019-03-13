using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    // Variavéis do game. Varaiveis declaradas publicas pode ser alteradas via console -> inpesionar elemento. Chamar elemntos da Unit 




    public float maxSpeed = 5;
    public float speed = 50f;
    public float jumpPower = 300f;
    public int corentHealth;
    public int maxHealth = 5;
    public bool shootDown = false;
    public bool getKeyPlayer;



    public Transform graundCheck;
    public float graundRadius;
    public bool isGrounded;
    public LayerMask layerCheck;



    private bool doubleJump;    
    private Rigidbody2D rg2d;
    private Animator anim;
    private Player player;    
    private Spring spring;
    private Image menu;


    private bool attacking = false;

    public Collider2D attackMelee;
    new AudioSource audio;

    public Transform shootPoint;
    public GameObject shoot;



    GameObject objectEmpty;


    
    // faz a inicalizações dos elementos q serão usados na cena.
    private void Start()
    {
        //audio = gameObject.GetComponents<AudioSource>();
        menu = GameObject.FindGameObjectWithTag("MenuPause").GetComponent<Image>();
        audio =  GameObject.FindGameObjectWithTag("MeleePlayer").GetComponent<AudioSource>();
        objectEmpty = new GameObject();
        
        player = gameObject.GetComponentInParent<Player>();
        rg2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        corentHealth = maxHealth;
      

    }


    void Update()   {


        isGrounded = Physics2D.OverlapCircle(graundCheck.position, graundRadius, layerCheck);
        
        anim.SetBool("Grounded", isGrounded);
        anim.SetBool("ShootDown", shootDown);
        anim.SetFloat("speed", Mathf.Abs(rg2d.velocity.x));
        anim.SetInteger("CorentHealth", corentHealth);
        anim.SetBool("AttackMelee", attacking);
        corentHealth = player.GetComponent<HealtScript>().hp;


       

        if (Input.GetAxisRaw("Horizontal") < -0.1f)
        {

            transform.localScale = new Vector3(-0.5f, 0.5f, 1);
            rg2d.velocity = new Vector2(-maxSpeed, rg2d.velocity.y);

        }
        else if (Input.GetAxisRaw("Horizontal") > 0.1f)
        {

            transform.localScale = new Vector3(0.5f, 0.5f, 1);
            rg2d.velocity = new Vector2(maxSpeed, rg2d.velocity.y);

        }
        else {
            rg2d.velocity = new Vector2(0, rg2d.velocity.y);
        }



        if (Input.GetButtonDown("Jump"))
        {          
            if (isGrounded)
            {             
                doubleJump = true;
                rg2d.velocity = new Vector2(rg2d.velocity.x, jumpPower);
                //rg2d.AddForce(Vector2.up * jumpPower);
            }
            else if (doubleJump)
            {
                doubleJump = false;
                rg2d.velocity = new Vector2(rg2d.velocity.x, jumpPower);
                //rg2d.AddForce(Vector2.up * (jumpPower - 110f));
            }

        }

            



        /**
         * Atualiza e destroi o jogador
         */


        if (corentHealth > maxHealth)
        {
            corentHealth = maxHealth;
        }

        if (corentHealth <= 0)
        {
            Invoke("Die", 0.6f);
        }


        if (Input.GetButtonDown("Fire1") && !(menu.isActiveAndEnabled))
        {
            shootDown = true;
            GameObject shootClone = (GameObject) Instantiate(shoot, shootPoint.position, shootPoint.rotation);
            shootClone.transform.localScale = (0.5f)*transform.localScale;

        }
        else
        {
            shootDown = false;
        }




        /**
         * Melee ataque e inicia audio 
         */

        if (Input.GetButtonDown("Fire2") && !attacking)
        {

            audio.enabled = true;
            audio.Play();
            attacking = true;
            attackMelee.enabled = true;

        }
        else {

            attacking = false;
        }







    }
    void FixedUpdate() { }
     

    void Die()
    {
        //Destroy(gameObject, 1.2f);        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }

    void Key()
    {

        getKeyPlayer = true;

    }





    /**
     * Metodo onCollisionEnter2D da classe, todos os teste de colisão dever ser implementados aqui
     */
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "MovingPlatform")
        {
            objectEmpty.transform.parent = col.transform;
            this.transform.parent = objectEmpty.transform;
        }
        if (col.collider.CompareTag("JumpUp"))
        {
            spring = GameObject.FindGameObjectWithTag("JumpUp").GetComponent<Spring>();
            spring.jumpTrue = true;
            rg2d.AddForce(Vector2.up *spring.upForce);
            

        }

    }







    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "MovingPlatform")
        {
            this.transform.parent = null;
        }
        if (col.collider.CompareTag("JumpUp"))
        {
            spring = GameObject.FindGameObjectWithTag("JumpUp").GetComponent<Spring>();
            spring.jumpTrue = false;       


        }
    }





    private void OnTriggerEnter2D(Collider2D col)
    {
        
    }


}
