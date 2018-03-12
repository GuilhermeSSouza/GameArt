using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour {

    public float timeFall;
    private Rigidbody2D rg2d;

	// Use this for initialization
	void Start () {
       
        rg2d = gameObject.GetComponent<Rigidbody2D>();
        rg2d.isKinematic = true;
	}

    // Update is called once per frame

     void OnCollisonEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            timeFall -= Time.deltaTime;
        }
        if (timeFall <= 0) {

            rg2d.isKinematic = false;
            
        }
    }

}
