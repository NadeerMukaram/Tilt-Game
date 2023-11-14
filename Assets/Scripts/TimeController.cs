using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    public TextMeshProUGUI timeStatusText;

    private bool isTimeFrozen = true;

    void Start()
    {
        // Freeze time at the start
        ToggleTime();
    }

    void Update()
    {
        // Check for input to toggle time freezing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleTime();
        }
    }

    public void ToggleTime()
    {
        // Toggle between freezing and unfreezing time
        isTimeFrozen = !isTimeFrozen;

        if (isTimeFrozen)
        {
            // Freeze time
            Time.timeScale = 0f;
            timeStatusText.text = "UNFREEZE SCREEN";
        }
        else
        {
            // Unfreeze time
            Time.timeScale = 1f;
            timeStatusText.text = "FREEZE SCREEN";
        }
    }
}
