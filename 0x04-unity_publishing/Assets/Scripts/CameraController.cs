﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Public variable to store a reference to the player game object
    public GameObject player;

    //Private variable to store the offset distance between the player and camera
    private Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
}
