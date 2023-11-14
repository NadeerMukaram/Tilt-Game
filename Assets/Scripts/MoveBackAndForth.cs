using UnityEngine;

public class MoveBackAndForth : MonoBehaviour
{
    public Transform endPosition;
    public float speed = 2f;

    private Vector3 startPosition;
    private PolygonCollider2D myCollider;
    private bool isFlipped = false;

    void Start()
    {
        startPosition = transform.position;
        myCollider = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1f);
        transform.position = Vector3.Lerp(startPosition, endPosition.position, t);

        // Check if the object has reached the end position
        if (t > 0.99f && !isFlipped)
        {
            // Flip the scale along the X-axis
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            isFlipped = true;
        }
        else if (t < 0.01f && isFlipped)
        {
            // Reset the scale to its original state
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            isFlipped = false;
        }

        // Update the collider offset to match the sprite offset
        myCollider.offset = new Vector2(-myCollider.offset.x, myCollider.offset.y);
    }
}
