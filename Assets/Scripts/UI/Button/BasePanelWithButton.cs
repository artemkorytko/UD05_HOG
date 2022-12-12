using UnityEngine.UI;

namespace HOG
{
    public abstract class BasePanelWithButton : PanelWithCanvasGroup
    {
        private Button _button;

        private void Awake ()
        {
            _button = GetComponentInChildren<Button>();
            GetComponentCanvasGroup();
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
        

    }
}