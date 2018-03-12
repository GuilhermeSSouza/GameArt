using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{




    private Vector3 velocity;
    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject player;

    public bool bounds;

    public Vector3 minCamemraPos;
    public Vector3 maxCameraPos;


    // Use this for initialization
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");


    }
    private void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
        
        transform.position = new Vector3(posX, posY, transform.position.z);

        if (bounds) {


            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCamemraPos.x, maxCameraPos.x), Mathf.Clamp(transform.position.y, minCamemraPos.y, maxCameraPos.y), Mathf.Clamp(transform.position.z, minCamemraPos.z, maxCameraPos.z));
                
                
                
                }



    }




}
