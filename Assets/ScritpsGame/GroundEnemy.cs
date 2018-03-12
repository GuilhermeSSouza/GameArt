using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour {


    private Enemy enemy;

    void Start()
    {

       enemy = gameObject.GetComponentInParent<Enemy>();

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        enemy.grounded = true;
    }
   
    void OnTriggerExit2D(Collider2D collision)
    {
        enemy.grounded = false;
    }

}
