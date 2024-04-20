using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSceneManager : MonoBehaviour
{
    public static OpenSceneManager instance;
    public bool isContinue;
    public int sceneIndex;
    
    /// <summary>
    /// It works when you first enter the game and can be used in other scenes with DontDestroyOnLoad.
    /// This way we know which scene to save.
    /// </summary>

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

   

    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }





}
