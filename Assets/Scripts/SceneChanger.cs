using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneChanger : MonoBehaviour
{
    public string sceneToLoad;

    private ClosingGateEffect closingGateEffect;

    public void Start()
    {
        closingGateEffect = FindObjectOfType<ClosingGateEffect>();
    }

    public void ChangeScene()
    {
        // Unfreeze the game by setting Time.timeScale back to 1.
        Time.timeScale = 1;

        closingGateEffect.PlayClosingGateEffect();

        // Start a coroutine to introduce a delay before loading the scene
        StartCoroutine(LoadSceneWithDelay());

    }

    private System.Collections.IEnumerator LoadSceneWithDelay()
    {
        // Wait for 3 seconds
        yield return new WaitForSeconds(1f);

        // Load the specified scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
