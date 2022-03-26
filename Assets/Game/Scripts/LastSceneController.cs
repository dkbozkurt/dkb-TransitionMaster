// Dogukan Kaan Bozkurt
//		github.com/dkbozkurt

using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Game.Scripts
{
    public class LastSceneController : MonoBehaviour
    {
        public static Vector3 FocusSphereScale;
        
        [SerializeField] private GameObject sceneThreeSphere;
        [SerializeField] private GameObject additionalObject;
        [SerializeField] private GameObject restartButton;
        private RectTransform _restartButtonTransform;
        
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
            _restartButtonTransform = restartButton.GetComponent<RectTransform>();
            
            _restartButtonTransform.transform.localScale =Vector3.zero;
            sceneThreeSphere.transform.localScale = Vector3.zero;
            additionalObject.transform.localScale = Vector3.zero;
        }

        private void FadeIn()
        {
            WaitForScene2Exit(0.55f);
        }
        
        private void WaitForScene2Exit(float t)
        {

            StartCoroutine(Do());
            IEnumerator Do()
            {
                yield return new WaitForSeconds(t);
                sceneThreeSphere.transform.DOScale(FocusSphereScale, 0.15f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    AdditionalObjectFades(true);
                });
            }
        }

        private void AdditionalObjectFades(bool fadeSituation)
        {
            if (fadeSituation)
            {
                additionalObject.transform.DOScale(Vector3.one*0.2f, 0.3f).SetEase(Ease.Flash).OnComplete(() =>
                {
                    ButtonTrigger(true);
                });
            }
            else additionalObject.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.Flash);
            
        }

        public void ButtonTrigger(bool buttonSituation)
        {
            if (buttonSituation)
            {
                _restartButtonTransform.DOScale(Vector3.one * 2, 0.2f).SetEase(Ease.InCubic);
            }
            else
            {
                _restartButtonTransform.DOScale(Vector3.zero, 0.1f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    // Load the first sceneS
                    FadeOut();
                });
            }
        }

        public static void FadeOut()
        {
            
        }
        
    }
}
