﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {


    private Player player;

	void Start () {

        player = gameObject.GetComponentInParent<Player>();
		
	}


    void OnTriggerStay2D(Collider2D collision)
    {
        player.grounded = true;
    }
     void OnTriggerExit2D(Collider2D collision)
    {
        player.grounded = false;
    }


}
