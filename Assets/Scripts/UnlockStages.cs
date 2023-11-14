using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockStages : MonoBehaviour
{
    private ButtonInteraction buttonInteraction;

    void Start()
    {
        buttonInteraction = FindObjectOfType<ButtonInteraction>();    
    }


    public void UnlockStage2Interactable()
    {
        // Unlock the stage2Interactable state
        buttonInteraction.SetInteractable(true, "stage2Interactable");
    }

    public void UnlockStage3Interactable()
    {
        // Unlock the stage3Interactable state
        buttonInteraction.SetInteractable(true, "stage3Interactable");
    }

    public void UnlockStage4Interactable()
    {
        // Unlock the stage3Interactable state
        buttonInteraction.SetInteractable(true, "stage4Interactable");
    }

    public void UnlockStage5Interactable()
    {
        // Unlock the stage3Interactable state
        buttonInteraction.SetInteractable(true, "stage5Interactable");
    }

    public void UnlockStage6Interactable()
    {
        // Unlock the stage3Interactable state
        buttonInteraction.SetInteractable(true, "stage6Interactable");
    }


}
