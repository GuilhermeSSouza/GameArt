using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour {


    public int levelLoad;
    private SetupManager setupMan;

    private void Start()
    {
        setupMan = GameObject.FindGameObjectWithTag("Manager").GetComponent<SetupManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {

            setupMan.inuputLevel.text = ("Press    [E]");

            if (Input.GetKeyDown("e"))
            {
                SaveScore();
                SceneManager.LoadScene(levelLoad);
            }
           
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            setupMan.inuputLevel.text = ("Press    [E]");

            if (Input.GetKeyDown("e"))
            {
                SaveScore();
                SceneManager.LoadScene(levelLoad);
            }

        }
    }

        private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            setupMan.inuputLevel.text = ("");

           

        }
    }

    void SaveScore() {

        PlayerPrefs.SetInt("Score", setupMan.score);
    }

}
