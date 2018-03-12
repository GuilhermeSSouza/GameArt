using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxePendulo : MonoBehaviour {


    public GameObject sprite;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



        sprite.transform.Translate(0, 45, 0);

    }
}
