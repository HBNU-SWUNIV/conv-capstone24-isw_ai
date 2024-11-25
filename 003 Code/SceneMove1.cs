using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMove1 : MonoBehaviour
{
    public void LoadingNewScene()
    {
        SceneManager.LoadScene("Start");
    }

}