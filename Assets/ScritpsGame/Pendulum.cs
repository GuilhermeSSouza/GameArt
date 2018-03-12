using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour {



    public Rigidbody2D rgd2;
    public float leftPush;
    public float rigthPush;
    public float velcity;


	void Start () {

        rgd2 = gameObject.GetComponent<Rigidbody2D>();
        rgd2.angularVelocity = velcity;
	}
	
	// Update is called once per frame
	void Update () {

        Push();
	}

    public void Push() {

        if (transform.rotation.z > 0
            && transform.rotation.z < rigthPush
            && (rgd2.angularVelocity > 0)
            && rgd2.angularVelocity < velcity) {
            rgd2.angularVelocity = velcity;
        } else if ( transform.position.z<0 
            && transform.rotation.z>leftPush
            && (rgd2.angularVelocity < 0)
            && rgd2.angularVelocity> velcity*(-1)
            ) { rgd2.angularVelocity = velcity*(-1);
        }

    }


}
