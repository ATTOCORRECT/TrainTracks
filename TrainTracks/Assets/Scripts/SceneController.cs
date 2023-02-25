using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string nextSceneName;
    public string previousSceneName;

    public void NextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
    public void PreviousScene()
    {
        SceneManager.LoadScene(previousSceneName);
    }
}
