using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDetect1 : MonoBehaviour
{
    private int score1 = 0; // Score for Player One
    private bool isInCollider = false; // Track whether the player is in the collider

    // OnTriggerEnter is called when another collider enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player_2"))
        {
            isInCollider = true;
        }
    }

    // OnTriggerExit is called when another collider leaves the trigger
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player_2"))
        {
            if (isInCollider)
            {
                score1++;   // Increment the score for Player One      
                Debug.Log("Player One Score: " + score1); // Log the current score
            }
            isInCollider = false;
        }
    }
}