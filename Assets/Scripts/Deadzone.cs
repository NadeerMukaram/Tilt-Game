using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    // Reference to the GameTimer script
    private GameTimer gameTimer;

    private void Start()
    {
        // Find and assign the GameTimer script in the scene
        gameTimer = FindObjectOfType<GameTimer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision involves an object with the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            // Perform your desired action here, for example:
            Debug.Log("Nice!");

            // Call the HandleGameOver() method from the GameTimer script
            if (gameTimer != null)
            {
                gameTimer.HandleGameOverRestart();
            }
        }
    }
}
