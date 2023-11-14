using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastStageUnlocked : MonoBehaviour
{
    private ButtonInteraction buttonInteraction;

    void Start()
    {
        buttonInteraction = FindObjectOfType<ButtonInteraction>();
    }

    void Update()
    {
        // Unlock the stage3Interactable state
        buttonInteraction.SetInteractable(true, "stage6Interactable");

    }

}
