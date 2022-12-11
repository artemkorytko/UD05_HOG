using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace HOG
{
    public abstract class BaseUiPanelWithButton : MonoBehaviour
    {
        private Button _button;
        private CanvasGroup _canvasGroup;

        
        private void Awake()
        {
            _button = GetComponentInChildren<Button>();
            _canvasGroup = GetComponent<CanvasGroup>();
        }
  
        
        private void Start()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        
        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }
        
        
        protected abstract void OnButtonClick();
        
        
        public void SetAlphaCanvas(bool isOn)
        {
            SetAlphaPanel(isOn);
        }

        
        private void SetAlphaPanel(bool blocksRaycasts)
        {
            _canvasGroup.blocksRaycasts = blocksRaycasts; 
            _canvasGroup.DOFade(blocksRaycasts ? 1:0,2);
        }
    }
}