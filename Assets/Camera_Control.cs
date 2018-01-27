﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour {

     public float minX;
    public float maxY;
    public float maxX;
    public float minY;

    public Transform pusher;

    float pushY;
    float pushX;

    public Vector2 PushOffset;
    [Range (0,1)]
    public float pushP;


    float mapX = 3512/4;
    float mapY = 1436/4;
       




	// Use this for initialization
	void Initialize () {

        var vertExten = Camera.main.orthographicSize;
        var horiExten = vertExten * Screen.width/Screen.height;

         maxX = mapX/2 - horiExten;
         maxY = mapY/2 - vertExten;

         minX = horiExten - mapX/2 ;
         minY = vertExten - mapY/2;

        pushY = pushP * vertExten;
        pushX = pushP * horiExten;


        //print(vertExten + "    " + horiExten);
       // print(minX + " MIN X " + minY + " MIN Y " + maxX + " Max X " + maxY + " maxY ");
        

    }

    
    private void Start()
    {
        Initialize();
    }

    private void Awake()
    {
        Initialize();
    }



    // Update is called once per frame
    void LateUpdate () {

        Initialize();
        var cameraP = transform.position;


        if (pusher.position.x > transform.position.x + pushX/2)
        {
            cameraP.x += pusher.position.x - (transform.position.x + pushX / 2);
        }

        if (pusher.position.x < transform.position.x - pushX / 2)
        {
            cameraP.x += pusher.position.x - (transform.position.x - pushX / 2);
        }

        if (pusher.position.y > transform.position.y + pushY / 2)
        {
            cameraP.y += pusher.position.y - (transform.position.y + pushY / 2);
        }

        if (pusher.position.y < transform.position.y - pushY / 2)
        {
            cameraP.y += pusher.position.y - (transform.position.y - pushY / 2);
        }



        cameraP.x = Mathf.Clamp(cameraP.x, minX, maxX);
        cameraP.y = Mathf.Clamp(cameraP.y, minY, maxY);
        transform.position = cameraP;




    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector2.zero, new Vector2(mapX, mapY));
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(Vector2.zero, new Vector2(maxX - minX, maxY - minY));
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position - (Vector3)PushOffset, new Vector2(pushX, pushY));
    }


}
