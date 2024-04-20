using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHelper : MonoBehaviour
{
    /// <summary>
    /// Since the OpenSceneManager class is DontDestroyOnLoad, this class helps that class.
    /// </summary>
 
    public void NewGame(string sceneName)
    {
        OpenSceneManager.instance.isContinue = false;
        SceneManager.LoadScene(sceneName);
    } 

    public void ContinueGame(string sceneName)
    {
        OpenSceneManager.instance.isContinue = true;
        if (sceneName.Equals("Drawing"))
            OpenSceneManager.instance.sceneIndex = 0;
        if (sceneName.Equals("Painting"))
            OpenSceneManager.instance.sceneIndex = 1;
        

        SceneManager.LoadScene(sceneName);
    }
}
