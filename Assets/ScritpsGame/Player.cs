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
    public bool grounded = true;
    public bool shootDown = false;
    public bool getKeyPlayer;





    private bool doubleJump;    
    private Rigidbody2D rg2d;
    private Animator anim;
    private Player player;    
    private Spring spring;
    private Image menu;




    GameObject objectEmpty;


    
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

        if (!grounded && rg2d.velocity.y < -3)
        {
            rg2d.gravityScale = 1.9f;
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
         * opção a ser estudada mais a frente. 
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
