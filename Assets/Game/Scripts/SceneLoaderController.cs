// Dogukan Kaan Bozkurt
//		github.com/dkbozkurt

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// </summary>

public class SceneLoaderController : MonoBehaviour
{
    public bool loadLevel=true;
    public string levelName;

    private void Awake()
    {
        if (loadLevel)
        {
            loadLevel = false;
            StartCoroutine(LoadScene());
        }
    }

    private void Update()
    {
        if (loadLevel)
        {
            //LoadingDone();
        }
    }

    private IEnumerator LoadScene()
    {
        var progress = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);

        while (!progress.isDone)
        {
            yield return null;
        }
        
        Debug.Log("Level loaded");
    }

    // Another version Of asyncLevelLoading
    private void LoadingDone()
    {
        var progress = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        progress.completed += (op) => Debug.Log("Level Loading Done!");
    }
    
    
}
