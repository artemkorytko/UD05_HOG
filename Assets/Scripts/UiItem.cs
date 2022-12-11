using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HOG
{
    public class UiItem : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI counterText;

        public int _count;

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
            counterText.text = _count.ToString();
            if (_count == 0)
            {
                gameObject.SetActive(false);
            }
            else
            { 
                counterText.text = _count.ToString();
            }
            
        }
    }
}