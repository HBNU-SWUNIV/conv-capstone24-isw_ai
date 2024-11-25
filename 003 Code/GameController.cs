using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Timer timer;

    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public float SaveAndReturnBestTime(float newTime)
    {
        float currentBestTime = PlayerPrefs.GetFloat("BestTime", float.MaxValue);

        if (newTime < currentBestTime || currentBestTime == float.MaxValue)
        {
            PlayerPrefs.SetFloat("BestTime", newTime);
            PlayerPrefs.Save();
            Debug.Log($"New Best Time saved: {newTime}");
            return newTime;
        }

        Debug.Log($"Best Time remains unchanged: {currentBestTime}");
        return currentBestTime;
    }

    public void OnBackButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void Start()
    {
        float bestTime = PlayerPrefs.GetFloat("BestTime", float.MaxValue);
        Debug.Log($"Loaded BestTime: {bestTime}");

        if (bestTime == float.MaxValue)
        {
            Debug.Log("No previous BestTime found. This is the first play.");
        }
        else
        {
            Debug.Log($"BestTime found: {bestTime}");
        }
    }
}
