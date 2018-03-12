using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMeleeScript : MonoBehaviour {


    public int dmg = 2;
    public string TagName;

        private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true && col.CompareTag(TagName)) {

            col.SendMessageUpwards("Damage", dmg);

        }        
    }

}
