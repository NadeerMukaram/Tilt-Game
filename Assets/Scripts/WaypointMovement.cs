using System.Collections;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    public Transform waypoint1;
    public Transform waypoint2;
    public Transform waypoint3;

    private void Start()
    {
        StartCoroutine(MoveToRandomWaypoint());
    }

    IEnumerator MoveToRandomWaypoint()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(4f, 5f));

            // Choose a random waypoint
            Transform randomWaypoint = GetRandomWaypoint();

            // Move the object to the chosen waypoint
            StartCoroutine(MoveObject(transform, randomWaypoint.position, 2f));
        }
    }

    IEnumerator MoveObject(Transform obj, Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = obj.position;

        while (time < duration)
        {
            obj.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        obj.position = targetPosition;
    }

    Transform GetRandomWaypoint()
    {
        int randomIndex = Random.Range(0, 3);
        switch (randomIndex)
        {
            case 0:
                return waypoint1;
            case 1:
                return waypoint2;
            case 2:
                return waypoint3;
            default:
                return waypoint1;
        }
    }
}
