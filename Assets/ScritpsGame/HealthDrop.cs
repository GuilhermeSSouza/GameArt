using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : MonoBehaviour {
    public int heart = 1;
    public string objectTag;
    public int timeDeath = 10;


    private void Start()
    {
        Destroy(gameObject, timeDeath);
    }



    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == objectTag)
        {

            HealtScript healt = col.gameObject.GetComponent<HealtScript>();

            healt.HealtDrop( heart);
            Destruir();
        }
    }

    private void Destruir()
    {

        Destroy(gameObject, 0);
    }
}
