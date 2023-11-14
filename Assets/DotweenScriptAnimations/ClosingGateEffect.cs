using UnityEngine;
using DG.Tweening;

public class ClosingGateEffect : MonoBehaviour
{
    public Transform gate1;
    public Transform gate2;
    public Transform closingPoint;
    private Vector3 originalPosition1;
    private Vector3 originalPosition2;
    public float duration = 2f;

    // Singleton instance
    private static ClosingGateEffect instance;

    void Awake()
    {
        // Ensure only one instance of ClosingGateEffect exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this one
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Store the original positions
        originalPosition1 = gate1.position;
        originalPosition2 = gate2.position;
    }

    public void PlayClosingGateEffect()
    {
        // Use DOTween to animate the gates closing, opening, and resetting
        gate1.DOMove(closingPoint.position, duration).SetEase(Ease.Linear);
        gate2.DOMove(closingPoint.position, duration).SetEase(Ease.Linear)
            .OnComplete(() => OpenGate()); // Open the gate after closing
    }

    void OpenGate()
    {
        // Use DOTween to animate the gates opening
        gate1.DOMove(originalPosition1, duration).SetEase(Ease.Linear);
        gate2.DOMove(originalPosition2, duration).SetEase(Ease.Linear);
    }

    // Removed the OnComplete callback for ResetGates
    void ResetGates()
    {
        // Use DOTween to animate the gates back to their original positions
        gate1.DOMove(originalPosition1, duration).SetEase(Ease.Linear);
        gate2.DOMove(originalPosition2, duration).SetEase(Ease.Linear);
    }
}
