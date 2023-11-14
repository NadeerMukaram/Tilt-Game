using UnityEngine;

public class AccelerometerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject player;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public AudioClip impactSound; // Assign your impact sound clip in the Inspector
    private AudioSource audioSource;

    void Start()
    {
        // Get or add an AudioSource component to the player object
        audioSource = player.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = player.AddComponent<AudioSource>();
        }

        // Assign the impact sound clip to the AudioSource
        audioSource.clip = impactSound;
    }

    void Update()
    {
        if (player != null)
        {
            float accelerationX = Input.acceleration.x;

            Vector3 movement = new Vector3(accelerationX, 0f, 0f);
            player.transform.position += movement * moveSpeed * Time.deltaTime;

            if (!IsGrounded())
            {
                Debug.Log("Player is in the air!");
            }
            else
            {
                Debug.Log("Player is on the ground!");

                // Check if the player has just landed (was in the air in the previous frame)
                if (!wasGroundedLastFrame)
                {
                    // Play the impact sound
                    audioSource.Play();
                }
            }

            // Update the grounded state for the next frame
            wasGroundedLastFrame = IsGrounded();
        }
        else
        {
            Debug.LogError("Player reference is null. Assign the player object in the Inspector.");
        }
    }

    bool IsGrounded()
    {
        float raycastDistance = 0.1f;

        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, raycastDistance, groundLayer);

        Debug.DrawRay(groundCheck.position, Vector2.down * raycastDistance, Color.red);

        return hit.collider != null;
    }

    // Variable to store the grounded state in the previous frame
    private bool wasGroundedLastFrame = false;
}
