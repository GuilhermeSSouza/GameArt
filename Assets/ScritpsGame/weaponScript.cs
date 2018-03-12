using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponScript : MonoBehaviour {

    public GameObject Shooting;
    public Transform shotPrefab;
    public Transform ShootRigth;
    public Transform ShootLeft;
    public float SpeedShoot;
    public Vector2 DirectionShoot;

    public float shootintRate = 0.25f;

    private float shootCooldown;

    private Player player;
   

    

   

    // Use this for initialization
    void Start () {

        shootCooldown = 0;
        player = gameObject.GetComponentInParent<Player>();
        
        
        }
	
	// Update is called once per frame
	void Update () {

        if (shootCooldown > 0) {

            shootCooldown -= Time.deltaTime;
        }


        DirectionShoot = new Vector2(player.transform.localScale.x, player.transform.localScale.y);
     
		
	}
    /**
     *Metodo AttackShoot verifica o cooldown e a direção do Player pelo localScale
     * e instancia objetos do tipo shot, que são prefabs de "tiros" e adiciona 
     * velocidade e direção baseando se na direção do player 
     */
    public void AttackShoot() {


        if ((shootCooldown <= 0) && (player.transform.localScale.x == 0.5))
        {
            shootCooldown = shootintRate;
            GameObject shot;
            shot = Instantiate(Shooting, ShootRigth.transform.position, ShootRigth.transform.rotation) as GameObject;
            shot.GetComponent<Rigidbody2D>().velocity = DirectionShoot* SpeedShoot;
            

        }
        if ((shootCooldown <= 0) && (player.transform.localScale.x == -0.5))
        {
            shootCooldown = shootintRate;
            GameObject shot;
            shot = Instantiate(Shooting, ShootRigth.transform.position, ShootRigth.transform.rotation) as GameObject;
            shot.transform.localScale = new Vector3(-0.25f, 0.25f, 1f);
            shot.GetComponent<Rigidbody2D>().velocity = DirectionShoot * SpeedShoot;
         
            
            
        }
    }
}
