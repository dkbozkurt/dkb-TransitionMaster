// Dogukan Kaan Bozkurt
//		github.com/dkbozkurt

using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// </summary>

public class TitleBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject title;
    private RectTransform _titleRectTransform;
    
    private void OnEnable()
    {
        InitTitle();
        FadeIn();
    }

    private void InitTitle()
    {
        _titleRectTransform = title.GetComponent<RectTransform>();
        _titleRectTransform.localScale = Vector3.zero;
    }
    private void FadeIn()
    {
        _titleRectTransform.DOScale(new Vector3(5, 5,0), 1.5f).SetEase(Ease.Linear);

    }

    public void FadeOut()
    {
        
    }

}
