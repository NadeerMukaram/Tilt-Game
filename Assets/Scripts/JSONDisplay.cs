using UnityEngine;
using TMPro;
using System.IO;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class TimeEntry
{
    public string sceneName;
    public float timeRemaining;
}

[System.Serializable]
public class TimeHistory
{
    public List<TimeEntry> timeEntries;
}

[System.Serializable]
public class FormattedTimeEntry
{
    public string sceneName;
    public string formattedTime;
    public float timeInSeconds;
}

public class JSONDisplay : MonoBehaviour
{
    private string jsonFileName = "playerTimeHistory.json";
    private string jsonFilePath;

    public TextMeshProUGUI textDisplay;

    private void Start()
    {
        if (textDisplay == null)
        {
            Debug.LogError("Please assign the TextMeshProUGUI reference in the inspector.");
            return;
        }

        jsonFilePath = Path.Combine(Application.persistentDataPath, jsonFileName);
        LoadFormatAndDisplayJSON();
    }

    private void LoadFormatAndDisplayJSON()
    {
        if (File.Exists(jsonFilePath))
        {
            string jsonData = File.ReadAllText(jsonFilePath);
            TimeHistory timeHistory = JsonUtility.FromJson<TimeHistory>(jsonData);

            // Create a dictionary to store the fastest time for each stage
            Dictionary<string, FormattedTimeEntry> fastestTimes = new Dictionary<string, FormattedTimeEntry>();

            for (int i = 0; i < timeHistory.timeEntries.Count; i++)
            {
                float timeRemaining = timeHistory.timeEntries[i].timeRemaining;

                if (timeRemaining > 0)
                {
                    int minutes = Mathf.FloorToInt(timeRemaining / 60);
                    int seconds = Mathf.FloorToInt(timeRemaining % 60);
                    string sceneName = timeHistory.timeEntries[i].sceneName;
                    string formattedTime = $"{sceneName}: {minutes}:{seconds:00}";
                    float timeInSeconds = minutes * 60 + seconds;

                    // Check if the stage already has a recorded time
                    if (fastestTimes.ContainsKey(sceneName))
                    {
                        // If the new time is faster, update the entry
                        if (timeInSeconds > fastestTimes[sceneName].timeInSeconds)
                        {
                            fastestTimes[sceneName] = new FormattedTimeEntry
                            {
                                sceneName = sceneName,
                                formattedTime = formattedTime,
                                timeInSeconds = timeInSeconds
                            };
                        }
                    }
                    else
                    {
                        // If the stage is not in the dictionary, add the entry
                        fastestTimes.Add(sceneName, new FormattedTimeEntry
                        {
                            sceneName = sceneName,
                            formattedTime = formattedTime,
                            timeInSeconds = timeInSeconds
                        });
                    }
                }
            }

            // Convert dictionary values to a list and sort by stage number and timeInSeconds in ascending order
            List<FormattedTimeEntry> formattedTimeEntries = fastestTimes.Values
                .OrderBy(entry => GetStageNumber(entry.sceneName))
                .ThenBy(entry => entry.timeInSeconds)
                .ToList();

            // Display the formatted time entries or an error message
            if (formattedTimeEntries.Count > 0)
            {
                List<string> sortedEntries = formattedTimeEntries.Select(entry => entry.formattedTime).ToList();
                string formattedData = string.Join("\n", sortedEntries);
                textDisplay.text = formattedData;
            }
            else
            {
                textDisplay.text = "No entries with time remaining found.";
            }
        }
        else
        {
            Debug.LogError("JSON file not found at the specified path: " + jsonFilePath);
        }
    }

    private int GetStageNumber(string sceneName)
    {
        // Assuming the sceneName is in the format "Stage X"
        // Extract the stage number and parse it as an integer
        string[] splitName = sceneName.Split(' ');
        if (splitName.Length == 2 && int.TryParse(splitName[1], out int stageNumber))
        {
            return stageNumber;
        }

        // If parsing fails, return a large number to ensure it comes last in the sorting
        return int.MaxValue;
    }
}
