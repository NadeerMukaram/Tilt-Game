using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject prefabToSpawn; // Drag and drop the prefab in the Inspector

    void Start()
    {
        if (prefabToSpawn != null)
        {
            // Spawn the prefab at the current position of this GameObject
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Prefab is not assigned. Please assign a prefab in the Inspector.");
        }
    }
}
