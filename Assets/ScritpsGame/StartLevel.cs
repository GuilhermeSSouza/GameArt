using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour {


    private SetupManager mana;
    private void Start()
    {
        mana = GameObject.FindGameObjectWithTag("Manager").GetComponent<SetupManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {

            mana.startLevel.text = ("Esse lugar... ");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mana.startLevel.text = ("Esse lugar...");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            mana.startLevel.text = ("");
        }
    }


}
