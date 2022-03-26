// Dogukan Kaan Bozkurt
//		github.com/dkbozkurt

using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Game.Scripts
{
    public class ShowSceneNumberBehaviour : MonoBehaviour
    {
        private static List<GameObject> _buttons = new List<GameObject>();
        private static GameObject _transitionStick;

        public static GameObject TransitionStick
        {
            get => _transitionStick;
            set => _transitionStick = value;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                GetSceneNumber("Scene2");
            }
        }

        private void OnEnable()
        {
            AssignInitValues();
        }

        private void AssignInitValues()
        {
            for (int i = 1; i <= 3; i++)
            {
                _buttons.Add(transform.GetChild(i).gameObject);
            }
            
            TransitionStick = transform.GetChild(0).gameObject;
            TransitionStick.transform.localPosition= _buttons[0].transform.localPosition;
        }

        public static void TrasitionStickMove(string sceneName)
        {
            TransitionStick.transform.DOMove(_buttons[GetSceneNumber(sceneName) - 1].transform.position, 0.5f)
                .SetEase(Ease.Linear).OnComplete(() =>
                {
                    //_buttons[GetSceneNumber(SceneLoaderController._lastLoadedScene)-1].transform.Do
                    _buttons[GetSceneNumber(sceneName) - 1].transform.DOScale(Vector3.one * 0.7f, 0.2f).SetEase(Ease.Linear);
                });
        }

        private static int GetSceneNumber(string sceneName)
        {
            int sceneNum = int.Parse(sceneName.Substring(sceneName.Length - 1));
            Debug.Log(sceneNum);
            return sceneNum;
        }
        
        
        
    }
}
