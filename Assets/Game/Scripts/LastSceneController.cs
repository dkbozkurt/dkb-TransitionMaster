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
        
        private static GameObject _sceneThreeSphere;
        private static GameObject _additionalObject;
        private static GameObject _restartButton;
        
        private static RectTransform _restartButtonTransform;
        
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
            _restartButton = transform.GetChild(2).GetChild(0).gameObject;
            _restartButtonTransform = _restartButton.GetComponent<RectTransform>();
            _sceneThreeSphere = transform.GetChild(0).gameObject;
            _additionalObject = transform.GetChild(1).gameObject;

            _restartButtonTransform.transform.localScale =Vector3.zero;
            _sceneThreeSphere.transform.localScale = Vector3.zero;
            _additionalObject.transform.localScale = Vector3.zero;
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
                _sceneThreeSphere.transform.DOScale(FocusSphereScale, 0.15f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    AdditionalObjectFades(true);
                });
            }
        }

        private void AdditionalObjectFades(bool fadeSituation)
        {
            if (fadeSituation)
            {
                _additionalObject.transform.DOScale(Vector3.one*0.2f, 0.3f).SetEase(Ease.Flash).OnComplete(() =>
                {
                    ButtonTrigger(true);
                });
            }
            else _additionalObject.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.Flash);
            
        }

        public void ButtonTrigger(bool buttonSituation)
        {
            if (buttonSituation)
            {
                _restartButtonTransform.DOScale(Vector3.one * 2, 0.2f).SetEase(Ease.InCubic);
            }
            else
            {
                SceneLoaderController.LoadScene(SceneName.Scene1.ToString(),SceneLoaderController.Scene1Loaded);
                FadeOut();
            }
        }

        public static void FadeOut()
        {
            _restartButtonTransform.DOScale(Vector3.zero, 0.4f).SetEase(Ease.Linear);
            _sceneThreeSphere.transform.DOScale(Vector3.zero, 0.7f).SetEase(Ease.Linear);
            _additionalObject.transform.DOScale(Vector3.zero, 0.7f).SetEase(Ease.Linear).OnComplete(() =>
            {
                SceneLoaderController.UnLoadScene(SceneName.Scene3.ToString(),SceneLoaderController.Scene3Loaded);
            });
        }
        
    }
}
