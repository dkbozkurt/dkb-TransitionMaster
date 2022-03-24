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

public enum SceneName
{
    Scene1,
    Scene2,
    Scene3,
}
public class SceneLoaderController : MonoBehaviour
{
    public SceneName sceneName;
    
    private static bool _shouldLoadNext; 
    private static bool _sceneIsLoaded = false;
    
    private static string _lastLoadedScene;

    private static List<bool> _loadedSceneIndex= new List<bool>();

    private void Awake()
    {
        sceneName = SceneName.Scene1;
        _shouldLoadNext = false;
    }

    private void OnEnable()
    {
        LoadScene(sceneName.ToString());
        _lastLoadedScene = sceneName.ToString();
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            //UnLoadScene(_lastLoadedScene);
            TitleBehaviour.FadeOut();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            LoadScene(sceneName.ToString());
        }

        // Accessing levels by using keyboard numbers.
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            SceneDecider(SceneName.Scene1.ToString());
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            SceneDecider(SceneName.Scene2.ToString());
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            SceneDecider(SceneName.Scene3.ToString());
        }
    }
    
    public void SceneDecider(string sceneCode)
    {
        if(_lastLoadedScene != sceneCode)
        {
            switch (sceneCode)
            {
                case "Scene1":
                    sceneName = SceneName.Scene1;
                    
                    break;
                case "Scene2":
                    sceneName = SceneName.Scene2;
                    _shouldLoadNext = true;
                    _sceneIsLoaded = false;
                    TitleBehaviour.FadeOut();
                    break;
            
                case "Scene3":
                    sceneName = SceneName.Scene3;
                    break;
            }
            
        }
    }
    
    public static void LoadScene(string sceneName)
    {
        if (!_sceneIsLoaded)
        {
            var progress = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            progress.completed += (op) =>
            {
                _sceneIsLoaded = true;
                if (_shouldLoadNext) UnLoadScene(_lastLoadedScene);
                _lastLoadedScene = sceneName;
                
                Debug.Log("Level Loaded!");
            };
        }
        
    }

    #region Load level with coroutine

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        
        var progress = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        while (!progress.isDone)
        {
            yield return null;
        }
        
        Debug.Log("Level loaded");
    }


    #endregion 
    
    public static void UnLoadScene(string sceneName)
    {
        if (_sceneIsLoaded)
        {
            var progress = SceneManager.UnloadSceneAsync(sceneName);
            progress.completed += (op) =>
            {
                _sceneIsLoaded = false;
                if (_shouldLoadNext) _shouldLoadNext = false;
                Debug.Log("Level Unloaded!");
            };
        }
        
    }


}