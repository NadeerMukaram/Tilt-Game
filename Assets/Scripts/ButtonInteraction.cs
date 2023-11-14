using UnityEngine;
using UnityEngine.UI;

public class ButtonInteraction : MonoBehaviour
{
    public Button stage2;
    public Button stage3;
    public Button stage4;
    public Button stage5;
    public Button stage6;


    public static ButtonInteraction Instance;

    private void Awake()
    {
        //if (Instance == null)
        //{
        //    Instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    private void Start()
    {
        // Set the initial interactable state based on the 'stage2Interactable' variable stored in PlayerPrefs
        bool stage2Interactable = PlayerPrefs.GetInt("stage2Interactable", 0) == 1;
        stage2.interactable = stage2Interactable;

        // Set the initial interactable state for stage 3 based on the 'stage3Interactable' variable stored in PlayerPrefs
        bool stage3Interactable = PlayerPrefs.GetInt("stage3Interactable", 0) == 1;
        stage3.interactable = stage3Interactable;

        // Set the initial interactable state for stage 3 based on the 'stage3Interactable' variable stored in PlayerPrefs
        bool stage4Interactable = PlayerPrefs.GetInt("stage4Interactable", 0) == 1;
        stage4.interactable = stage4Interactable;

        // Set the initial interactable state for stage 3 based on the 'stage3Interactable' variable stored in PlayerPrefs
        bool stage5Interactable = PlayerPrefs.GetInt("stage5Interactable", 0) == 1;
        stage5.interactable = stage5Interactable;

        // Set the initial interactable state for stage 3 based on the 'stage3Interactable' variable stored in PlayerPrefs
        bool stage6Interactable = PlayerPrefs.GetInt("stage6Interactable", 0) == 1;
        stage6.interactable = stage6Interactable;

    }

    public void SetInteractable(bool interactable, string interactableKey)
    {
        // Set the specified interactable variable and store it in PlayerPrefs
        int interactableValue = interactable ? 1 : 0;
        PlayerPrefs.SetInt(interactableKey, interactableValue);
        PlayerPrefs.Save();

        // Update the button's interactable state based on the key
        if (interactableKey == "stage2Interactable")
        {
            stage2.interactable = interactable;
        }
        else if (interactableKey == "stage3Interactable")
        {
            stage3.interactable = interactable;
        }
        else if (interactableKey == "stage4Interactable")
        {
            stage4.interactable = interactable;
        }
        else if (interactableKey == "stage5Interactable")
        {
            stage5.interactable = interactable;
        }
        else if (interactableKey == "stage6Interactable")
        {
            stage6.interactable = interactable;
        }
    }
}
