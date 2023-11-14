using System;
using System.Collections.Generic;
using UnityEngine; // Add this using directive

[Serializable]
public class PlayerTimeHistory
{
    public List<float> timeEntries = new List<float>();

    public List<string> GetFormattedTimeEntries()
    {
        List<string> formattedTimeEntries = new List<string>();
        foreach (float timeInSeconds in timeEntries)
        {
            int minutes = Mathf.FloorToInt(timeInSeconds / 60);
            int seconds = Mathf.FloorToInt(timeInSeconds % 60);
            formattedTimeEntries.Add(string.Format("{0:00}:{1:00}", minutes, seconds));
        }
        return formattedTimeEntries;
    }
}
