// Dogukan Kaan Bozkurt
//		github.com/dkbozkurt

using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>

namespace Game.Scripts
{
    public class TitleBehaviour : MonoBehaviour
    {
        private static RectTransform _titleRectTransform;
        private static TextMeshProUGUI _titleTMP;
        private static Camera _cam;
        private static float _delayTime = 0.7f;
    
        private void OnEnable()
        {
            InitTitle();
            FadeIn();
        }
    
        private void InitTitle()
        {
            _titleRectTransform = GetComponent<RectTransform>();
            _titleRectTransform.localScale = Vector3.zero;
            _titleTMP = GetComponent<TextMeshProUGUI>();
            _cam = Camera.main;
        }
        private void FadeIn()
        {
            _titleRectTransform.DOScale(new Vector3(5, 5,0), 1.5f).SetEase(Ease.Linear);
        }

        public static void FadeOut()
        {
            var sequence = DOTween.Sequence();

            _cam.DOColor(Color.white, _delayTime).SetEase(Ease.Linear);
            _titleTMP.DOFade(0, _delayTime).SetEase(Ease.Linear);
            _titleRectTransform.DOScale(new Vector3(600, 600,0), _delayTime).SetEase(Ease.Linear).OnComplete(() =>
            {
                // Camera background changes
                Camera.main.backgroundColor = Color.white;
                SceneLoaderController.UnLoadScene(SceneName.Scene1.ToString(),SceneLoaderController.scene1Loaded);
            });
            
        }

    }
}