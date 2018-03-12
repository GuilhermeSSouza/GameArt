using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetKey : MonoBehaviour
{

    public string tagName;
    


    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(tagName))
        {

            col.gameObject.SendMessage("Key");
        }

        Destroy(this.gameObject);
    }
    
}


