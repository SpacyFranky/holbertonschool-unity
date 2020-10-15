using System.Collections;
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
        
        // Checks if player can jump on the ground or not in the air
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

        // Resets from the start line when player falls
        if (transform.position.y <= -20f)
        {
            transform.position = new Vector3(0.0f, 30.0f, 0.0f);
        }
    }
}
