using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float speed = 3; //variables for speed, rotation speed, gravity and jump speed
    public float rotationSpeed = 90;
    public float gravity = -10f;
    public float jumpSpeed = 15;

    CharacterController characterController;
    Vector3 moveVelocity;
    Vector3 turnVelocity;

    void Awake()
    {
        characterController = GetComponent<CharacterController>(); // Get the CharacterController component
    }

    void Update()
    {
        var hInput = Input.GetAxis("Horizontal"); // Get the horizontal input
        var vInput = Input.GetAxis("Vertical");  // Get the vertical input

        if (characterController.isGrounded)
        {
            // Check if moving forward or not before applying movement
            if (vInput > 0)
            {
                moveVelocity = transform.forward * speed * vInput;
            }
            else if (vInput < 0)
            {
                // Prevent backward movement
                moveVelocity = Vector3.zero;
            }

            turnVelocity = transform.up * rotationSpeed * hInput;
            
            // Change condition to check for "s" key for jump
            if (Input.GetKeyDown(KeyCode.S))
            {
                moveVelocity.y = jumpSpeed;
            }
        }

        //Adding gravity
        moveVelocity.y += gravity * Time.deltaTime;
        characterController.Move(moveVelocity * Time.deltaTime);
        transform.Rotate(turnVelocity * Time.deltaTime);
    }
}

