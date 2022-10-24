using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        // Load new scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
