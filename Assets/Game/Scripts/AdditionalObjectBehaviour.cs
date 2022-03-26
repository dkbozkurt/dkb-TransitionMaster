// Dogukan Kaan Bozkurt
//		github.com/dkbozkurt

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>

namespace Game.Scripts
{
    public class AdditionalObjectBehaviour : MonoBehaviour
    {
        public static Vector3 sphereScale;
        [SerializeField] private GameObject focusSphere;

        private void OnEnable()
        {
            AssignInitValues();
            FadeIn();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("sphereScale: "+ sphereScale);
            }
        }

        private void AssignInitValues()
        {
            //focusSphere.transform.localScale = Vector3.zero;
            focusSphere.transform.localScale = sphereScale;
        }

        private void FadeIn()
        {
            
        }

        private void WaitForTime(float t)
        {

            StartCoroutine(Do());
            IEnumerator Do()
            {
                yield return new WaitForSeconds(t);
                
            }
        }
    }
}
