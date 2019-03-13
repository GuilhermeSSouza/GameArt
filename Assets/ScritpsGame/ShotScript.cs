using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour {

    public int damage = 1;
    public string objectTag;
    public float shootSpeed;
    private Rigidbody2D rg2d;
    


    private void Start()
    {
        Destroy(gameObject, 0.50f);
        rg2d = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        rg2d.velocity = new Vector2(shootSpeed* transform.localScale.x, 0);

    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(objectTag))      {

            HealtScript healt = col.gameObject.GetComponent<HealtScript>();

            healt.Damage(damage);
            Destroy(this.gameObject.GetComponent<Renderer>());
            Destroy(this.gameObject.GetComponent<Collider2D>());
            Destroy(this.gameObject, 1);
        }
        if (col.CompareTag("Ground")||col.CompareTag("BlockDoor"))
        {
            Destroy(this.gameObject.GetComponent<Renderer>());
            Destroy(this.gameObject.GetComponent<Collider2D>());
            Destroy(this.gameObject, 1);

        }


    }

    

}
