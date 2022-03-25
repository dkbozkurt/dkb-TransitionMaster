// Dogukan Kaan Bozkurt
//		github.com/dkbozkurt

using System;
using System.Collections;
using System.Collections.Generic;
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
        private void OnEnable()
        {
            AssignInitValues();
            FadeIn();
        }

        private void AssignInitValues()
        {
            canRotate = false;
            transform.localScale = Vector3.zero;
        }
        
        private void FadeIn()
        {
            transform.DOScale(Vector3.one, 1.5f).OnComplete(() =>
            {
                canRotate = true;
            });
        }

        public static void SphereFocus(GameObject clickedSphere)
        {
            clickedSphere.transform.parent = null;
            Debug.Log("ga name " + clickedSphere.name);
        }
    }
}

