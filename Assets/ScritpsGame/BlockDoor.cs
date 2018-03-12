using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDoor : MonoBehaviour {


    public int durabality;
    private Collider2D col;

	// Use this for initialization
	void Start () {
        col = gameObject.GetComponent<Collider2D>();

    }
	
	// Update is called once per frame
	void Update () {

        
        if (durabality <= 0) {
           col.isTrigger = true;

        }
	}


  
}
