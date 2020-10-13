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
    public bool isGrounded;

    void Start()
    {
        //player = GetComponent<Rigidbody>();
        player = GetComponent<CharacterController>();
    }

    void Update()
    {
        //player.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, player.velocity.y, Input.GetAxis("Vertical") * moveSpeed);

        /*if (Input.GetButtonDown("Jump"))
        {
            player.velocity = new Vector3(player.velocity.x, jumpForce, player.velocity.z);
        }*/

        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1) * moveSpeed;
        moveDirection.y = yStore;
        
        if (player.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        player.Move(moveDirection * Time.deltaTime);

        if (transform.position.y <= -20f)
        {
            transform.position = new Vector3(0.0f, 30.0f, 0.0f);
        }
    }
}
