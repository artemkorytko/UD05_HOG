using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HOG
{
    public class UiItem : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _counterText;

        private int _count;
        
        public void SetSprite(Sprite sprite)
        {
            _image.sprite = sprite;
        }

        public void SetCounter(int index)
        {
            _count = index;
            _counterText.text = index.ToString();
        }

        public void Decrease()
        {
            
            if (--_count == 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _counterText.text = _count.ToString();
            }
        }
    }
}