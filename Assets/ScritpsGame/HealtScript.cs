using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtScript: MonoBehaviour {


    public int hp = 1;

    public void Damage(int damageCount) {
        hp -= damageCount;
    }

    public void HealtDrop(int heart) {

        hp += heart;
    }

}
