using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController_1 : MonoBehaviour
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
    var hInput = Input.GetKey(KeyCode.J) ? -1 : (Input.GetKey(KeyCode.L) ? 1 : 0); // Get the horizontal input
    var vInput = Input.GetKey(KeyCode.I) ? 1 : 0;  // Get the vertical input

    if (characterController.isGrounded)
    {
        // Check if moving forward or not before applying movement
        if (vInput != 0)
        {
            // Move forward if "I" key is pressed
            moveVelocity = transform.forward * speed * vInput;
        }
        else
        {
            // Stop moving if "I" key is not pressed
            moveVelocity = Vector3.zero;
        }

        turnVelocity = transform.up * rotationSpeed * hInput;
        
        // Change condition to check for "K" key for jump
        if (Input.GetKeyDown(KeyCode.K))
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

