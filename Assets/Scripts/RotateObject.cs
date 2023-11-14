using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private float delayTimer;
    private float rotationTimer;
    private float rotationIntervalMin = 4.0f;  // Minimum time between rotations
    private float rotationIntervalMax = 7.0f;  // Maximum time between rotations
    private bool rotationStarted = false;

    void Start()
    {
        // Initialize the delay timer with a random value between 0 to 3 seconds.
        delayTimer = Random.Range(0.0f, 3.0f);
    }

    void Update()
    {
        if (!rotationStarted)
        {
            // Update the delay timer.
            delayTimer -= Time.deltaTime;

            if (delayTimer <= 0)
            {
                // The delay timer has finished; start the rotation.
                rotationStarted = true;
                rotationTimer = Random.Range(rotationIntervalMin, rotationIntervalMax);
            }
        }
        else
        {
            // Update the rotation timer.
            rotationTimer -= Time.deltaTime;

            // Check if it's time to rotate.
            if (rotationTimer <= 0)
            {
                // Randomly choose to rotate on the X-axis or Y-axis.
                if (Random.Range(0, 2) == 0)
                {
                    // Rotate on the Y-axis by 180 degrees.
                    transform.Rotate(Vector3.up, 180.0f);
                }
                else
                {
                    // Rotate on the X-axis by 180 degrees.
                    transform.Rotate(Vector3.right, 180.0f);
                }

                // Set a new random rotation interval.
                rotationTimer = Random.Range(rotationIntervalMin, rotationIntervalMax);
            }
        }
    }
}
