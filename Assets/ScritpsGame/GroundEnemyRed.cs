using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyRed : MonoBehaviour {

    private EnemyRed enemy;

    void Start()
    {

        enemy = gameObject.GetComponentInParent<EnemyRed>();

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
