using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDrop : MonoBehaviour
{


    public string tagName;
    public int coinsValue;
    new AudioSource audio;
    private SetupManager setupMan;


    // Update is called once per frame

    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        setupMan = GameObject.FindGameObjectWithTag("Manager").GetComponent<SetupManager>();
        audio.enabled = false;
    }


    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(tagName))
        {
            audio.enabled = true;
            audio.Play();
            setupMan.score += coinsValue;          
            
            Destroy(this.gameObject.GetComponent<Collider2D>());
            Destroy(this.gameObject.GetComponent<Renderer>());
            Destroy(this.gameObject, 1);
        }
    }
       

}
