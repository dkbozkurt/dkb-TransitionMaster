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
            if(RotatingSpheresBehaviour.canRotate) RotateSphere();
        }

        private void RotateSphere()
        {
            transform.RotateAround(transform.parent.position,Vector3.forward, sphereRotationSpeed * Time.deltaTime);
        }

        private void OnMouseDown()
        {
            AdditionalObjectBehaviour.sphereScale = gameObject.transform.lossyScale;
            RotatingSpheresBehaviour.canRotate = false;
            gameObject.tag = "SelectedPlanet";
            RotatingSpheresBehaviour.endSceneTwo = true;
            RotatingSpheresBehaviour.ClickedSphereFocus(this.gameObject);
        }
        
    }
    
}



