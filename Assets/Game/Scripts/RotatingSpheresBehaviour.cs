// Dogukan Kaan Bozkurt
//		github.com/dkbozkurt

using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 
/// </summary>

namespace Game.Scripts
{
    public class RotatingSpheresBehaviour : MonoBehaviour
    {
        public static bool canRotate;
        private static Transform galaxyTransform;
        [SerializeField] private List<GameObject> planets = new List<GameObject>();
        public static bool endSceneTwo;

        private void OnEnable()
        {
            AssignInitValues();
            FadeIn();
        }

        private void Update()
        {
            if (endSceneTwo)
            {
                FadeOutUnselectedSpheres();
            }
        }

        private void AssignInitValues()
        {
            canRotate = true;
            endSceneTwo = false;
            transform.localScale = Vector3.zero;
            galaxyTransform = GetComponent<Transform>();
        }
        
        private void FadeIn()
        {
            transform.DOScale(Vector3.one, 0.7f);
        }

        private void FadeOutUnselectedSpheres()
        {
            endSceneTwo = false;
            foreach (GameObject child in planets)
            {
                child.transform.parent = null;
                
                if (child.tag != "SelectedPlanet")
                {
                    child.transform.DOScale(Vector3.zero, 0.7f).SetEase(Ease.Linear);
                }
            }
        }

        public static void ClickedSphereFocus(GameObject clickedSphere)
        {
            clickedSphere.transform.DOMove(Vector3.zero, 0.7f).SetEase(Ease.Linear).OnComplete(() =>
            {
                SceneLoaderController.UnLoadScene(SceneName.Scene2.ToString(),SceneLoaderController.scene2Loaded);
                SceneLoaderController.LoadScene(SceneName.Scene3.ToString(),SceneLoaderController.scene3Loaded);
            });

        }

        public static void NonSelectedFocus()
        {
            var autoSelectedPlanet =GameObject.Find("BigSphere");
            autoSelectedPlanet.tag = "SelectedPlanet";
            endSceneTwo = true;
            SceneLoaderController.UnLoadScene(SceneName.Scene2.ToString(),SceneLoaderController.scene2Loaded);

        }
        
    }
}

