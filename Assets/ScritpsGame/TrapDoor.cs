using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour {



    public string tagName;
    private BlockDoor door;
    private Collider2D col;

    private void Start()
    {
        col = gameObject.GetComponent<Collider2D>();
        door = GameObject.FindGameObjectWithTag("BlockDoor").GetComponent<BlockDoor>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagName)) {

            door.GetComponent<Collider2D>().isTrigger = false;

            Destroy(col);
        }
    }



}
