using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectAnimator : MonoBehaviour
{
    public Vector3 minScale = new Vector3(1f, 1f, 1f);
    public Vector3 maxScale = new Vector3(1.5f, 1.5f, 1.5f);
    public float duration = 1.5f;

    void Start()
    {
        // Start the random hype animation
        PlayRandomHypeAnimation();
    }

    void PlayRandomHypeAnimation()
    {
        // Use DOTween to animate the object's scale randomly
        transform.DOScale(GetRandomScale(), duration)
            .SetEase(Ease.OutElastic)
            .OnComplete(() => PlayRandomHypeAnimation()); // Repeat the animation
    }

    Vector3 GetRandomScale()
    {
        // Generate a random scale within the specified range
        float randomX = Random.Range(minScale.x, maxScale.x);
        float randomY = Random.Range(minScale.y, maxScale.y);
        float randomZ = Random.Range(minScale.z, maxScale.z);

        return new Vector3(randomX, randomY, randomZ);
    }
}
