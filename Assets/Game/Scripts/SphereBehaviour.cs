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
    public class SphereBehaviour : MonoBehaviour
    {
        [SerializeField] private float sphereRotationSpeed;
        private void Update()
        {
            if(RotatingSpheresBehaviour.CanRotate) RotateSphere();
        }

        private void RotateSphere()
        {
            transform.RotateAround(transform.parent.position,Vector3.forward, sphereRotationSpeed * Time.deltaTime);
        }

        private void OnMouseDown()
        {
            LastSceneController.FocusSphereScale = gameObject.transform.lossyScale;

            RotatingSpheresBehaviour.CanRotate = false;
            gameObject.tag = "SelectedPlanet";
            RotatingSpheresBehaviour.EndSceneTwo = true;

            ShowSceneNumberBehaviour.TrasitionStickMove("Scene3");
            ShowSceneNumberBehaviour.PreviousLevelButtonShrink("Scene2");
            
            RotatingSpheresBehaviour.ClickedSphereFocus(this.gameObject);
        }
        
    }
    
}



