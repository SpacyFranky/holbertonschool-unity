﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public Rigidbody player;
    public CharacterController player;
    public float moveSpeed;
    public float jumpForce;
    
    private Vector3 moveDirection;
    public float gravityScale;
    public Transform pivot;
    public float rotateSpeed;

    public GameObject playerModel;


    //public CharacterController controller;
    public Animator anim;


    void Start()
    {
        player = GetComponent<CharacterController>();

    }

    void Update()
    {
        // Setting move direction vector
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1) * moveSpeed;
        moveDirection.y = yStore;
        
        // Making the player able to jump only on the ground
        if (player.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        // Applying move direction to player
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        player.Move(moveDirection * Time.deltaTime);

        // Move the player in different directions based on camera look direction
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }

        // Resets from the start line when player falls
        if (transform.position.y <= -30.0f)
        {
            transform.position = new Vector3(0.0f, 30.0f, 0.0f);
        }


        anim.SetBool("isGrounded", player.isGrounded);
        anim.SetFloat("speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
    }
}
