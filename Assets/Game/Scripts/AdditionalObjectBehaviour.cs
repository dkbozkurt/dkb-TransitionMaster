// Dogukan Kaan Bozkurt
//		github.com/dkbozkurt

using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Game.Scripts
{
    public class AdditionalObjectBehaviour : MonoBehaviour
    {
        public static Vector3 FocusSphereScale;
        [SerializeField] private GameObject sceneThreeSphere;

        private void OnEnable()
        {
            AssignInitValues();
            FadeIn();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("sphereScale: "+ FocusSphereScale);
            }
        }

        private void AssignInitValues()
        {
            sceneThreeSphere.transform.localScale = Vector3.zero;
            WaitForScene2Exit(0.55f);

        }

        private void FadeIn()
        {
            
        }

        public  void SphereFadeIn()
        {
            sceneThreeSphere.GetComponent<MeshRenderer>().enabled = true;
        }
        
        private void WaitForScene2Exit(float t)
        {

            StartCoroutine(Do());
            IEnumerator Do()
            {
                yield return new WaitForSeconds(t);
                sceneThreeSphere.transform.DOScale(FocusSphereScale, 0.15f).SetEase(Ease.Linear);
            }
        }
    }
}
