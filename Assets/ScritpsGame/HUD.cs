using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    public Sprite[] HeartSprites;

    public Image HeartUI;

    private Player player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    private void Update()
    {
        if (player.corentHealth >= 0)
        {
            HeartUI.sprite = HeartSprites[player.corentHealth];
        }
    }

   
}
