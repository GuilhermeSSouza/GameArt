using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShotPlayer : MonoBehaviour {


    public Vector2 speed = new Vector2(25, 0);

    private Vector2 movement;

    public Vector2 direction;

    private Rigidbody2D rg2d;
    private Player player;



    private void Start()
    {
        rg2d = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {           
        movement = new Vector2(direction.x * speed.x, 0);
    }
    private void FixedUpdate()
    {
        rg2d.velocity = movement;
    }
}
