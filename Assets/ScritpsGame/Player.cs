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


    private bool doubleJump;
    public bool grounded;
    public bool shootDown = false;
    public bool getKeyPlayer;



    public int corentHealth;
    public int maxHealth = 5;


    private Rigidbody2D rg2d;
    private Animator anim;
    private Player player;
    GameObject objectEmpty;
    private Spring spring;
    private Image menu;
    //new AudioSource[] audio;
    //private float audioMove= 0;
    
    // faz a inicalizações dos elementos q serão usados na cena.
    private void Start()
    {
        //audio = gameObject.GetComponents<AudioSource>();
        menu = GameObject.FindGameObjectWithTag("MenuPause").GetComponent<Image>();  
        objectEmpty = new GameObject();
        player = gameObject.GetComponentInParent<Player>();
        rg2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        corentHealth = maxHealth;
      

    }


    void Update()
    {   anim.SetBool("Grounded", grounded);
        anim.SetBool("ShootDown", shootDown);
        anim.SetFloat("speed", Mathf.Abs(rg2d.velocity.x));
        anim.SetInteger("CorentHealth", corentHealth);
        corentHealth = player.GetComponent<HealtScript>().hp;

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1);
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }

        if (Input.GetButtonDown("Jump"))
        {
          
            if (grounded)
            {
              
                doubleJump = true;
                rg2d.AddForce(Vector2.up * jumpPower);
               
            }
            else if (doubleJump)
            {
                
                doubleJump = false;
                rg2d.AddForce(Vector2.up * (jumpPower - 110f));
               
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
            weaponScript weapon = GetComponent<weaponScript>();
            if (weapon != null)
            {
                weapon.AttackShoot();
            }
        }
        else
        {
            shootDown = false;
        }
        
        

    }
    void FixedUpdate()    {
        Vector3 veloc = rg2d.velocity;
        veloc.y = rg2d.velocity.y;
        veloc.z = 0.0f;
        veloc.x *= 0.85f;

        if (grounded)
        {
            rg2d.velocity = veloc;
        }
        /*
         * Refatora pra deixar velocidade constante.
         * opção a ser estudada maia a frente. 
         */

        float h = Input.GetAxis("Horizontal");
        rg2d.AddForce((Vector2.right * h) * speed);

        if (rg2d.velocity.x > maxSpeed)        {
            rg2d.velocity = new Vector2(maxSpeed, rg2d.velocity.y);

        }
        if (rg2d.velocity.x < -maxSpeed)
        {
            rg2d.velocity = new Vector2(-maxSpeed, rg2d.velocity.y);

        }

        /*
         * Refatorar isso. 
         */
        //PlayerMoveAudio(audioMove);

    }

    void Die()
    {
        Destroy(gameObject, 1.2f);
        int n = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(n);


    }

    void Key()
    {

        getKeyPlayer = true;

    }

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


    /*
     * 
     * Sicornização pessima. Deve existir um metodo ou api que faça isso.
     *

    void PlayerMoveAudio(float play) {
        if (rg2d.velocity.x != 0 && grounded && play <= 0)
        {
            GetComponent<AudioSource>()[2].enabled = true;
            GetComponent<AudioSource>()[2].Play();
            audioMove = 1.5f;
        }
        else {
            audioMove -= Time.deltaTime;
        }
    }
    */
}
