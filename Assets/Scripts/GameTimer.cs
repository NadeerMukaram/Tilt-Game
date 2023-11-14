using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.IO;

public class GameTimer : MonoBehaviour
{
    public float gameTimeInSeconds = 120f;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI timerText_Active;
    public Button restartButton;

    private float timeRemaining;
    private bool isGameActive = true;

    private CollisionHandler collisionHandler;
    private PlayerTimeHistory playerTimeHistory = new PlayerTimeHistory();

    [System.Serializable]
    public class TimeEntry
    {
        public string sceneName;
        public float timeRemaining;

        public TimeEntry(string name, float time)
        {
            sceneName = name;
            timeRemaining = time;
        }
    }

    public class PlayerTimeHistory
    {
        public List<TimeEntry> timeEntries = new List<TimeEntry>();
    }

    private void Start()
    {
        timeRemaining = gameTimeInSeconds;
        restartButton.gameObject.SetActive(false);

        // Find the CollisionHandler component in the scene.
        collisionHandler = FindObjectOfType<CollisionHandler>();

        // Load player time history from the JSON file (if it exists).
        LoadPlayerTimeHistory();
    }

    private void Update()
    {
        if (isGameActive)
        {
            if (collisionHandler.stageStatus)
            {
                isGameActive = false; // Stop the timer when stageStatus is true.
                timeRemaining = 0;
            }
            else
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerText();

                if (timeRemaining <= 0)
                {
                    isGameActive = false;
                    timeRemaining = 0;
                    HandleGameOverRestart();
                }
            }
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText_Active.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void HandleGameOver()
    {
        // Stop the game.
        Time.timeScale = 0;

        // Get the name of the active scene.
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        // Create a TimeEntry instance with scene name and time remaining.
        TimeEntry timeEntry = new TimeEntry(sceneName, timeRemaining);

        // Add the time entry to the player's time history.
        playerTimeHistory.timeEntries.Add(timeEntry);

        // Serialize the playerTimeHistory object to JSON.
        string jsonData = JsonUtility.ToJson(playerTimeHistory);

        // Construct the file path using Application.persistentDataPath
        string jsonFilePath = Path.Combine(Application.persistentDataPath, "playerTimeHistory.json");

        // Write the JSON data to the specified file path.
        File.WriteAllText(jsonFilePath, jsonData);

        // Activate the restart button.
        restartButton.gameObject.SetActive(true);
    }

    public void HandleGameOverRestart()
    {
        // Stop the game.
        Time.timeScale = 0;

        // Activate the restart button.
        restartButton.gameObject.SetActive(true);
    }

    public void LoadPlayerTimeHistory()
    {
        // Construct the file path using Application.persistentDataPath
        string jsonFilePath = Path.Combine(Application.persistentDataPath, "playerTimeHistory.json");

        // Check if the file exists before attempting to load it.
        if (File.Exists(jsonFilePath))
        {
            // Read the JSON data from the file.
            string jsonData = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON data to populate the playerTimeHistory object.
            playerTimeHistory = JsonUtility.FromJson<PlayerTimeHistory>(jsonData);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
