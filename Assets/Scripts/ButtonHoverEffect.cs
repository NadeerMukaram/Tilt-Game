using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button button;
    private Vector3 originalScale;

    void Start()
    {
        button = GetComponent<Button>();
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Scale up on hover
        transform.DOScale(originalScale * 1.1f, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Return to original scale when not hovered
        transform.DOScale(originalScale, 0.3f);
    }
}
