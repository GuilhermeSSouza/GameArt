using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{

    public GameObject MenuUI;
    private bool paused = false;




    void Start()
    {
        MenuUI.SetActive(false);

    }


    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;

        }

        if (paused)
        {
            MenuUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (!paused)
        {
            MenuUI.SetActive(false);
            Time.timeScale = 1;
        }

    }


    public void Renume()
    {
        paused = false;

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuPrincipal()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }


}
