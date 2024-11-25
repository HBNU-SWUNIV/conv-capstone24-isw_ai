using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public float delayBeforeSceneLoad = 2f; // �� ��ȯ �� ��� �ð�

    public void LoadingNewScene()
    {
        StartCoroutine(LoadSceneWithDelay("map1"));
    }

    private IEnumerator LoadSceneWithDelay(string sceneName)
    {
        yield return new WaitForSeconds(delayBeforeSceneLoad); // ������ �ð� ���� ���
        SceneManager.LoadScene(sceneName); // �� ��ȯ
    }
}
