using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyController : MonoBehaviour
{
    public static DontDestroyController instancetwo;

    private void Awake()
    {
        if (instancetwo == null)
        {
            instancetwo = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Check if the current scene is named "Menu"
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            // Destroy the object if the scene is "Menu"
            Destroy(gameObject);
        }
    }
}
