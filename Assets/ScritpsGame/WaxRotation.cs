using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaxRotation: MonoBehaviour
{


    public int velRotation;
    public GameObject sprite;
    


    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        sprite.transform.Rotate(0, 0, Time.deltaTime * velRotation);
    }

}
