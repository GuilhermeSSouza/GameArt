using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupManager : MonoBehaviour {

    public int getCoins;

    public Text scoreCoins;
    public Text inuputLevel;
    public Text startLevel;
	
	// Update is called once per frame
	void Update () {

        scoreCoins.text = ("SCORE:   " +  getCoins);
	}

    void Coins(int coins) {

        getCoins += coins;


    }


}
