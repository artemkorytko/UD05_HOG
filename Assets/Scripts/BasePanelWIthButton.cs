using UnityEngine;
using UnityEngine.UI;

namespace HOG
{
    public abstract class BasePanelWIthButton : MonoBehaviour
    {
        /// <summary>
        /// ссылка на кнопку
        /// </summary>
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

        /// <summary>
        /// метод который вызывается при нажатии на кнопку
        /// </summary>
        protected abstract void OnButtonClick();
    }
}
