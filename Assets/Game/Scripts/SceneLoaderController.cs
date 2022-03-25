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

namespace Game.Scripts
{ 
    public enum SceneName
    {
        Scene1,
        Scene2,
        Scene3,
    }
    
    public class SceneLoaderController : MonoBehaviour
    {
        public SceneName sceneName;

        #region Booleans to check is the stated scene is loaded
        
        public static bool scene1Loaded = false;
        public static bool scene2Loaded = false;
        public static bool scene3Loaded = false;

        #endregion
      
        private static string _lastLoadedScene;
        
        private void OnEnable()
        {
            LoadScene(sceneName.ToString(),scene1Loaded);
            _lastLoadedScene = sceneName.ToString();
        }
    
        private void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.A))
            {
                TitleBehaviour.FadeOut();
            }
    
            if (Input.GetKeyDown(KeyCode.D))
            {
                LoadScene(sceneName.ToString(),scene2Loaded);
            }

            #region Accessing levels by using keyboard numbers.

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

            #endregion

            if (Input.GetKeyDown(KeyCode.K))
            {
                Debug.Log("last loaded scene is " + _lastLoadedScene);
            }

        }
        
        public void SceneDecider(string sceneCode)
        {
            if(_lastLoadedScene != sceneCode)
            {
                LastSceneFadeOutOperations(_lastLoadedScene);
                switch (sceneCode)
                {
                    case "Scene1":
                        sceneName = SceneName.Scene1;
                        LoadScene(sceneCode, scene1Loaded);

                        break;
                    case "Scene2":
                        sceneName = SceneName.Scene2;
                        LoadScene(sceneCode,scene2Loaded);
                        break;
                
                    case "Scene3":
                        sceneName = SceneName.Scene3;
                        LoadScene(sceneCode,scene3Loaded);
                        break;
                }
                
                
                Debug.Log(_lastLoadedScene + "loast Loaded scene is");
                
            }
        }
        
        public static void LoadScene(string sceneName,bool sceneIsLoaded)
        {
            if (!sceneIsLoaded)
            {
                var progress = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
                progress.completed += (op) =>
                {
                    SceneLoaderSetter(sceneName,true);
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
        
        public static void UnLoadScene(string sceneName,bool sceneIsLoaded)
        {
            if (sceneIsLoaded)
            {
                var progress = SceneManager.UnloadSceneAsync(sceneName);
                progress.completed += (op) =>
                {
                    SceneLoaderSetter(sceneName,false);
                    _lastLoadedScene = sceneName;
                    Debug.Log("Level Unloaded!");
                };
            }
            
        }

        private static void SceneLoaderSetter(string sceneName,bool status)
        {
            if (sceneName == SceneName.Scene1.ToString()) scene1Loaded = status;
            
            if (sceneName == SceneName.Scene2.ToString()) scene2Loaded = status;
            
            if (sceneName == SceneName.Scene3.ToString()) scene3Loaded = status;
        }

        private static void LastSceneFadeOutOperations(string sceneToFadeOut)
        {
            switch (sceneToFadeOut)
            {
                case "Scene1":
                    TitleBehaviour.FadeOut();
                    break;
                
                case "Scene2":
                    Debug.Log("Fade Out of Scene 2");
                    break;
                
                case "Scene3":
                    Debug.Log("Fade Out of Scene 3");
                    break;
                    
                
            }
        }

    }   
}