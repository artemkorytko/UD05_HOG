using UnityEngine;
using UnityEngine.UI;

namespace HOG
{
    public abstract class BasePanelWIthButton : MonoBehaviour
    {
        private Button _button;
        private void Awake()
        {
            _button = GetComponentInChildren<Button>();
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