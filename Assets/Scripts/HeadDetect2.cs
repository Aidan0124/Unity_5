using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadDetect2 : MonoBehaviour
{
    private int score2 = 0; // Score for Player One
    private bool isInCollider = false; // Track whether the player is in the collider

    // OnTriggerEnter is called when another collider enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player_1"))
        {
            isInCollider = true;
        }
    }

    // OnTriggerExit is called when another collider leaves the trigger
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player_1"))
        {
            if (isInCollider)
            {
                score2++;   // Increment the score for Player One      
                Debug.Log("Player Two Score: " + score2); // Log the current score
            }
            isInCollider = false;
        }
    }
}
