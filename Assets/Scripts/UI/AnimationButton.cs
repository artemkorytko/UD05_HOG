using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace HOG
{
    public class AnimationButton : MonoBehaviour
    {
        [Header("Setting Animation")]
        [SerializeField] private Vector3 _maxScaleButton;
        [SerializeField] private float _durationAnimationButton;
        
        private Button _button;
        private Sequence _sequence;
        
        
        private void Awake()
        {
            _button = GetComponent<Button>();
        }
        
        
        public void ActiveAnimationButton()
        {
            _sequence = DOTween.Sequence();
            
            StartAnimation();
            _button.onClick.AddListener(OnStopAnimation);
        }
 
        
        private void OnStopAnimation()
        {
            _sequence?.Kill(true);
            _button.onClick.RemoveListener(OnStopAnimation);
        }
         
        
        private void StartAnimation()
        {
            _sequence.Append(transform.DOScale(_maxScaleButton, _durationAnimationButton));
            _sequence.Append(transform.DOScale(Vector3.one, _durationAnimationButton));
            _sequence.SetLoops(-1);
        }
        
    }
}