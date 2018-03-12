using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumDamage : MonoBehaviour {

    public int damage;
    public float cwdown;
    private float timeDamage;


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && timeDamage <= 0)
        {
            collision.gameObject.SendMessage("Damage", damage);
            timeDamage = cwdown;
        }
        else {
            timeDamage -= Time.deltaTime;
        }
    }

}
