using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitKey : MonoBehaviour {

    private Collider2D cd2d;

    private void Start()
    {
        cd2d = GameObject.FindGameObjectWithTag("Exit").GetComponent<Collider2D>();
        
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            cd2d.enabled = true;
            
        }

        Destroy(this.gameObject);
    }



}
