using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HOG
{
    public class UiItem : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI counterText;
        private int _count;

        public void SetSprite(Sprite sprite)
        {
            image.sprite = sprite;
        }

        public void SetCounter(int count)
        {
            _count = count;
            counterText.text = count.ToString();
        }

        public void Decrease()
        {
            _count--;
            if (_count == 0)
            {
                Destroy(gameObject);
            }
            else
            {
                counterText.text = _count.ToString();
            }
        }
    }
}