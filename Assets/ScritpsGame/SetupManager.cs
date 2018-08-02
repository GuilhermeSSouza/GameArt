using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetupManager : MonoBehaviour {

    public int score;

    public Text scoreCoins;
    public Text inuputLevel;
    public Text startLevel;



    void Start()
    {
        if (PlayerPrefs.HasKey("Score")) {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                PlayerPrefs.DeleteKey("Score");
                score = 0;
            }
            else {
                score = PlayerPrefs.GetInt("Score");
            }
        }
    }
    void Update () {

        scoreCoins.text = ("SCORE:   " +  score);
	}

    void Coins(int coins) {

       score += coins;


    }


}
