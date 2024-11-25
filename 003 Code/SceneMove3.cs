using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove3 : MonoBehaviour
{
    public float delayBeforeSceneLoad = 2f; // �� ��ȯ �� ��� �ð�

    public void LoadingNewScene()
    {
        StartCoroutine(LoadSceneWithDelay("EUNSIL_FANTASY1"));
    }

    private IEnumerator LoadSceneWithDelay(string sceneName)
    {
        yield return new WaitForSeconds(delayBeforeSceneLoad); // ������ �ð� ���� ���
        SceneManager.LoadScene(sceneName); // �� ��ȯ
    }
}

