using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {
        
    public float upForce;
    public bool jumpTrue = false;
    private Animator anim;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("Jump", jumpTrue);
    }

}
