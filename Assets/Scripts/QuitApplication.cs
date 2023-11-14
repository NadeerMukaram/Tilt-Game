using UnityEngine;
using UnityEngine.UI;

public class QuitApplication : MonoBehaviour
{
    // Reference to the button
    public Button quitButton;

    void Start()
    {
        // Add a listener to the button's click event
        quitButton.onClick.AddListener(Quit);
    }

    // Function to quit the application
    void Quit()
    {
        Debug.Log("Quit action.");
        Application.Quit();
    }
}
