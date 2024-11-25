using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove3 : MonoBehaviour
{
    public float delayBeforeSceneLoad = 2f; // 씬 전환 전 대기 시간

    public void LoadingNewScene()
    {
        StartCoroutine(LoadSceneWithDelay("EUNSIL_FANTASY1"));
    }

    private IEnumerator LoadSceneWithDelay(string sceneName)
    {
        yield return new WaitForSeconds(delayBeforeSceneLoad); // 지정된 시간 동안 대기
        SceneManager.LoadScene(sceneName); // 씬 전환
    }
}

