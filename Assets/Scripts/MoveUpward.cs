using UnityEngine;

public class MoveUpward : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as needed
    private GameObject player;
    private Rigidbody2D playerRb;

    void Start()
    {
        // Find the player object with the "Player" tag
        player = GameObject.FindGameObjectWithTag("Player");

        // Get the player's Rigidbody2D component
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player != null && playerRb != null)
        {
            // Check if the player is moving (using Rigidbody2D velocity)
            if (playerRb.velocity.magnitude > 0.1f)
            {
                // Move the object upwards based on player input
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
    }
}
