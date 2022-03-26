// Dogukan Kaan Bozkurt
//		github.com/dkbozkurt

using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Game.Scripts
{
    public class ShowSceneNumberBehaviour : MonoBehaviour
    {
        public static List<GameObject> Buttons { get; } = new List<GameObject>();
        private static GameObject TransitionStick { get ; set; }
        
        private void OnEnable()
        {
            AssignInitValues();
        }

        private void AssignInitValues()
        {
            for (int i = 1; i <= 3; i++)
            {
                Buttons.Add(transform.GetChild(i).gameObject);
            }
            
            TransitionStick = transform.GetChild(0).gameObject;
            TransitionStick.transform.localPosition= Buttons[0].transform.localPosition;
        }

        public static void TrasitionStickMove(string sceneName)
        {
            TransitionStick.transform.DOMove(Buttons[GetSceneNumber(sceneName) - 1].transform.position, 0.5f)
                .SetEase(Ease.Linear).OnComplete(() =>
                {
                    Buttons[GetSceneNumber(sceneName) - 1].transform.DOScale(Vector3.one * 0.7f, 0.2f).SetEase(Ease.Linear);
                });
        }

        public static void PreviousLevelButtonShrink(string sceneName)
        {
            Buttons[GetSceneNumber(sceneName) - 1].transform.DOScale(Vector3.one * 0.5f, 0.3f).SetEase(Ease.Linear);
        }

        private static int GetSceneNumber(string sceneName)
        {
            int sceneNum = int.Parse(sceneName.Substring(sceneName.Length - 1));
            return sceneNum;
        }
        
        
        
    }
}
