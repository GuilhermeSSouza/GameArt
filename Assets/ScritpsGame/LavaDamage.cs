using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDamage : MonoBehaviour {



    public string tagName;
    public float damage;
    private float timeDamage;
    public float cwdDamage;

    void Start()
    {
        
    }



    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == tagName && timeDamage <= 0)
        {          
            collision.gameObject.SendMessage("Damage", damage);
            timeDamage = cwdDamage;
        }
        else {

            timeDamage -= Time.deltaTime;

        }

    }

  
 

}
